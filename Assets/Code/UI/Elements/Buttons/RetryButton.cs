using Code.Infrastructure.StateMachine;
using Code.Infrastructure.StateMachine.States;
using Code.Services;
using Code.StaticData.LevelStaticData;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Elements.Buttons
{
    public class RetryButton : MonoBehaviour
    {
        [SerializeField] private Button retryButton;

        private IGameStateMachine _gameStateMachine;
        
        private void Awake()
        {
            _gameStateMachine = ServiceLocator.Container.Resolve<IGameStateMachine>();
        }

        private void OnEnable()
        {
            retryButton.onClick.AddListener(Retry);
        }

        private void OnDisable()
        {
            retryButton.onClick.RemoveListener(Retry);
        }

        private void Retry()
        {
            _gameStateMachine.Enter<GameState, LevelType>(LevelType.Main);
        }
    }
}