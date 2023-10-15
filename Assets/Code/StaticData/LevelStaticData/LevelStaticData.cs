using System;
using UnityEngine;

namespace Code.StaticData.LevelStaticData
{
    [CreateAssetMenu(fileName = "LevelStaticData", menuName = "Level Config", order = 0)]
    public class LevelStaticData : ScriptableObject
    {
        [SerializeField] private LevelType type;
        [SerializeField] private Vector3 startTilePosition;
        [SerializeField] private Vector3 playerPosition;

        [Header("Level Generation")] 
        [SerializeField] private int routeLength;
        [SerializeField] private int routeWidth;
        [SerializeField] private int tileLength;
        [SerializeField] private int tileWidth;
        [SerializeField] private int finishTileSize;
        [SerializeField] private Vector3 firstRoutePosition;
        [SerializeField] private Vector3 deathZonePosition;

        public LevelType Type => type;
        public Vector3 StartTilePosition => startTilePosition;
        public Vector3 PlayerPosition => playerPosition;
        public int RouteWidth => routeWidth;
        public int RouteLength => routeLength;
        public int TileLength => tileLength;
        public int TileWidth => tileWidth;
        public int FinishTileSize => finishTileSize;
        public Vector3 FirstRoutePosition => firstRoutePosition;
        public Vector3 DeathZonePosition => deathZonePosition;
    }
}