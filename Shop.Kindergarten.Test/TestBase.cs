
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.ApplicationServices.Services;
using Shop.Core.ServiceInterface;
using Shop.Data;
using Shop.Kindergarten.Test.Macros;
using Shop.Spaceship.Test.Mock;
using System;

namespace Shop.Kindergarten.Test
{
    
    public abstract class TestBase
    {
        protected IServiceProvider serviceProvider { get; }

        protected TestBase()
        {
            var service= new ServiceCollection();
            SetupServices(service);
            serviceProvider = service.BuildServiceProvider();

        }
        public void Dispose()
        {

        }

        protected T Svc<T>()
        {
        
        return serviceProvider.GetService<T>();
        
        }


    protected T Macro<T>() where T : IMacro
    {
        return serviceProvider.GetService<T>();

    }

    public virtual  void SetupServices(IServiceCollection service) {
            service.AddScoped<IKindergartenServices,KindergartenServices>();
            service.AddScoped<IFileServices,FilesServices>();
            service.AddScoped<IHostEnvironment, MockIHostEnviroment>();


            service.AddDbContext<ShopContext>(x =>
            {
                x.UseInMemoryDatabase("TEST");
                x.ConfigureWarnings(e => e.Ignore(InMemoryEventId.TransactionIgnoredWarning));

            });

            RegisterMacros(service);

        }

        private void RegisterMacros(IServiceCollection service)
        {
           var macroBaseType= typeof(TestBase);
            var macros = macroBaseType.Assembly.GetTypes()
                    .Where(x => macroBaseType.IsAssignableFrom(x) && !x.IsInterface
                    && !x.IsAbstract);
            foreach (var macro in macros)
            {
                service.AddSingleton(macro);
            }


        }
    }
}