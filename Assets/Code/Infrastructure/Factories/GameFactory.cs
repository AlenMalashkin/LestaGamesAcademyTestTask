using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using Code.Infrastructure.AssetProvider;
using Code.Infrastructure.Constants;
using Code.Logic;
using Code.Logic.PlayerLogic;
using Code.Logic.Tiles;
using UnityEngine;

namespace Code.Infrastructure.Factories
{
    public class GameFactory : IGameFactory
    {
        private IAssetProvider _assetProvider;
        
        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        
        public CinemachineVirtualCamera CreateCamera(Transform follow)
        {
            CinemachineVirtualCamera playerCamera = Object.Instantiate(
                _assetProvider.LoadPrefab<CinemachineVirtualCamera>(PrefabPaths.PlayerCamera));
            playerCamera.Follow = follow;
            return playerCamera;
        }

        public Player CreatePlayer(Vector3 position)
        {
            Player player =  Object.Instantiate(
                _assetProvider.LoadPrefab<Player>(PrefabPaths.PlayerPrefab),
                position,
                Quaternion.identity);

            IDamageable damageable = player.GetComponent<IDamageable>();
            damageable.MaxHealth = 10;
            damageable.CurrentHealth = 10;
            
            return player;
        }

        public GameObject CreateStarterTile(Vector3 position)
        {
            return Object.Instantiate(
                _assetProvider.LoadPrefab(PrefabPaths.StarterTilePrefab),
                position,
                Quaternion.identity);
        }

        public GameObject CreateRouteTile(Vector3 position)
        {
            return Object.Instantiate(
                _assetProvider.LoadPrefab(PrefabPaths.RouteTilePrefab), 
                position,
                Quaternion.identity);
        }

        public GameObject CreateFinishTile(Vector3 position)
        {
            return Object.Instantiate(
                _assetProvider.LoadPrefab(PrefabPaths.FinishTilePrefab), 
                position,
                Quaternion.identity);
        }

        public GameObject CreateDeathZone(Vector3 position)
        {
            return Object.Instantiate(_assetProvider.
                    LoadPrefab(PrefabPaths.DeathZone),
                position,
                Quaternion.identity);
        }

        public GameObject CreateBlock(BlockType type, Vector3 position)
        {
            List<Block> blocks = _assetProvider
                .LoadPrefabs<Block>(PrefabPaths.Blocks)
                .ToList();

            GameObject block = blocks.Find(x => x.Type == type).gameObject;

            return Object.Instantiate(block, position, Quaternion.identity);
        }
    }
}