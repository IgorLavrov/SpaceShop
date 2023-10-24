using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.ApplicationServices.Services;
using Shop.Core.ServiceInterface;
using Shop.Data;
using Shop.RealEstate.Test.Macros;
using Shop.RealEstate.Test.Mock;

namespace Shop.RealEstate.Test
{
   
    
        public abstract class TestBase
        {
            protected IServiceProvider serviceProvider { get; }

            protected TestBase()
            {
                var services = new ServiceCollection();
                SetupServices(services);
                serviceProvider = services.BuildServiceProvider();

            }
            public void Dispose()
            {

            }
            protected T Svc<T>()
            {
                return serviceProvider.GetService<T>();
            }

            protected T Macro<T>() where T : IMacros
            {
                return serviceProvider.GetService<T>();

            }
            public virtual void SetupServices(IServiceCollection services)
            {
                services.AddScoped< IRealEstateServices, RealEstatesServices>();
                services.AddScoped<IFileServices, FilesServices>();
                services.AddScoped<IHostEnvironment, MockIHostEnviroment>();



                services.AddDbContext<ShopContext>(x =>
                {
                    x.UseInMemoryDatabase("TEST");
                    x.ConfigureWarnings(e => e.Ignore(InMemoryEventId.TransactionIgnoredWarning));
                });

                RegisterMacros(services);
            }

            private void RegisterMacros(IServiceCollection services)
            {
                var macroBaseType = typeof(IMacros);

                var macros = macroBaseType.Assembly.GetTypes()
                    .Where(x => macroBaseType.IsAssignableFrom(x) && !x.IsInterface
                    && !x.IsAbstract);
                foreach (var macro in macros)
                {
                    services.AddSingleton(macro);
                }


            }

        }
    }
