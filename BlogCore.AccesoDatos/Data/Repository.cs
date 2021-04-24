using BlogCore.AccesoDatos.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        internal DbSet<T> dbSet;
        public Repository(DbContext context)
        {
            Context = context;
            this.dbSet = context.Set<T>();
        }

        //-----PARA AGREGAR.
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        //-----OBTENER UN REGISTRO.
        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        //-----OBTENER TODOS LOS REGISTROS (COMPLETOS O FILTRADOS).
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            //include properties separada por comas.
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
        }

        //-----OBTENER EL PRIMER REGISTRO O EL POR DEFECTO QUE ENCUENTRE.
        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            //include properties separada por comas.
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.FirstOrDefault();
        }


        //-----PARA REMOVER POR IDENTIFICADOR UNICO.
        public void Remove(int id)
        {
            T entityToRemove = dbSet.Find(id);
            Remove(entityToRemove);
        }

        //-----PARA REMOVER PASANDOLE TODA LA ENTIDAD.
        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        
    }
}
