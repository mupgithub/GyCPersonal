using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyCPersonal.Repositorios
{
    public interface IRepositorioBase<T>
    {
        void Adicionar(T entidad);
        void Eliminar(T entidad);
        void Actualizar(int entidadId, T entidad);
        IQueryable<T> ObtenerTodos();
        T ObtenerPorId(int entidadId);
        void Guardar();

    }
}
