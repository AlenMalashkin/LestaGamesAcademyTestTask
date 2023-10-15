using Cinemachine;
using Code.Logic.PlayerLogic;
using Code.Logic.Tiles;
using Code.Services;
using UnityEngine;

namespace Code.Infrastructure.Factories
{
    public interface IGameFactory : IService
    {
        CinemachineVirtualCamera CreateCamera(Transform follow);
        Player CreatePlayer(Vector3 position);
        GameObject CreateStarterTile(Vector3 position);
        GameObject CreateRouteTile(Vector3 position);
        GameObject CreateFinishTile(Vector3 position);
        GameObject CreateDeathZone(Vector3 position);
        GameObject CreateBlock(BlockType type, Vector3 position);
    }
}