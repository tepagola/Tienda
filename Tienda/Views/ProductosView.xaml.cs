using System.Windows.Controls;
using Tienda.ViewModels;

namespace Tienda.Views
{
    /// <summary>
    /// Lógica de interacción para ProductosView.xaml
    /// </summary>
    public partial class ProductosView : UserControl
    {
        public ProductosView()
        {
            InitializeComponent();

            DataContext = new ProductosViewModel();
        }
    }
}
