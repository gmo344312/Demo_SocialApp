using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocielApp_Demo.Models
{
    public class Group : BaseEntity
    {
        public String GroupName { get; set; }
        public String Description { get; set; }
        public String Rules { get; set; }

        public ICollection<UserGroup> UserinGroups { get; set; }
        public ICollection<Post> Post { get; set; }

    }
}