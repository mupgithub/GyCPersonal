namespace GyCPersonal.EFContext.Migrations
{
    using GyCPersonal.Entidades;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GyCPersonal.EFContext.GyCPersonalDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GyCPersonal.EFContext.GyCPersonalDbContext context)
        {
            context.Categorias.AddOrUpdate(c => c.nombre,
                new Categoria { nombre = "Alimentos" },
                new Categoria { nombre="Ropa"});
            context.Productos.AddOrUpdate(
                new Producto { codProducto = "LECHEERIA", descripcion = "Leche Entera Eria 1L", ultimoPrecioCoste = (decimal)0.58, categoriaId = 1 },
                new Producto { codProducto = "QHUNTAR", descripcion = "Queso Blanco para huntar", ultimoPrecioCoste = (decimal)1, categoriaId = 1 },
                new Producto { codProducto = "PIZZAQUESO", descripcion = "Pizza de Queso y Tomate", ultimoPrecioCoste = (decimal)1.8, categoriaId = 1 });
            context.Proveedores.AddOrUpdate(
                new Proveedor {nombre="Mercadona",direccion="Amos de Escalante"},
                new Proveedor { nombre = "AhorraMas", direccion = "Hermanos García Nobleja" });
            context.SaveChanges();
        }
    }
}
