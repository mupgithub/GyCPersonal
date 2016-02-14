using GyCPersonal.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyCPersonal.EFContext
{
    class CompraConfiguration: EntityTypeConfiguration<Compra>
    {
        public CompraConfiguration()
        {
            Property(c => c.fechaCompra).IsRequired();
            Property(c => c.observaciones).HasMaxLength(100).IsOptional();

            HasRequired(c => c.proveedor)
                .WithMany(p => p.Compras)
                .HasForeignKey(c => c.proveedorId)
                .WillCascadeOnDelete(false);

            HasRequired(c => c.DetalleCompra);
        }
    }
}
