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
    class ProveedorConfiguration: EntityTypeConfiguration<Proveedor>
    {
        public ProveedorConfiguration()
        {
            Property(p => p.nombre)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnAnnotation("index", new IndexAnnotation(new IndexAttribute("AK_Proveedor_Nombre") { IsUnique = true }));

            Property(p => p.direccion).HasMaxLength(100).IsOptional();
            Property(p => p.telefono).HasMaxLength(12).IsOptional();
    
        }
    }
}
