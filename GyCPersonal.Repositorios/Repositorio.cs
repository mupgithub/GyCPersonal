using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyCPersonal.Repositorios
{
    public abstract class Repositorio<T>:IRepositorioBase<T> where T: class
    {
        private DbContext _db;
        private DbSet<T> _dbSet;
        public Repositorio(DbContext db)
        {
            _db = db;
            _dbSet = db.Set<T>();
        }
        
        public void Adicionar(T entidad)
        {
            _dbSet.Add(entidad);
            
        }

        public void Eliminar(T entidad)
        {

            _dbSet.Remove(entidad);
        }

        public void Actualizar(int entidadId, T entidad)
        {
            _db.Entry<T>(entidad).State = EntityState.Modified;
            //_db.Entry<T>(entidad) = entidad;
        }   

        public IQueryable<T> ObtenerTodos()
        {
            return _dbSet;
        }

        public T ObtenerPorId(int entidadId)
        {
            return _dbSet.Find(entidadId);
        }

        public void Guardar()
        {
            _db.SaveChanges();
        }
    }
}
