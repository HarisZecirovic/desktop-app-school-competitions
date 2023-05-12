using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Domain
{
  public class Ucenik
   {
      
      public int Id { get; set; }
      public string Jmbg { get; set; }
      public string Pol { get; set; }
      public DateTime DatumRodjenja { get; set; }
      public string Razred { get; set; }
      
      public string UserNameUcenika { get; set; }

      public virtual User User { get; set; }
   }
}
