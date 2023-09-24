using Capital_Placement_Task.Models;
using Capital_Placement_Task.Repositroy.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace Capital_Placement_Task.Repositroy
{
    public class BaseRepositry<T> : IBaseRepository<T> where T : class
    {
        private ApplicationDbContext _context;
        public BaseRepositry(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var model = GetById(id);
            if (model != null)
            {
                _context.Set<T>().Remove(model);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Update(int id,T entity)
        {
            var model = GetById(id);
            if (model == null)
            {
                return null;
            }
            _context.Entry(model).State = EntityState.Detached;
            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
