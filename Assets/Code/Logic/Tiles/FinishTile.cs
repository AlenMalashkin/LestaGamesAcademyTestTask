using System;
using Code.Infrastructure.StateMachine;
using Code.Infrastructure.StateMachine.States;
using Code.Logic.PlayerLogic;
using Code.Services;
using Code.Services.Timer;
using Code.UI.Windows;
using UnityEngine;

namespace Code.Logic.Tiles
{
    public class FinishTile : Tile
    {
        private IGameStateMachine _gameStateMachine;
        private ITimerService _timerService;
        
        private void Start()
        {
            _gameStateMachine = ServiceLocator.Container.Resolve<IGameStateMachine>();
            _timerService = ServiceLocator.Container.Resolve<ITimerService>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                _timerService.Finish();
                _gameStateMachine.Enter<GameOverState, WindowType>(WindowType.Win);
            }
        }
    }
}