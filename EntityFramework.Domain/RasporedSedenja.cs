using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Domain
{
   public class RasporedSedenja
   {
      
      [Key]
      public int Id { get; set; }
      public string UserNameUcenika { get; set; }
      public int IdTakmicenja { get; set; }
      
      
      public string ImeTima { get; set; }
      
      public string NazivSkole { get; set; }

      public int BrojKlupe { get; set; }
      public int BrojZadnjeKlupe { get; set; }

      public int PrijavaZaTakmicenjeId { get; set; }
      public virtual PrijavaZaTakmicenje PrijavaZaTakmicenje { get; set; }




   }
}
