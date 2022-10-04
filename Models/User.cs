using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocielApp_Demo.Models
{
    public class User : BaseEntity
    {
        public String DisplayName { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public String Address { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ICollection<Posts> UserPost { get; set; }
        public ICollection<PostLikers> PostLikers { get; set; }
    }
}