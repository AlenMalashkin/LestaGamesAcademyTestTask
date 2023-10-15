using Code.StaticData.LevelStaticData;

namespace Code.Services
{
    public interface IStaticDataService : IService
    {
        void Load();
        LevelStaticData ForLevel(LevelType type);
    }
}