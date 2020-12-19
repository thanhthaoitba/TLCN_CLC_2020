using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
  public class Productor
  {
    [Key]
    public string ProductorId { get; set; }
    public string Productor_Name { get; set; }
        public string Name_Manager { get; set; }
        public string Content_overView { get; set; }
        public string Image { get; set; }
        public string Year { get; set; }
        public string Linkfb { get; set; }
        public string LinkTwiter { get; set; }
        public string Biography { get; set; }
    }
}
