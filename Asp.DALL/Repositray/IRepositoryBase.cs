using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Asp.DALL.Repositray
{
    public interface IRepositoryBase<T> where T : class
    {
        DbContext db { get; }
        Task<T> GetOne(Expression<Func<T, bool>>? filter = null, List<string>? includes = null);
        Task<List<T>> GetList(Expression<Func<T, bool>>? filter = null, List<string>? includes = null, List<string>? OrderBy = null);
        Task<bool> Add(T entity);
        Task<bool> AddRange(List<T> entity);
        Task<bool> Update(T entity);
        Task<bool> UpdateRange(List<T> entity);
        Task<bool> Delete(T entity);
        Task<bool> DeleteRange(List<T> entity);
        void Exception(Exception ex, string controllerName, string funName);
        Task<int> GetCount();
        Task<bool> CheckActionPrivilege(string ControllerName, string ActionName, List<int> Privs);
    }
}
