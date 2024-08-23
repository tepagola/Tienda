using System.Windows;
using Tienda.Models;
using Tienda.ViewModels;

namespace Tienda.Views
{
    /// <summary>
    /// Lógica de interacción para AgregarProductoWindow.xaml
    /// </summary>
    public partial class AgregarProductoWindow : Window
    {
        internal Product Product { get; private set; }

        internal AgregarProductoWindow()
        {
            InitializeComponent();
        }

        private void AceptarButton_Click(object sender, RoutedEventArgs e)
        {
            // Aquí estamos confiando en la vinculación de datos para obtener los valores
            var viewModel = DataContext as ProductosViewModel;

            // Validar los datos a través del ViewModel
            if (viewModel != null && viewModel.ValidarProducto())
            {
                // Crear el producto con los datos del ViewModel
                Product = new Product
                {
                    Name = viewModel.Nombre,
                    Category = viewModel.Categoria,
                    Price = viewModel.Precio,
                    Stock = viewModel.Stock
                };

                DialogResult = true;  // Esto cerrará la ventana modal y devolverá true
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos correctamente.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
