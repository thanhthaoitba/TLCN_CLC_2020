using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class PhotoDirector
    {
        [Key]
        public string PhotoProductorId { get; set; }
        public string Path { get; set; }
        public string  DirectorId { get; set; }
        public Directors Directors { get; set; }
    }
}
