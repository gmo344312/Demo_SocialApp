using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_SocialApp.Models
{
    public class PostLikers
    {
        public Guid PostId { get; set; }
        public Post Post { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public DateTime PostLikersTime { get; set; }
    }
}