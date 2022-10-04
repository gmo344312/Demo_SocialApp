using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Demo_SocialApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserController _userServices;
        public UserController(UserService userService){
            _userService= userService;
        }
    }

    [HttpGet]
    public async Task<IActrionResult> getUserList(){
        var users = await _userServices
    }
}