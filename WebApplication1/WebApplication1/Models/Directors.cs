using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
  public class Directors
  {
    [Key]
    public string DirectorsId { get; set; }
    public string Directors_Name { get; set; }
    public string Content_Overview { get; set; }
    public string Image { get; set; }
    public Prize Prize { get; set; }
  }
}
