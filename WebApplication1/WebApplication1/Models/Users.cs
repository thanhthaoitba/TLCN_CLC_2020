using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Users
    {
        [Key]
        public string userId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Country { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }

        public IList<UserCommentMovie> UserCommentMovies { get; set; }

        public IList<UserFavoriteMovie> UserFavoriteMovies { get; set; }

        public IList<UserBlog> UserBlogs { get; set; }
    }
}
