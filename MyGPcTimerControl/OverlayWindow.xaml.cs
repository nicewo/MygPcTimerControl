using System.Windows;
using MyGPcTimerControl;

namespace MyGPcTimerControl
{
    public partial class OverlayWindow : Window
    {
        public OverlayWindow()
        {
            InitializeComponent();
        }
        public void SetWorkingHours(List<TimeRange> saatAraliklari)
        {
            List<string> saatListesi = new();
            foreach (var saat in saatAraliklari)
            {
                saatListesi.Add($"{saat.basla} - {saat.bitir}");
            }
            WorkingHoursList.ItemsSource = saatListesi;
        }

    }
}