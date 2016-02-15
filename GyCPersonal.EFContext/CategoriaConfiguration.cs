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
    class CategoriaConfiguration: EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfiguration()
        {
            //Property(c => c.id).HasColumnName("CategoryId");

            Property(c => c.nombre)
                .HasMaxLength(30)
                .IsRequired()
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute("AK_Categoria_Nombre") {IsUnique = true}));
            
        }
    }
}
