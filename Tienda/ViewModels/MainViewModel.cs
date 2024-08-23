using System;
using System.Windows.Controls;
using System.Windows.Input;
using Tienda.Commands;
using Tienda.Views;

namespace Tienda.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        public ICommand VerProductosCommand { get; set; }
        public ICommand VerVentasCommand { get; set; }

        private UserControl _vistaActual;
        public UserControl VistaActual
        {
            get { return _vistaActual; }
            set
            {
                _vistaActual = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            VerProductosCommand = new RelayCommand(o => MostrarProductos());
            VerVentasCommand = new RelayCommand(o => MostrarVentas());

            // Mostrar la vista de productos por defecto
            MostrarProductos();
        }

        private void MostrarProductos()
        {
            VistaActual = new ProductosView(); // Instanciar la vista directamente
        }

        private void MostrarVentas()
        {
            VistaActual = new VentasView(); // Instanciar la vista directamente
        }
    }
}
