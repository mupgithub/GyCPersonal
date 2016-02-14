using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GyCPersonal.Entidades
{
    public class Proveedor
    {
        public Proveedor()
        {
            Compras = new List<Compra>();
        }
        public int id { get; set; }

        [Display(Name = "Proveedor")]
        public string nombre { get; set; }

        [Display(Name = "Dirección")]
        public string direccion { get; set; }

        [Display(Name = "Teléfono")]
        public string telefono { get; set; }

        //Propiedades de navegación.
        public virtual ICollection<Compra> Compras { get; set; }
    }
}