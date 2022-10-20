using DataAccessLayer.Contract;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class RepositoryAppUser : IRepository<AppUser>
    {
        private readonly ILogger _logger; 
        private readonly AppDbContext _appDbContext; 
        
        public RepositoryAppUser(ILogger<AppUser> logger)
        {
            _logger = logger;
        }
        public async Task<AppUser> Create(AppUser appUser)
        {
            try
            {
                if(appUser != null)
                {
                    var obj = _appDbContext.Add<AppUser>(appUser);
                    await _appDbContext.SaveChangesAsync();
                    return obj.Entity; 
                }else
                {
                    return null; 
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Delete(AppUser appuser)
        {
            try
            {
                if(appuser != null)
                {
                    var obj = _appDbContext.Remove(appuser); 
                    if(obj != null)
                    {
                        _appDbContext.SaveChangesAsync(); 
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Update(AppUser appUser)
        {
            try
            {
                if(appUser != null)
                {
                    var obj = _appDbContext.Update(appUser); 
                    if( obj != null) _appDbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<AppUser> GetAll()
        {
            try
            {
                var obj = _appDbContext.appUsers.ToList();
                if (obj != null) return obj;
                else return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public AppUser GetById(int Id)
        {
            try
            {
                if (Id != null)
                {
                    var Obj = _appDbContext.appUsers.FirstOrDefault(x => x.Id == Id);
                    if (Obj != null) return Obj;
                    else return null;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
