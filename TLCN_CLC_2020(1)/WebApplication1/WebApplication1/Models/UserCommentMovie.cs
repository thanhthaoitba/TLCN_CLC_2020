using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class UserCommentMovie
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public string MovieId { get; set; }
        public Movie Movie { get; set; }

        public string Content { get; set; }
        public DateTime DateTime { get; set; }

    }
}
