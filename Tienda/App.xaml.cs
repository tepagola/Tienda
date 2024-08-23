using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using Tienda.Data;

namespace Tienda
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IDatabaseInitializer _databaseInitializer;

        public App()
        {
            // Configurar servicios e inyección de dependencias
            var services = new ServiceCollection();
            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();
            _databaseInitializer = serviceProvider.GetRequiredService<IDatabaseInitializer>();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<InventarioContext>();
            services.AddTransient<IDatabaseInitializer, DatabaseInitializer>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Inicializar la base de datos aquí
            await _databaseInitializer.EnsureDatabaseCreatedAsync();

            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }

}
