using System;
using System.Windows;
using EventsDemo.Logic;

namespace EventsDemo.FastClockWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private DateTime _dateTime;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_Initialized(object sender, EventArgs e)
        {
            _dateTime = GetCurrentTime();

            DatePickerDate.SelectedDate = DateTime.Today;
            TextBoxTime.Text = _dateTime.ToShortTimeString();
            FastClock.GetInstance(_dateTime);
        }

        private void ButtonSetTime_Click(object sender, RoutedEventArgs e)
        {
            SetFastClockStartDateAndTime();
        }

        private void SetFastClockStartDateAndTime()
        {
            string date = DatePickerDate.Text;
            string time = TextBoxTime.Text;
            _dateTime = StringToDateTime(date, time);
            FastClock.GetInstance(_dateTime);
        }

        private DateTime StringToDateTime(string dateString, string timeString)
        {
            string[] dateParts = dateString.Split('.');
            string[] timeParts = timeString.Split(':');
            int day = 0;
            int month = 0;
            int year = 0;
            int hour = 0;
            int minute = 0;
            int second = 0;

            Int32.TryParse(dateParts[0], out day);
            Int32.TryParse(dateParts[1], out month);
            Int32.TryParse(dateParts[2], out year);
            Int32.TryParse(timeParts[0], out hour);
            Int32.TryParse(timeParts[1], out minute);
            if(timeParts.Length >= 3)
            {
                Int32.TryParse(timeParts[2], out second);
            }
            return new DateTime(year, month, day, hour, minute, second);
        }

        private void FastClockOneMinuteIsOver(object sender, DateTime fastClockTime)
        {

        }

        private void CheckBoxClockRuns_Click(object sender, RoutedEventArgs e)
        {
            FastClock fastClock = FastClock.GetInstance(_dateTime);
            fastClock.IsRunning = !fastClock.IsRunning;
        }

        private void ButtonCreateView_Click(object sender, RoutedEventArgs e)
        {
            DigitalClock digitalClock = new DigitalClock();
            digitalClock.Owner = this;
            digitalClock.Show();
        }

        private DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}
