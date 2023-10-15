using System;
using System.Collections.Generic;
using Code.Infrastructure.Factories;
using Code.Infrastructure.StateMachine.States;
using Code.Infrastructure.Update;
using Code.Services;
using Code.Services.InputService;
using Code.Services.LevelGenerationService;
using Code.Services.Timer;
using Code.UI.Factories;
using Code.UI.LoadingCurtain;
using Code.UI.Services.WindowService;
using UnityEngine.Timeline;

namespace Code.Infrastructure.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private Dictionary<Type, IExitableState> _states;
        private IExitableState _currentState;
        
        public GameStateMachine(SceneLoader sceneLoader, 
            LoadingCurtain loadingCurtain,
            Updater updater,
            ServiceLocator serviceLocator)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(
                    this, 
                    sceneLoader,
                    loadingCurtain,
                    updater,
                    serviceLocator),
                [typeof(GameState)] = new GameState(
                    this,
                    sceneLoader,
                    loadingCurtain,
                    serviceLocator.Resolve<IGameFactory>(),
                    serviceLocator.Resolve<IUIFactory>(),
                    serviceLocator.Resolve<IStaticDataService>(),
                    serviceLocator.Resolve<IInputService>(),
                    serviceLocator.Resolve<ILevelGenerationService>()),
                [typeof(GameOverState)] = new GameOverState(
                    this, 
                    loadingCurtain,
                    serviceLocator.Resolve<IWindowService>(),
                    serviceLocator.Resolve<ITimerService>())
            };
        }
        
        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TPayloadState, TPayload>(TPayload payload) where TPayloadState : class, IPayloadState<TPayload>
        {
            TPayloadState payloadState = ChangeState<TPayloadState>();
            payloadState.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _currentState?.Exit();

            TState state = GetState<TState>();
            _currentState = state;
		
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState
            => _states[typeof(TState)] as TState;
    }
}