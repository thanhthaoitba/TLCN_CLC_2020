using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class MediaProductor
    {
        [Key]
        public string MediaProductorId { get; set; }
        public string LinkProductorMedia { get; set; }
        public string Title { get; set; }
        public string Time { get; set; }
        public string Image { get; set; }
        public string ProductorId { get; set; }
        public Productor Productor { get; set; }
    }
}
