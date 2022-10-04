using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocielApp_Demo.Data;
using SocielApp_Demo.Models;

namespace Demo_SocialApp.Services
{
    public class UserServices
    {
        private readonly AppDbContext _context;
        public UserServices(AppDbContext appDbContext){
            _context= appDbContext;
        }

        public async Task<bool?> AddUser(User user){
            try{
            var userExist= await _context.user.FirstOrDefaultAsync(u => u.Email== user.Email);
                if(userExist==null){
            await _context.user.AddAsync();
            await _context.user.SaveChangesAsync();
            return true;
            } 
                        throw new Exception("Email Da ton tai");
                }
            catch(Exception e){
                return false;
            }
        }

        public async Task UpdateUser(User user, String Id){
                var userExist = FinUserById(Id);
                if(userExist=null){
                    return false;
                }
                userExist.DisplayName=user.DisplayName;
                userExist.Email=user.Email;
                userExist.Address=user.Address;
                userExist.DateOfBirth=user.DateOfBirth;
                await _context.user.SaveChangesAsync();
                return true;
        }

        public async Task<bool?> DeleteUser(User user, String Id){
         var userExist = FinUserById(Id);
            if(userExist=null){
                return false;
            }
            _context.user.Remove(userExist);
            await _context.user.SaveChangesAsync();
                return true;
        }

        public async Task<User> FinUserById(Guid Id){
            return await _context.user.FirstOrDefault(u => u.Id=Id);
        }



    }
}