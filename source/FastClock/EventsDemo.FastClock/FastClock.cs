using System;
using System.Windows.Threading;

namespace EventsDemo.Logic {
    public class FastClock {
        private static FastClock instance = null;

        private readonly DispatcherTimer _timer;
        private bool _isRunning;

        public static FastClock GetInstance(DateTime currentDateTime)
        {
            if (instance == null)
            {
                instance = new FastClock(currentDateTime);
            }
            return instance;
        }

        public DateTime CurrentDateTime { get; private set; }

        public bool IsRunning {
            get { return _isRunning; }
            set {
                _isRunning = value;

                if (_isRunning)
                {
                    _timer.Start();
                }
                else
                {
                    _timer.Stop();
                }
            }
        }

        private FastClock(DateTime currentDateTime)
        {
            this._timer = new DispatcherTimer();
            this.CurrentDateTime = currentDateTime;
        }
    }
}
