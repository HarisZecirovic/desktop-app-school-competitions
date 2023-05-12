using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Domain
{
  public class Takmicenje
   {  
      [Key]
      public int Id { get; set; }
      public string NazivTakmicenja { get; set; }
      public DateTime RokZaPrijavu { get; set; }
      public DateTime DatumTakmicenja { get; set; }
      public string RazredTakmicenja { get; set; }
      public string StatusTakmicenja { get; set; }
      public string DozvolaZaPrijavu { get; set; }






   }
}
