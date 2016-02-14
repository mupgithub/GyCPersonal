using GyCPersonal.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyCPersonal.EFContext
{
    class ProductoConfiguration: EntityTypeConfiguration<Producto>
    {
        public ProductoConfiguration()
        {
           Property(p => p.codProducto)
               .HasMaxLength(20)
               .IsRequired()
               .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("AK_Producto_CodigoProducto") {IsUnique = true}));
           
            Property(p => p.descripcion)
              .HasMaxLength(80)
              .IsRequired()
              .HasColumnAnnotation("Index",
                   new IndexAnnotation(new IndexAttribute("AK_Producto_Descripcion") { IsUnique = true }));

            HasRequired(p => p.categoria)
                .WithMany(c => c.Productos )
                .HasForeignKey(p => p.categoriaId)
                .WillCascadeOnDelete(false);
        }
       
    }
}
