using Code.Logic.PlayerLogic;
using Code.Services;
using Code.Services.Timer;
using UnityEngine;

namespace Code.Logic
{
    public class StartTrigger : MonoBehaviour
    {
        private ITimerService _timerService;
        
        private void Awake()
        {
            _timerService = ServiceLocator.Container.Resolve<ITimerService>();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                _timerService.Start();
            }
        }
    }
}