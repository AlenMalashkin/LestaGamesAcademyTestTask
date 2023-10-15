using System.Collections.Generic;
using UnityEngine;

namespace Code.Infrastructure.Update
{
    public class Updater : MonoBehaviour, IUpdater
    {
        private List<ITickable> _tickables = new List<ITickable>();

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            foreach (var tickable in _tickables)
            {
                tickable.Tick();
            }
        }

        public void AddTickable(ITickable tickable)
            => _tickables.Add(tickable);

        public void RemoveTickable(ITickable tickable)
            => _tickables.Remove(tickable);
    }
}