using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Actor
    {
        [Key]
        public string ActorId { get; set; }
        public string ActorName { get; set; }
        public string Content_Overview { get; set; }
        public DateTime Date { get; set; }
        public string Country { get; set; }
        public string Height { get; set; }
        public string String { get; set; }

        public IList<MovieActor> MovieActors { get; set; }
    }
}
