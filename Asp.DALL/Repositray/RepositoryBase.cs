using Asp.DALL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Asp.DALL.Repositray
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        protected ProjectContext _db;
        protected DbSet<T> _dbSet;
        public RepositoryBase() : this(new ProjectContext()) { }
        public RepositoryBase(ProjectContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }
        public DbContext db
        {
            get { return _db; }
        }

        public async Task<T> GetOne(Expression<Func<T, bool>>? filter = null, List<string>? includes = null)
        {
            try
            {
                if (filter != null)
                    return await _db.Set<T>().AsNoTracking().WithIncludes(includes).FirstOrDefaultAsync(filter);
                else
                    return await _db.Set<T>().AsNoTracking().WithIncludes(includes).FirstOrDefaultAsync();

            }
            catch (Exception)
            {
                return null;
            }

        }
        public async Task<List<T>> GetList(Expression<Func<T, bool>> filter = null, List<string>? includes = null
            , List<string>? OrderBy = null)
        {
            try
            {
                if (filter != null)
                    return await _db.Set<T>().AsNoTracking().WithIncludes(includes).Where(filter).WithOrderBy(OrderBy).ToListAsync();
                else
                    return await _db.Set<T>().AsNoTracking().WithIncludes(includes).WithOrderBy(OrderBy).ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<bool> Add(T entity)
        {
            try
            {
                await _db.AddAsync(entity);
                if (await _db.SaveChangesAsync() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> AddRange(List<T> entity)
        {
            try
            {
                await _db.AddRangeAsync(entity);
                if (await _db.SaveChangesAsync() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public async Task<bool> Delete(T entity)
        {
            try
            {
                _db.Remove(entity);
                if (await _db.SaveChangesAsync() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> DeleteRange(List<T> entity)
        {
            try
            {
                _db.RemoveRange(entity);
                if (await _db.SaveChangesAsync() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> Update(T entity)
        {
            try
            {
                _db.Update(entity);
                if (await _db.SaveChangesAsync() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public async Task<bool> UpdateRange(List<T> entities)
        {
            try
            {
                _db.UpdateRange(entities);
                if (await _db.SaveChangesAsync() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Exception(Exception ex, string controllerName, string funName)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCount()
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckActionPrivilege(string ControllerName, string ActionName, List<int> Privs)
        {
            throw new NotImplementedException();
        }
    }
    public static class LinqExtensions
    {
        public static IQueryable<T> WithIncludes<T>(this IQueryable<T> source, List<string> associations) where T : class
        {
            var query = (IQueryable<T>)source;
            if (associations != null)
                foreach (var assoc in associations)
                {
                    query = query.Include(assoc);
                }
            return query;
        }
        public static IQueryable<T> WithOrderBy<T>(this IQueryable<T> source, List<string> orderBy) where T : class
        {
            var query = (IQueryable<T>)source;
            if (orderBy != null)
                foreach (var order in orderBy)
                {
                    query = query.OrderByDescending(z => order);
                }
            return query;
        }
    }
}
