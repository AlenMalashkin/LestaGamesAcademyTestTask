using Code.Infrastructure.StateMachine.States;
using Code.Infrastructure.Update;
using Code.UI.LoadingCurtain;
using UnityEngine;

namespace Code.Infrastructure
{
    public class Bootstrap : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private LoadingCurtain loadingCurtain;
        [SerializeField] private Updater updater;
        
        private Game _game;
        
        private void Awake()
        {
            _game = new Game(this, Instantiate(loadingCurtain),Instantiate(updater));
            _game.GameStateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(this);
        }
    }
}