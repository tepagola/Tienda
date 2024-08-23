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
        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(); // Notifica a la vista que la propiedad ha cambiado
                ((RelayCommand)EditarProductoCommand).RaiseCanExecuteChanged(); // Actualiza la capacidad de ejecutar el comando
                ((RelayCommand)BorrarProductoCommand).RaiseCanExecuteChanged();
            }
        }

        public ICommand AgregarProductoCommand { get; set; }
        public ICommand EditarProductoCommand { get; set; }
        public ICommand BorrarProductoCommand { get; set; }

        public ProductosViewModel()
        {
            Products = new ObservableCollection<Product>();
            AgregarProductoCommand = new RelayCommand(AgregarProducto);
            EditarProductoCommand = new RelayCommand(EditarProducto, CanEditarProducto);
            BorrarProductoCommand = new RelayCommand(BorrarProducto, CanEditarProducto);

            // Cargar productos existentes desde la base de datos al iniciar
            CargarProductos();
        }

        private async Task CargarProductos()
        {
            using (var context = new InventarioContext())
            {
                var productosDesdeBD = await context.Products.ToListAsync();
                foreach (var producto in productosDesdeBD)
                {
                    this.Products.Add(producto);
                }
            }
        }

        private async void AgregarProducto(object obj)
        {
            // Este método ahora abre la ventana y utiliza ValidarProducto para validar antes de crear el producto
            var ventana = new AgregarProductoWindow();
            ventana.DataContext = new Product();

            if (ventana.ShowDialog() == true)
            {
                using (var context = new InventarioContext())
                {
                    // Añadir el producto a la base de datos
                    context.Products.Add(ventana.Product);
                    await context.SaveChangesAsync();  // Guardar los cambios en la base de datos

                    // Añadir el producto a la colección observable
                    this.Products.Add(ventana.Product);
                }
            }
        }

        private async void EditarProducto(object parameter)
        {
            if (SelectedProduct != null)
            {
                var ventana = new AgregarProductoWindow();
                ventana.DataContext = SelectedProduct;


                if (ventana.ShowDialog() == true)
                {
                    using (var context = new InventarioContext())
                    {
                        // Añadir el producto a la base de datos
                        context.Products.Update(ventana.Product);
                        await context.SaveChangesAsync();  // Guardar los cambios en la base de datos
                    }
                }
            }
        }

        private async void BorrarProducto(object parameter)
        {
            if (SelectedProduct != null)
            {
                using (var context = new InventarioContext())
                {
                    // Añadir el producto a la base de datos
                    context.Products.Remove(SelectedProduct);
                    await context.SaveChangesAsync();  // Guardar los cambios en la base de datos

                    this.Products.Remove(SelectedProduct);
                }
            }
        }

        private bool CanEditarProducto(object parameter)
        {
            return SelectedProduct != null; // Habilita el botón solo si hay un producto seleccionado
        }
    }
}
