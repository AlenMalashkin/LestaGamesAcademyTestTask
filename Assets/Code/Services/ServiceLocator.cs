namespace Code.Services
{
    public class ServiceLocator
    {
        private static ServiceLocator _instance;
        public static ServiceLocator Container => _instance ?? new ServiceLocator();
        
        public void RegisterService<TService>(TService service) where TService : IService
            => InstanceHolder<TService>.Instance = service;

        public TService Resolve<TService>() where TService : IService
            => InstanceHolder<TService>.Instance;

        private class InstanceHolder<TService> where TService : IService
        {
            public static TService Instance;
        }
    }
}