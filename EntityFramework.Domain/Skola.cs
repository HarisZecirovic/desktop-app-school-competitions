using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Domain
{
   public class Skola
   {
      [Key]
      public int Id { get; set; }
      public string NazivSkole { get; set; }

      
      public string UserNameSkole { get; set; }
      public virtual User User { get; set; }
   }
}
