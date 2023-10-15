using Code.Services.Timer;
using Code.UI.LoadingCurtain;
using Code.UI.Services.WindowService;
using Code.UI.Windows;
using UnityEngine;

namespace Code.Infrastructure.StateMachine.States
{
    public class GameOverState : IPayloadState<WindowType>
    {
        private IGameStateMachine _gameStateMachine;
        private LoadingCurtain _loadingCurtain;
        private IWindowService _windowService;
        private ITimerService _timerService;
        
        public GameOverState(IGameStateMachine gameStateMachine, 
            LoadingCurtain loadingCurtain,
            IWindowService windowService,
            ITimerService timerService)
        {
            _gameStateMachine = gameStateMachine;
            _loadingCurtain = loadingCurtain;
            _windowService = windowService;
            _timerService = timerService;
        }
        
        public void Enter(WindowType type)
        {
            _windowService.Open(type);
            Time.timeScale = 0;
        }

        public void Exit()
        {
            _loadingCurtain.Show();
            _timerService.Reset();
            Time.timeScale = 1;
        }
    }
}