using System;
using Code.Infrastructure.Update;
using UnityEngine;

namespace Code.Services.Timer
{
    public class TimerService : ITimerService
    {
        public float CurrentTime { get; private set; }
        private bool _countingTime;

        private IUpdater _updater;

        public TimerService(IUpdater updater)
        {
            _updater = updater;
        }

        public void Tick()
        {
            CountTime();
        }

        public void Start()
        {
            _updater.AddTickable(this);
            _countingTime = true;
        }

        public void Finish()
        {
            _countingTime = false;
            _updater.RemoveTickable(this);
        }
        
        public void Reset()
        {
            CurrentTime = 0;
        }

        private void CountTime()
        {
            if (_countingTime)
                CurrentTime += Time.deltaTime;
        }
    }
}