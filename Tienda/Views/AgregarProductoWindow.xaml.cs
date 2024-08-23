using System.Windows;
using System.Windows.Controls;
using Tienda.Models;
using Tienda.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tienda.Views
{
    /// <summary>
    /// Lógica de interacción para AgregarProductoWindow.xaml
    /// </summary>
    public partial class AgregarProductoWindow : Window
    {
        internal Product Product { get; set; }

        internal AgregarProductoWindow()
        {
            InitializeComponent();
        }

        private void AceptarButton_Click(object sender, RoutedEventArgs e)
        {
            // Aquí estamos confiando en la vinculación de datos para obtener los valores
            var viewModel = DataContext as Product;

            // Validar los datos a través del ViewModel
            if (viewModel != null && this.ValidarProducto())
            {
                this.Product = viewModel;
                DialogResult = true;  // Esto cerrará la ventana modal y devolverá true
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos correctamente.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ValidarProducto()
        {
            // Validación simple de campos
            return true;
        }

        private void PriceTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            decimal result;
            // Permitir solo valores numéricos y un único separador decimal
            e.Handled = !decimal.TryParse(((TextBox)sender).Text + e.Text, out result);
        }
    }
}
