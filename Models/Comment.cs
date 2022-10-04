using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocielApp_Demo.Models
{
    public class Comment : BaseEntity
    {
        public String Content { get; set; }
        public Guid AuthorId { get; set; }
        public User Author { get; set; }
        public Guid PostId { get; set; }
        public Post Post { get; set; }
    }
}