using Code.Infrastructure.Factories;
using Code.Services;
using UnityEngine;

namespace Code.Logic.Tiles
{
    public abstract class Tile : MonoBehaviour
    {
        [SerializeField] private BlockType[] blocksOnTile;
        [SerializeField] private int horizontalSize;
        [SerializeField] private int verticalSize;

        private IGameFactory _gameFactory;
        
        private void Awake()
        {
            _gameFactory = ServiceLocator.Container.Resolve<IGameFactory>();
            GenerateTile();
        }

        private void OnDrawGizmos()
        {
            for (int i = 0; i < horizontalSize; i++)
            {
                for (int j = 0; j < verticalSize; j++)
                {
                    Gizmos.color = Color.cyan;
                    Gizmos.DrawCube(new Vector3(i, 0, j), new Vector3(0.95f, 0.95f, 0.95f));
                }
            }
        }

        private void GenerateTile()
        {
            for (int i = 0; i < horizontalSize; i++)
            {
                for (int j = 0; j < verticalSize; j++)
                {
                    _gameFactory.
                        CreateBlock(blocksOnTile[Random.Range(0, blocksOnTile.Length)],
                            new Vector3(i, 0, j) + transform.position);
                }
            }
        }
    }
}