using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocielApp_Demo.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool IsValid { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        
    }
}