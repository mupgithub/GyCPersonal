using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyCPersonal.Entidades
{
    public class Compra
    {
        public Compra()
        {
            DetalleCompra = new List<DetalleCompra>();
        }
        public int id { get; set; }
        public string observaciones { get; set; }

        public int proveedorId { get; set; }

        [Display(Name = "Fecha de Compra")]
        public DateTime fechaCompra { get; set; }

        //Propiedades de navegación.
        public virtual Proveedor proveedor { get; set; }
        public virtual ICollection<DetalleCompra> DetalleCompra { get; set; }
    }
}
