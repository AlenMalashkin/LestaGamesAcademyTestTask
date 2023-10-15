using System.Collections.Generic;
using System.Linq;
using Code.Infrastructure.Constants;
using Code.StaticData.LevelStaticData;
using UnityEngine;

namespace Code.Services
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<LevelType, LevelStaticData> _levelsStaticData = new Dictionary<LevelType, LevelStaticData>();
        
        public void Load()
        {
            _levelsStaticData = Resources.LoadAll<LevelStaticData>(StaticDataPaths.LevelStaticData)
                .ToDictionary(x => x.Type);
        }

        public LevelStaticData ForLevel(LevelType type)
            => _levelsStaticData[type];
    }
}