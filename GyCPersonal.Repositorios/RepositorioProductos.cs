using GyCPersonal.Entidades;
using System.Data.Entity;

namespace GyCPersonal.Repositorios
{
    public class RepositorioProductos: Repositorio<Producto>        
    {
        public RepositorioProductos(DbContext db)
            :base(db)
        {

        }
    }
}
