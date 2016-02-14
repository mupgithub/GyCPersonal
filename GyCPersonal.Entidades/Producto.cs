using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyCPersonal.Entidades
{
    public class Producto
    {
        public int id { get; set; }

        [Display(Name = "Producto")]
        public string descripcion { get; set; }

        [Display(Name = "Ultimo Precio de Costo")]
        public decimal ultimoPrecioCoste { get; set; }
        public int categoriaId { get; set; }

        //Propiedades de navegación.
        public virtual Categoria categoria { get; set; }

    }
}
