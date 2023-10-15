using Code.Infrastructure.AssetProvider;
using Code.Infrastructure.Factories;
using Code.Infrastructure.Update;
using Code.Services;
using Code.Services.InputService;
using Code.Services.LevelGenerationService;
using Code.Services.Timer;
using Code.StaticData.LevelStaticData;
using Code.UI.Factories;
using Code.UI.LoadingCurtain;
using Code.UI.Services.WindowService;

namespace Code.Infrastructure.StateMachine.States
{
    public class BootstrapState : IState
    {
        private IGameStateMachine _gameStateMachine;
        private SceneLoader _sceneLoader;
        private LoadingCurtain _loadingCurtain;
        private Updater _updater;
        private ServiceLocator _serviceLocator;

        public BootstrapState(IGameStateMachine gameStateMachine, 
            SceneLoader sceneLoader,
            LoadingCurtain loadingCurtain,
            Updater updater,
            ServiceLocator serviceLocator)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _updater = updater;
            _serviceLocator = serviceLocator;
            
            RegisterServices();
        }
        
        public void Enter()
        {
            _loadingCurtain.Show();
            _sceneLoader.Load("Bootstrap", OnLoad);
        }

        public void Exit()
        {
        }

        private void OnLoad()
        {
            _gameStateMachine.Enter<GameState, LevelType>(LevelType.Main);
        }

        private void RegisterServices()
        {
            _serviceLocator.RegisterService<IUpdater>(_updater);
            _serviceLocator.RegisterService(_gameStateMachine);
            RegisterStaticDataService();
            _serviceLocator.RegisterService<IAssetProvider>(new AssetProvider.AssetProvider());
            _serviceLocator.RegisterService<IGameFactory>(new GameFactory(_serviceLocator.Resolve<IAssetProvider>()));
            _serviceLocator.RegisterService<IUIFactory>(new UIFactory(_serviceLocator.Resolve<IAssetProvider>()));
            _serviceLocator.RegisterService<IWindowService>(new WindowService(_serviceLocator.Resolve<IAssetProvider>()));
            _serviceLocator.RegisterService<IInputService>(new DesctopInputService());
            _serviceLocator.RegisterService<ITimerService>(new TimerService(_updater));
            RegisterLevelGenerationService();
        }

        private void RegisterStaticDataService()
        {
            IStaticDataService staticDataService = new StaticDataService();
            staticDataService.Load();
            _serviceLocator.RegisterService(staticDataService);
        }

        private void RegisterLevelGenerationService()
        {
            ILevelGenerationService levelGenerationService = new LevelGenerationService(
                _serviceLocator.Resolve<IGameFactory>(),
                _serviceLocator.Resolve<IStaticDataService>());
            levelGenerationService.LoadStaticData();
            _serviceLocator.RegisterService(levelGenerationService);
        }
    }
}