using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class PhotoActor
    {
        [Key]
        public string PhotoActorId { get; set; }
        public string ActorId { get; set; }
        public string Path { get; set; }
        public Actor Actor { get; set; }

    }
}
