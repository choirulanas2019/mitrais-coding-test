using MitraisCodingTest.Core.Models;
using MitraisCodingTest.Core.Repositories;
using MitraisCodingTest.Core.Repositories.Interface;
using MitraisCodingTest.Core.Services;
using MitraisCodingTest.Core.Services.Interface;
using System;
using Unity;

namespace MitraisCodingTest
{
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        public static IUnityContainer Container => container.Value;
        #endregion
        
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IMitraisCodingTestContext, MitraisCodingTestContext>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IUserService, UserService>();
        }
    }
}