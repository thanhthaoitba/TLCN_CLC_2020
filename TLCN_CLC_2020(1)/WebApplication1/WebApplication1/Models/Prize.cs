using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
  public class Prize
  {
    [Key]
    public string PrizeId { get; set; }
    public string Prize_Name { get; set; }
  }
}
