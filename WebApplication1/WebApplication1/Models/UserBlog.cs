using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class UserBlog
    {
        public Blog Blog { get; set; }
        public string BlogId { get; set; }

        public User User { get; set; }
        public string UserId { get; set; }
    public string Comment { get; set; }
    public string DateTime { get; set; }
  }
}
