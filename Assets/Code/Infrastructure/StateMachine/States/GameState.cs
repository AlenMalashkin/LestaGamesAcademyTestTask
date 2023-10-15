using Code.Infrastructure.Factories;
using Code.Logic;
using Code.Logic.PlayerLogic;
using Code.Services;
using Code.Services.InputService;
using Code.Services.LevelGenerationService;
using Code.StaticData.LevelStaticData;
using Code.UI.Factories;
using Code.UI.LoadingCurtain;

namespace Code.Infrastructure.StateMachine.States
{
    public class GameState : IPayloadState<LevelType>
    {
        private IGameStateMachine _gameStateMachine;
        private SceneLoader _sceneLoader;
        private LoadingCurtain _loadingCurtain;
        private IGameFactory _gameFactory;
        private IUIFactory _uiFactory;
        private IStaticDataService _staticDataService;
        private IInputService _inputService;
        private ILevelGenerationService _levelGenerationService;

        private LevelType _levelType;

        public GameState(IGameStateMachine gameStateMachine, 
            SceneLoader sceneLoader,
            LoadingCurtain loadingCurtain,
            IGameFactory gameFactory,
            IUIFactory uiFactory,
            IStaticDataService staticDataService,
            IInputService inputService,
            ILevelGenerationService levelGenerationService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
            _uiFactory = uiFactory;
            _staticDataService = staticDataService;
            _inputService = inputService;
            _levelGenerationService = levelGenerationService;
        }
        
        public void Enter(LevelType type)
        {
            _levelType = type;
            _sceneLoader.Load("Game", OnLoad);
            _inputService.Enable();
        }

        public void Exit()
        {
            _inputService.Disable();
        }

        private void OnLoad()
        {
            InitializeGameWorld();
            _loadingCurtain.Hide();
        }

        private void InitializeGameWorld()
        {
            LevelStaticData levelStaticData = _staticDataService.ForLevel(_levelType);
            
            _levelGenerationService.GenerateLevel();
            Player player = _gameFactory.CreatePlayer(levelStaticData.PlayerPosition);
            _gameFactory.CreateCamera(player.CameraRoot);

            _uiFactory.CreateHud(player.GetComponent<IDamageable>());
        }
    }
}