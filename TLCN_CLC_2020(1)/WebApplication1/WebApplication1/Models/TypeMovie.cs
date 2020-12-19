using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class TypeMovie
    {
        public Movie Movie { get; set; }
        public string MovieId { get; set; }

        public Genre Genre { get; set; }
        public string TypeId { get; set; }
    }
}
