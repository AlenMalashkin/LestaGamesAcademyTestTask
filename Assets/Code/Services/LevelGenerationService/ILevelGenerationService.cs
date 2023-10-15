namespace Code.Services.LevelGenerationService
{
    public interface ILevelGenerationService : IService
    {
        void LoadStaticData();
        void GenerateLevel();
    }
}