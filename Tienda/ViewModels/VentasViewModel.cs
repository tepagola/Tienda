using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tienda.Models;

namespace Tienda.ViewModels
{
    internal class VentasViewModel : BaseViewModel
    {
        public ObservableCollection<Sale> Ventas { get; set; }

        public ICommand AgregarVentaCommand { get; set; }

        public VentasViewModel()
        {
            // Lógica para manejar las ventas
        }
    }
}
