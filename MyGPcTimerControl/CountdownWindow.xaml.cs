using System.Windows;

namespace MyGPcTimerControl
{
    public partial class CountdownWindow : Window
    {
        public CountdownWindow()
        {
            InitializeComponent();
        }

        public void UpdateCountdown(int secondsLeft)
        {
            CountdownText.Text = $"Kapanışa {secondsLeft} sn";
        }
    }
}