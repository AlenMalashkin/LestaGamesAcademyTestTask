using Code.Infrastructure.Factories;
using Code.StaticData.LevelStaticData;
using UnityEngine;

namespace Code.Services.LevelGenerationService
{
    public class LevelGenerationService : ILevelGenerationService
    {
        private IGameFactory _gameFactory;
        private IStaticDataService _staticDataService;

        private LevelStaticData _levelStaticData;
        
        public LevelGenerationService(IGameFactory gameFactory, IStaticDataService staticDataService)
        {
            _gameFactory = gameFactory;
            _staticDataService = staticDataService;
        }

        public void LoadStaticData()
        {
            _levelStaticData = _staticDataService.ForLevel(LevelType.Main);
        }

        public void GenerateLevel()
        {
            CreateStarterTile();

            for (int i = 0; i < _levelStaticData.RouteWidth; i++)
            {
                for (int j = 0; j < _levelStaticData.RouteLength; j++)
                {
                    _gameFactory.CreateRouteTile(_levelStaticData.FirstRoutePosition
                                                 + new Vector3(
                                                     i * _levelStaticData.TileWidth,
                                                     0,
                                                     j * _levelStaticData.TileLength));
                }
            }
            
            CreateFinishTile();
            
            CreateDeathZone();
        }

        private void CreateStarterTile()
        {
            _gameFactory.CreateStarterTile(_levelStaticData.StartTilePosition);
        }

        private void CreateFinishTile()
        {
            _gameFactory.CreateFinishTile(new Vector3(0, 0,
                _levelStaticData.RouteLength * 
                _levelStaticData.FinishTileSize +
                _levelStaticData.FirstRoutePosition.z));
        }

        private void CreateDeathZone()
        {
            _gameFactory.CreateDeathZone(_levelStaticData.DeathZonePosition);
        }
    }
}