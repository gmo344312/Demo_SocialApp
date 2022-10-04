using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_SocialApp.Services
{
    public class UserServices
    {
        private readonly AppDbContext _context;
        public UserServices(AppDbContext appDbContext){
            _context= appDbContext;
        }

        public async Task AddUser(User user){
            try{
            await _context.user.AddAsync();
            return user;
            }
            catch(Exception e){
                return false;
            }
        }

        public async Task UpdateUser(User user){
            try{
                var userExist = await _context.user.FindAsynx();
            await _context.user.AddAsync();
            return user;
            }
            catch(Exception e){
                return false;
            }
        }

    }
}