using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace evdekinisatcom.MvcWebApp_App.Entity.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {
        List<T> GetAll();

        T Get(Expression<Func<T, bool>> filter = null);

        T GetById(int id);

        T GetByName(string name);

        void Delete(T entity);

        void Update(T entity);

        void Add(T entity);

        T GetByCategoryId(int categoryId);


    }
}
