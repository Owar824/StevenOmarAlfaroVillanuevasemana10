using StevenOmarAlfaroVillanuevaSemana8.DAO;
using StevenOmarAlfaroVillanuevaSemana8.Models;

CRUDProducto crud = new CRUDProducto();
Producto producto = new Producto();
bool Continuar = true;
while (Continuar) { 
Console.WriteLine("Menú");
Console.WriteLine("Pulse 1 para insertar Producto");
Console.WriteLine("Pulse 2 para  actualizar Producto");
Console.WriteLine("Pulse 3 para  eliminar Producto");
Console.WriteLine("Pulse 4 para  mostrar la lista de Productos");

    var Menu = Convert.ToInt32(Console.ReadLine());

    switch (Menu)
    {
        case 1:
            int bucle = 1;
            while (bucle == 1)
            {
                Console.WriteLine("Ingresa el nombre de tu Producto: ");
                producto.Nombre = Console.ReadLine();
                Console.WriteLine("Ingresa la descripcion de tu producto: ");
                producto.Descripcion = Console.ReadLine();
                Console.WriteLine("Ingresa el precio de tu producto: ");
                producto.Precio = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Ingresa la cantidad de producto disponible: ");
                producto.Stock = Convert.ToInt32(Console.ReadLine());
                crud.AgregarProducto(producto);
                Console.WriteLine("El producto se ingreso corectamente");
                Console.WriteLine("pulse 1 para continuar agregando productos");
                Console.WriteLine("Pulsa 0 para salir");
                bucle = Convert.ToInt32(Console.ReadLine());
            }
            break;
        case 2:
            Console.WriteLine("Actualizar datos");
            Console.WriteLine("Ingresa el id del producto que deseas actualizar");
            var ProductooIndividualUpdate = crud.ProductoIndividual(Convert.ToInt32(Console.ReadLine()));

            if (ProductooIndividualUpdate == null)
            {
                Console.WriteLine("El id no existe");
            }
            else
            {
                Console.WriteLine($"Nombre del Producto {ProductooIndividualUpdate.Nombre} \n  Precio: {ProductooIndividualUpdate.Precio}");

                Console.WriteLine("Para actualizar el nombre presiona #1");
                Console.WriteLine("Para actualizar el nombre presiona #2");

                var Lector = Convert.ToInt32(Console.ReadLine());

                if (Lector == 1)
                {
                    Console.WriteLine("Ingresa el nuevo nombre del producto: ");
                    ProductooIndividualUpdate.Nombre = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Ingresa el nuevo precio del producto: ");
                    ProductooIndividualUpdate.Precio = decimal.Parse(Console.ReadLine());


                }
                crud.ActualizarProducto(ProductooIndividualUpdate, Lector);
                Console.WriteLine("El producto se actualizo corectamente");
            }
            break;
        case 3:
            Console.WriteLine("Ingresa el id del usuario a eliminar:");
            var delete = crud.ProductoIndividual(Convert.ToInt32(Console.ReadLine()));

            if (delete == null)
            {
                Console.WriteLine("Este usuario  no existe");
            }
            else
            {
                Console.WriteLine("Eliminar Producto");
                Console.WriteLine($"El producto : {delete.Nombre}  Con un precio de: {delete.Precio}");
                Console.WriteLine("¿El producto es el correto?");
                var Lector = Convert.ToInt32(Console.ReadLine());
                if (Lector == 1)
                {
                    var Id = Convert.ToInt32(delete.Id);
                    Console.WriteLine(crud.EliminarProducto(Id));
                }
                else
                {
                    Console.WriteLine("Intenta nuevamente");
                }

            }
            break;

        case 4:
            Console.WriteLine("Lista de productos");
            var ListarProductos = crud.ListarProductos();
            foreach (var ListadeProductos in ListarProductos)
            {
                Console.WriteLine($"{ListadeProductos.Id} {ListadeProductos.Nombre} {ListadeProductos.Precio}");
            }
            break;
    }
    Console.WriteLine("¿Desea Seguir haciendo operaciones?");
    string cont = Console.ReadLine();
    if (cont.Equals("N")) 
    {
        Continuar = false;
    }
}