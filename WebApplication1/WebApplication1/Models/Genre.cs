using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Genre
    {
        [Key]
        public string TypeId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Type_Name { get; set; }
        public IList<TypeMovie> TypeMovies { get; set; }
    }
}
