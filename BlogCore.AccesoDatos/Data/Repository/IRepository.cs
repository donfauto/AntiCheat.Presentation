using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        //-----OBTENER UN REGISTRO.
        T Get(int id);

        //-----OBTENER TODOS LOS REGISTROS (COMPLETOS O FILTRADOS).
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>>filter =null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null
            );

        //-----OBTENER EL PRIMER REGISTRO O EL POR DEFECTO QUE ENCUENTRE.
        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null
            );

        //-----PARA AGREGAR.
        void Add(T entity);

        //-----PARA REMOVER POR IDENTIFICADOR UNICO.
        void Remove(int id);

        //-----PARA REMOVER PASANDOLE TODA LA ENTIDAD.
        void Remove(T entity);


    }
}
