using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocielApp_Demo.Models
{
    public class UserGroup : BaseEntity
    {
        public Guid GroupId { get; set; }
        public Group Group { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}