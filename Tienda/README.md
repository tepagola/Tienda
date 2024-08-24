# Tienda - Sistema de Inventario B�sico

Este es un sistema de inventario b�sico para una peque�a tienda, desarrollado en WPF (Windows Presentation Foundation) utilizando .NET. El sistema permite gestionar productos, consultar existencias y realizar ventas. Adem�s, maneja productos con diferentes categor�as y calcula el stock restante despu�s de cada venta.

## Caracter�sticas

- **CRUD de productos**: A�adir, editar y eliminar productos del inventario.
- **Registro de ventas**: Registrar ventas y actualizar autom�ticamente el inventario.
- **Reportes de inventario bajo**: Mostrar productos que est�n por debajo de un stock m�nimo.
- **Almacenamiento de datos**: Utiliza una base de datos SQLite para almacenar los datos.

## Tecnolog�as Utilizadas

- **WPF**: Para la interfaz gr�fica de usuario.
- **.NET**: El framework utilizado para desarrollar la aplicaci�n.
- **Entity Framework Core**: Para manejar la base de datos SQLite.
- **SQLite**: Base de datos ligera para almacenar la informaci�n de los productos y ventas.

## Requisitos

- **.NET SDK 6.0 o superior**: [Descargar .NET SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- **Visual Studio 2022**: O cualquier otro IDE compatible con WPF y .NET.

## Configuraci�n y Ejecuci�n

### Clonar el Repositorio

```bash
git clone https://github.com/tu_usuario/tu_repositorio.git
cd tu_repositorio
```

### Configurar la Base de Datos

El proyecto est� configurado para crear autom�ticamente la base de datos si no existe. No obstante, si deseas aplicar migraciones o actualizar la base de datos, puedes usar los siguientes comandos de Entity Framework Core:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### Ejecutar la Aplicaci�n

1. Abre el proyecto en Visual Studio 2022.
2. Selecciona la configuraci�n `Release` o `Debug`.
3. Presiona `F5` o haz clic en `Iniciar` para ejecutar la aplicaci�n.

## Uso

### Gesti�n de Productos

- **A�adir Producto**: Haz clic en "A�adir Producto" para abrir la ventana de creaci�n de un nuevo producto. Completa los campos y haz clic en "Aceptar".
- **Editar Producto**: Selecciona un producto de la lista y haz clic en "Editar Producto" para modificar sus detalles.
- **Borrar Producto**: Selecciona un producto de la lista y haz clic en "Borrar Producto" para eliminarlo.

### Registro de Ventas

- **Registrar Venta**: Navega a la secci�n de ventas y selecciona los productos que se vender�n. Completa los detalles de la venta y confirma para registrar la venta.

### Reportes de Inventario

- **Inventario Bajo**: La aplicaci�n muestra un reporte de productos que est�n por debajo de un stock m�nimo establecido.

## Licencia

Este proyecto est� licenciado bajo la licencia MIT - ver el archivo LICENSE para m�s detalles.