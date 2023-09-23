using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using evdekinisatcom.MvcWebApp.DataAccess.Data;
using evdekinisatcom.MvcWebApp_App.Entity.Interfaces;

namespace evdekinisatcom.MvcWebApp.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly AppDbContext _context;
        private DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbSet?.Remove(entity);
            _context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter = null)
        {
            return _dbSet.FirstOrDefault(filter);
        }

        public List<T> GetAll()
        {
            return (_dbSet.ToList());
        }

        public T GetById(int id)
        {
            return (_dbSet.Find(id));
        }

        public T GetByName(string name)
        {
            return (_dbSet.Find(name));
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public T GetByCategoryId(int categoryId)
        {
            return (_dbSet.Find(categoryId));
        }
    }
}
