using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Domain
{
   public class Tim
   {
      [Key]
      public string ImeTima { get; set; }
      public string Razred { get; set; }

      public int SkolaId { get; set; }
      public virtual Skola Skola { get; set; }
      public virtual List<Clanovi> Clanovi { get; set; }



   }
}
