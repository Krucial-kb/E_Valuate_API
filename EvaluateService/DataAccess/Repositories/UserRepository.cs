using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using E_ValuateDataAccess.DataModels;
using E_ValuateDataAccess.Logic;
using E_valuateDomain.DomainModels;
using E_valuateDomain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_ValuateDataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EvalContext _ctx;

        public UserRepository(EvalContext context)
        {
            _ctx = context;
        }

        public void Add(E_valuateDomain.DomainModels.Users entity)
        {
            var mappedAddress = Mapper.MapAddress(entity);
            _ctx.Set<DataModels.Address>().Add(mappedAddress);
            _ctx.SaveChanges();
            _ctx.Entry(mappedAddress).Reload();
            var mappedEntity = Mapper.MapUsers(entity);
            mappedEntity.Address = mappedAddress.AddressId;
            _ctx.Set<DataModels.Users>().Add(mappedEntity);
        }

        public void AddRange(IEnumerable<E_valuateDomain.DomainModels.Users> entities)
        {
            foreach(var entity in entities)
            {
                Add(entity);
            }
        }

        public bool Any(Expression<Func<E_valuateDomain.DomainModels.Users, bool>> predicate)
        {
            var entity = FindAsync(predicate);
            if (entity == null)
            {
                return false;
            }
            else
                return true;
        }

        public IEnumerable<E_valuateDomain.DomainModels.Users> FindAsync(Expression<Func<E_valuateDomain.DomainModels.Users, bool>> predicate)
        {
            return _ctx.Set<E_valuateDomain.DomainModels.Users>().Where(predicate);
        }

        public async Task<E_valuateDomain.DomainModels.Users> FindAsync(int id)
        {
            var data = await _ctx.Set<DataModels.Users>().FindAsync(id);

            return Mapper.MapUsers(data);
        }

        public async Task<E_valuateDomain.DomainModels.Users> FindAsyncAsNoTracking(int id)
        {
            var data = await _ctx.Set<DataModels.Users>().AsNoTracking().Where(a => a.UserId == id).FirstOrDefaultAsync();

            return Mapper.MapUsers(data);
        }

        public E_valuateDomain.DomainModels.Users FindbyEmail(string email)
        {
            var cust = _ctx.Users.Where(u => u.Email == email).Include("AddressNavigation");
            return Mapper.MapUsers(cust.First());
        }

        public async Task<IEnumerable<E_valuateDomain.DomainModels.Users>> GetAll()
        {
            var entities = await _ctx.Set<DataModels.Users>().ToListAsync();
            var mappedEntities = new List<E_valuateDomain.DomainModels.Users>();
            foreach (var entity in entities)
            {
                mappedEntities.Add(Mapper.MapUsers(entity));
            }
            return mappedEntities;
        }

        public async Task<E_valuateDomain.DomainModels.Users> GetAsync(int id)
        {
            var entity = await _ctx.Set<DataModels.Users>().FindAsync(id); //return single object of class

            return Mapper.MapUsers(entity);
        }

        public int HighestID()
        {
            return _ctx.Users.OrderByDescending(e => e.UserId).FirstOrDefault().UserId;
        }

        public async Task<bool> ModifyStateAsync(E_valuateDomain.DomainModels.Users user, int id)
        {
            var mappedUser = Mapper.MapUsers(user);
            /*_context.Entry(customer).State = EntityState.Modified;*/
            _ctx.Entry(mappedUser).State = EntityState.Modified;

            try
            {
                await SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return false;
                    // customer not found
                }
                else
                {
                    throw;
                }
            }
            return true;
            // it worked, so return true
        }

        private bool UserExists(int id)
        {
            return Any(u => u.UserID == id);
        }

        public void Remove(E_valuateDomain.DomainModels.Users entity)
        {
            var mappedEntity = Mapper.MapUsers(entity);
            _ctx.Set<DataModels.Users>().Remove(mappedEntity);
        }

        public void RemoveRange(IEnumerable<E_valuateDomain.DomainModels.Users> entities)
        {
            foreach (var entity in entities)
            {
                Remove(entity);
            }
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<E_valuateDomain.DomainModels.Users>> ToListAsync()
        {
            return await GetAll();
        }
    }
}
