using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Timers;
using System.Windows;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace MyGPcTimerControl
{
    public partial class MainWindow : Window
    {
        private readonly NotifyIcon _trayIcon;
        private readonly Timer _checkTimer;
        private readonly string _jsonUrl = "https://api.npoint.io/c53804a3eb8ba7caa148";
        private List<TimeRange> _workingHours = new();
        private EkSure _ekSure;
        private CountdownWindow _countdownWindow;

        public MainWindow()
        {
            InitializeComponent();
            this.Hide();
            _trayIcon = new NotifyIcon
            {
                Icon = System.Drawing.SystemIcons.Information,
                Visible = true,
                Text = "Çalışma Saati Takibi"
            };
            _trayIcon.ContextMenuStrip = new ContextMenuStrip();
            _trayIcon.ContextMenuStrip.Items.Add("Çıkış", null, (s, e) => System.Windows.Application.Current.Shutdown());

            _checkTimer = new Timer(1000);
            _checkTimer.Elapsed += CheckWorkingHours;
            _checkTimer.Start();

            LoadSettings();

            // Saatleri her 60 saniyede bir güncelleyen timer
            var updateTimer = new Timer(15000);
            updateTimer.Elapsed += (s, e) => LoadSettings();
            updateTimer.Start();
        }

        private async void LoadSettings()
        {
            try
            {
                using var httpClient = new HttpClient();
                var response = await httpClient.GetStringAsync(_jsonUrl);
                var data = JsonSerializer.Deserialize<DatabaseModel>(response);
                _workingHours = data?.saat_araliklari ?? new List<TimeRange>();
                _ekSure = data?.ek_sure ?? new EkSure();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Veri çekme hatası: " + ex.Message);
            }
        }

        private void CheckWorkingHours(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                DateTime now = DateTime.Now;

                bool icinde = false;
                bool geriSayim = false;

                foreach (var range in _workingHours)
                {
                    if (TimeSpan.TryParse(range.basla, out var start) && TimeSpan.TryParse(range.bitir, out var end))
                    {
                        if (now.TimeOfDay >= start && now.TimeOfDay <= end)
                        {
                            icinde = true;

                            if ((end - now.TimeOfDay).TotalSeconds <= 30 && (end - now.TimeOfDay).TotalSeconds > 0)
                            {
                                geriSayim = true;
                            }
                            break;
                        }
                    }
                }

                if (!icinde)
                {
                    if (_ekSure.aktif && DateTime.TryParse(_ekSure.verildigi_zaman, out var verilenZaman))
                    {
                        if ((now - verilenZaman).TotalMinutes <= _ekSure.sure_dakika)
                            icinde = true;
                    }
                }

                if (geriSayim)
                {
                    ShowCountdown();
                }
                else
                {
                    HideCountdown();
                }

                if (!icinde)
                {
                    ShowOverlay();
                }
                else
                {
                    CloseOverlay();
                }
            });
        }

        private OverlayWindow _overlay;

        private void ShowOverlay()
        {
            if (_overlay == null)
            {
                _overlay = new OverlayWindow();
                _overlay.SetWorkingHours(_workingHours);
                _overlay.Show();
            }
        }


        private void CloseOverlay()
        {
            if (_overlay != null)
            {
                _overlay.Close();
                _overlay = null;
            }
        }

        private void ShowCountdown()
        {
            if (_countdownWindow == null)
            {
                _countdownWindow = new CountdownWindow();
                _countdownWindow.Show();
            }
            int secondsLeft = 0;
            foreach (var range in _workingHours)
            {
                if (TimeSpan.TryParse(range.bitir, out var end))
                {
                    var now = DateTime.Now.TimeOfDay;
                    if (now <= end && (end - now).TotalSeconds <= 30 && (end - now).TotalSeconds > 0)
                    {
                        secondsLeft = (int)(end - now).TotalSeconds;
                        break;
                    }
                }
            }
            _countdownWindow.UpdateCountdown(secondsLeft);
        }

        private void HideCountdown()
        {
            if (_countdownWindow != null)
            {
                _countdownWindow.Close();
                _countdownWindow = null;
            }
        }
    }

    public class DatabaseModel
    {
        public List<TimeRange> saat_araliklari { get; set; }
        public EkSure ek_sure { get; set; }
    }

    public class TimeRange
    {
        public string basla { get; set; }
        public string bitir { get; set; }
    }

    public class EkSure
    {
        public bool aktif { get; set; }
        public int sure_dakika { get; set; }
        public string verildigi_zaman { get; set; }
    }
}
