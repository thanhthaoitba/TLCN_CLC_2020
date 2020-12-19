using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class MediaDirector
    {
        [Key]
        public string MediaDirectorId { get; set; }
        public string LinkDirectorMedia { get; set; }
        public string Title { get; set; }
        public string Time { get; set; }
        public string Image { get; set; }
        public string DirectorsId { get; set; }
        public Directors Directors { get; set; }
    }
}
