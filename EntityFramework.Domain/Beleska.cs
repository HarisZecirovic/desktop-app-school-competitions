using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Domain
{
   public class Beleska
   {
      [Key]
      public int Id { get; set; }
      public string UserNameUcenika { get; set; }
      public string ImeTimaUcenika { get; set; }
      public string TesktBeleske { get; set; }


   }
}
