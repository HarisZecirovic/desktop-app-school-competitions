using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Domain
{
   public class Clanovi
   {
      [Key]
      public int Id { get; set; }
      public DateTime DatumRodjenja { get; set; }
      public string Dozvola { get; set; }
      public string UserNameUcenika { get; set; }

      public int UcenikId { get; set; }

      public virtual Ucenik Ucenik { get; set; }
      public string ImeTimaUcenika { get; set; }
      public string ImeSkole { get; set; }


      public virtual Tim Tim { get; set; }

   }
}
