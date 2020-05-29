using E_valuateDomain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_valuateDomain.Interfaces
{
    public interface IUserRepository
    {
        void Add(Users entity);
        void AddRange(IEnumerable<Users> entities);
        bool Any(Expression<Func<Users, bool>> predicate);
        IEnumerable<Users> FindAsync(Expression<Func<Users, bool>> predicate);
        Users FindbyEmail(string email);
        Task<Users> FindAsync(int id);
        Task<Users> FindAsyncAsNoTracking(int id);
        Task<IEnumerable<Users>> GetAll();
        Task<Users> GetAsync(int id);
        Task<bool> ModifyStateAsync(Users address, int id);
        void Remove(Users entity);
        void RemoveRange(IEnumerable<Users> entities);
        void Save();
        Task<int> SaveChangesAsync();
        Task<IEnumerable<Users>> ToListAsync();
        int HighestID();
    }
}
