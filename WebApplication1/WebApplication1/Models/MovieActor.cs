using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class MovieActor
    {
        public string ActorId { get; set; }
        public Actor Actor { get; set; }

        public Movie Movie { get; set; }
        public string MovieId { get; set; }

    }
}
