using Code.Services;

namespace Code.Infrastructure
{
    public class AllServices
    {
        public static AllServices Container => _instance ?? (_instance = new AllServices());
        private static AllServices _instance;
        public TService Single <TService>() where TService:IService
        {
            return Implemential<TService>.Service;
        }

        public void RegisterSingle<TService>(TService service) where TService:IService
        {
            Implemential<TService>.Service = service;
        }

        private static class Implemential<TService> where TService:IService
        {
            public static TService Service;
        }
    }
}