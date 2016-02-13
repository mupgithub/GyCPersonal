using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GyCPersonal.Entidades
{
    public class Categoria
    {
        public Categoria()
        {
            Productos = new List<Producto>();
        }

        public int id { get; set; }

        [Display(Name="Categoría")]
        public string nombre { get; set; }

        //Propiedades de navegación.
        public virtual ICollection<Producto> Productos { get; set; }

    }
}