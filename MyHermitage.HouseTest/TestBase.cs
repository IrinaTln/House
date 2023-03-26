using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Hosting;
using MyHermitage.ApplicationServices.Services;
using MyHermitage.Core.ServiceInterface;
using MyHermitage.Data;
using MyHermitage.HouseTest.Macros;

namespace MyHermitage.HouseTest
{
    public abstract class TestBase : IDisposable
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

        public virtual void SetupServices(IServiceCollection services)
        {
            services.AddScoped<IHouseServices, HouseServices>();
            services.AddScoped<IHostEnvironment, MockWebHostingEnv>();

            services.AddDbContext<MyHermitageDbContext>(x =>
            {
                x.UseInMemoryDatabase("TEST");
                x.ConfigureWarnings(e => e.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });

            RegisterMacros(services);
        }

        protected T Svc<T>()
        {
            return serviceProvider.GetService<T>();
        }

        protected T Macro<T>() where T : IMacro
        {
            return serviceProvider.GetService<T>();
        }
        private void RegisterMacros(IServiceCollection services)
        {
            var macroBaseType = typeof(IMacro);

            var macros = macroBaseType.Assembly.GetTypes()
                .Where(x => macroBaseType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            foreach (var macro in macros)
            {
                services.AddTransient(macro);
            }
        }
    }
}
