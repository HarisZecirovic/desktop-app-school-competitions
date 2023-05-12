using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Domain
{
   public class Rezultati
   {
      
      [Key]
      public int Id { get; set; }
      public string UserNameUcenika { get; set; }
      public int IdTakmicenja { get; set; }

     
      public string ImeUcenika { get; set; }
      public string PrezimeUcenika { get; set; }

      public string Bodovi { get; set; }
      
      



   }
}
