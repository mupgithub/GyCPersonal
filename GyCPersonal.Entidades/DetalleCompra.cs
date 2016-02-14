using System.ComponentModel.DataAnnotations;
namespace GyCPersonal.Entidades
{
    public class DetalleCompra
    {
        public int id { get; set; }
        public int compraId { get; set; }
        public int productoId { get; set; }

        [Display(Name = "Cantidad")]
        public int cantidad { get; set; }

        //Propiedades de navegación.
        public virtual Compra compra { get; set; }
        public virtual  Producto producto { get; set; }

    }
}