using System;
using Gameplay;

namespace UI
{
    public class FailedObserver : IFailedLevel
    {
        public event Action TaskFailed;

        private readonly Item2DCounter _item2DCounter;
        private readonly Timer _timer;

        
        public FailedObserver(Item2DCounter item2DCounter, Timer timer)
        {
            _item2DCounter = item2DCounter;
            _timer = timer;
            
            item2DCounter.TaskFailed += OnFailed;
            timer.TaskFailed += OnFailed;
        }

        private void OnFailed()
        {
            _item2DCounter.TaskFailed -= OnFailed;
            _timer.TaskFailed -= OnFailed;
            
            TaskFailed?.Invoke();
        }
    }
}