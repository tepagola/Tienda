# Tienda - Sistema de Inventario Básico

Este es un sistema de inventario básico para una pequeña tienda, desarrollado en WPF (Windows Presentation Foundation) utilizando .NET. El sistema permite gestionar productos, consultar existencias y realizar ventas. Además, maneja productos con diferentes categorías y calcula el stock restante después de cada venta.

## Características

- **CRUD de productos**: Añadir, editar y eliminar productos del inventario.
- **Registro de ventas**: Registrar ventas y actualizar automáticamente el inventario.
- **Reportes de inventario bajo**: Mostrar productos que están por debajo de un stock mínimo.
- **Almacenamiento de datos**: Utiliza una base de datos SQLite para almacenar los datos.

## Tecnologías Utilizadas

- **WPF**: Para la interfaz gráfica de usuario.
- **.NET**: El framework utilizado para desarrollar la aplicación.
- **Entity Framework Core**: Para manejar la base de datos SQLite.
- **SQLite**: Base de datos ligera para almacenar la información de los productos y ventas.

## Requisitos

- **.NET SDK 6.0 o superior**: [Descargar .NET SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- **Visual Studio 2022**: O cualquier otro IDE compatible con WPF y .NET.

## Configuración y Ejecución

### Clonar el Repositorio

```bash
git clone https://github.com/tu_usuario/tu_repositorio.git
cd tu_repositorio
```

### Configurar la Base de Datos

El proyecto está configurado para crear automáticamente la base de datos si no existe. No obstante, si deseas aplicar migraciones o actualizar la base de datos, puedes usar los siguientes comandos de Entity Framework Core:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### Ejecutar la Aplicación

1. Abre el proyecto en Visual Studio 2022.
2. Selecciona la configuración `Release` o `Debug`.
3. Presiona `F5` o haz clic en `Iniciar` para ejecutar la aplicación.

## Uso

### Gestión de Productos

- **Añadir Producto**: Haz clic en "Añadir Producto" para abrir la ventana de creación de un nuevo producto. Completa los campos y haz clic en "Aceptar".
- **Editar Producto**: Selecciona un producto de la lista y haz clic en "Editar Producto" para modificar sus detalles.
- **Borrar Producto**: Selecciona un producto de la lista y haz clic en "Borrar Producto" para eliminarlo.

### Registro de Ventas

- **Registrar Venta**: Navega a la sección de ventas y selecciona los productos que se venderán. Completa los detalles de la venta y confirma para registrar la venta.

### Reportes de Inventario

- **Inventario Bajo**: La aplicación muestra un reporte de productos que están por debajo de un stock mínimo establecido.

## Licencia

Este proyecto está licenciado bajo la licencia MIT - ver el archivo LICENSE para más detalles.