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

        [Display(Name = "Codigo")]
        public string codProducto { get; set; }

        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }

        [Display(Name = "Ultimo Precio de Costo")]
        public decimal ultimoPrecioCoste { get; set; }
        public int categoriaId { get; set; }

        //Propiedades de navegación.
        public virtual Categoria categoria { get; set; }

    }
}
