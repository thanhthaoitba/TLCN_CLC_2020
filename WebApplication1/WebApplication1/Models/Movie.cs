using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Movie
    {
        [Key]
        public string movieId { get; set; }
        [Column(TypeName ="nvarchar(100)")]
        public string MovieName { get; set; }
        [Column(TypeName = "nvarchar(5)")]
        public string ReleaseYear { get; set; }
        public int Length { get; set; } // minutes
        [Column(TypeName = "nvarchar(1000)")]
        public string Link_Trailer { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        
        public float Ave_Rate { get; set; }
        public string Content_Overview { get; set; }
        public Prize Prize { get; set; }
    public Directors Directors { get; set; }
    public Productor Productor { get; set; }
    public IList<MovieActor> MovieActors { get; set; }

        public IList<TypeMovie> TypeMovies { get; set; }

        public IList<UserCommentMovie> UserCommentMovies { get; set; }

        public IList<UserFavoriteMovie> UserFavoriteMovies { get; set; }



    }
}
