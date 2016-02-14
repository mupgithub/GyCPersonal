using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using GyCPersonal.Entidades;

namespace GyCPersonal.EFContext
{
    public class GyCPersonalDbContextInitializer : DropCreateDatabaseIfModelChanges<GyCPersonalDbContext>
    {
        protected override void Seed(GyCPersonalDbContext context)
        {
            var categorias = new List<Categoria>()
            {
                new Categoria(){nombre = "Lacteos"},
                new Categoria(){nombre = "Carnes"},
                new Categoria(){nombre = "Ropa"}
            };
            categorias.ForEach(c => context.Categorias.Add(c));
            context.SaveChanges();

            var productos = new List<Producto>()
            {
                new Producto(){descripcion = "Queso blanco para untar",ultimoPrecioCoste = 1m, categoria = categorias[0]},
                new Producto(){descripcion = "Leche entera",ultimoPrecioCoste = 0.57m, categoria = categorias[0]},
                new Producto(){descripcion = "Cuartos traseros de pollo",ultimoPrecioCoste = 1.29m, categoria = categorias[1]},
                new Producto(){descripcion = "Jeans Bershka",ultimoPrecioCoste = 12.99m, categoria = categorias[2]},
                new Producto(){descripcion = "Pullover",ultimoPrecioCoste = 5.99m, categoria = categorias[2]}
            };
            productos.ForEach(p => context.Productos.Add(p));
            context.SaveChanges();

            var proveedores = new List<Proveedor>(){
                new Proveedor(){nombre="Mercadona",direccion="Amos de Escalante, 14" },
                new Proveedor(){nombre="Ahorramas",direccion="Ciudad Lineal" }
            };
            proveedores.ForEach(p => context.Proveedores.Add(p));
            context.SaveChanges();

            var compras = new List<Compra>(){
                new Compra(){fechaCompra=new DateTime(2016,1,1), observaciones="Mi primera compra del año",proveedor=proveedores[0]}
            };
            compras.ForEach(c => context.Compras.Add(c));
            context.SaveChanges();

            var detCompras = new List<DetalleCompra>(){
                new DetalleCompra(){compra=compras[0], producto=productos[0], cantidad=1 },
                new DetalleCompra(){compra=compras[0], producto=productos[1], cantidad=6 },
                new DetalleCompra(){compra=compras[0], producto=productos[2], cantidad=5 }
            };
            detCompras.ForEach(d => context.DetallesCompras.Add(d));
            context.SaveChanges();

            base.Seed(context);
        }

    }
}
