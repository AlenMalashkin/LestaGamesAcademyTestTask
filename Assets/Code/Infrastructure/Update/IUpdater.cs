using Code.Services;

namespace Code.Infrastructure.Update
{
    public interface IUpdater : IService
    {
        void AddTickable(ITickable tickable);
        void RemoveTickable(ITickable tickable);
    }
}