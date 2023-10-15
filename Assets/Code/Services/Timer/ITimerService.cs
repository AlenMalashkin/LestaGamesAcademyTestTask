using Code.Infrastructure.Update;

namespace Code.Services.Timer
{
    public interface ITimerService : IService, ITickable
    {
        float CurrentTime { get; }
        void Start();
        void Finish();
        void Reset();
    }
}