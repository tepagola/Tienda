using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Tienda.Commands;
using Tienda.Data;
using Tienda.Models;
using Tienda.Views;

namespace Tienda.ViewModels
{
    internal class ProductosViewModel :BaseViewModel
    {
        public ObservableCollection<Product> Products { get; set; }

        public ICommand AgregarProductoCommand { get; set; }
        public ICommand EditarProductoCommand { get; set; }
        public ICommand BorrarProductoCommand { get; set; }

        // Propiedades para enlazar los campos del formulario
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public ProductosViewModel()
        {
            Products = new ObservableCollection<Product>();
            AgregarProductoCommand = new RelayCommand(AgregarProducto);

            // Cargar productos existentes desde la base de datos al iniciar
            _ = CargarProductos();
        }

        private async Task CargarProductos()
        {
            using (var context = new InventarioContext())
            {
                await context.Database.EnsureCreatedAsync();

                var productosDesdeBD = await context.Products.ToListAsync();
                foreach (var producto in productosDesdeBD)
                {
                    this.Products.Add(producto);
                }
            }
        }

        public bool ValidarProducto()
        {
            // Validación simple de campos
            return !string.IsNullOrEmpty(Nombre) &&
                   !string.IsNullOrEmpty(Categoria) &&
                   Precio > 0 &&
                   Stock >= 0;
        }

        private async void AgregarProducto(object obj)
        {
            // Este método ahora abre la ventana y utiliza ValidarProducto para validar antes de crear el producto
            var ventana = new AgregarProductoWindow();
            ventana.DataContext = this;

            if (ventana.ShowDialog() == true)
            {
                using (var context = new InventarioContext())
                {
                    // Añadir el producto a la base de datos
                    context.Products.Add(ventana.Product);
                    context.SaveChanges();  // Guardar los cambios en la base de datos

                    // Añadir el producto a la colección observable
                    this.Products.Add(ventana.Product);
                }
            }
        }
    }
}
