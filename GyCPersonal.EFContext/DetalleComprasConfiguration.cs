using GyCPersonal.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyCPersonal.EFContext
{
    class DetalleComprasConfiguration: EntityTypeConfiguration<DetalleCompra>
    {
        public DetalleComprasConfiguration()
        {
            Property(d => d.cantidad).IsRequired();

            HasRequired(d => d.compra)
                .WithMany(c => c.DetalleCompra)
                .HasForeignKey(d => d.compraId)
                .WillCascadeOnDelete(false);

            HasRequired(d => d.producto);
        }
    }
}
