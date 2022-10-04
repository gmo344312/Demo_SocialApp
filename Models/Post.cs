using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocielApp_Demo.Models
{
    public class Post : BaseEntity
    {
        public String Content { get; set; }
        public String Title { get; set; }
        public User Author { get; set; }
        public Guid AuthorId { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }

        public ICollection<Comment> Comment { get; set; }
        public ICollection<User> Likers { get; set; }

    }
}