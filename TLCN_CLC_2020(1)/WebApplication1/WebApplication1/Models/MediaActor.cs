using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class MediaActor
    {
        [Key]
        public string MediaActorId { get; set; }
        public string LinkActorMedia { get; set; }
        public string Title  { get; set; }
        public string  Time { get; set; }
        public string  Image { get; set; }
        public string ActorId { get; set; }
        public Actor Actor { get; set; }
        
    }
}
