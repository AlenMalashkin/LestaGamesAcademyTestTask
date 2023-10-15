using Code.Infrastructure.StateMachine;
using Code.Infrastructure.Update;
using Code.Services;
using Code.UI.LoadingCurtain;

namespace Code.Infrastructure
{
    public class Game
    {
        public IGameStateMachine GameStateMachine;
        
        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain, Updater updater)
        {
            GameStateMachine = new GameStateMachine(
                new SceneLoader(coroutineRunner), 
                loadingCurtain,
                updater,
                ServiceLocator.Container);
        }
    }
}