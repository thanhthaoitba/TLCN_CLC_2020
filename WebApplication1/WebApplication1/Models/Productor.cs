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
    public string Year { get; set; }
  }
}
