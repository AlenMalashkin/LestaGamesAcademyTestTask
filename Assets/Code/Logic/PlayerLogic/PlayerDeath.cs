using Code.Infrastructure.StateMachine;
using Code.Infrastructure.StateMachine.States;
using Code.Services;
using Code.UI.Windows;
using UnityEngine;

namespace Code.Logic.PlayerLogic
{
    public class PlayerDeath : MonoBehaviour
    {
        [SerializeField] private PlayerHealth playerHealth;
        
        private IGameStateMachine _gameStateMachine;

        private void Awake()
        {
            _gameStateMachine = ServiceLocator.Container.Resolve<IGameStateMachine>();
        }

        private void OnEnable()
        {
            playerHealth.HealthChanged += Die;
        }

        private void OnDisable()
        {
            playerHealth.HealthChanged -= Die;
        }

        private void Die(int currentHealth)
        {
            if (currentHealth <= 0)
                _gameStateMachine.Enter<GameOverState, WindowType>(WindowType.Lose);
        }
    }
}