using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocielApp_Demo.Models
{
    public class PostLikers : BaseEntity
    {
        public Guid PostId { get; set; }
        public Posts Posts { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime PostLikersTime { get; set; }
    }
}