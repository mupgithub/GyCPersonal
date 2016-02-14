using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GyCPersonal.Entidades;

namespace GyCPersonal.EFContext
{
    public class GyCPersonalDbContext: DbContext
    {
        public GyCPersonalDbContext()
            : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Producto> Productos { get;set;}
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<DetalleCompra> DetallesCompras { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
                       
            modelBuilder.Configurations.Add(new ProductoConfiguration());
            modelBuilder.Configurations.Add(new ProveedorConfiguration());
            modelBuilder.Configurations.Add(new CategoriaConfiguration());
            modelBuilder.Configurations.Add(new CompraConfiguration());
            modelBuilder.Configurations.Add(new DetalleComprasConfiguration());
           
            modelBuilder.Entity<Producto>().ToTable("Productos");
            modelBuilder.Entity<Proveedor>().ToTable("Proveedores");

            base.OnModelCreating(modelBuilder);
        }

    }
}
