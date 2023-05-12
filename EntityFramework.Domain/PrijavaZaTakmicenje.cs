using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Domain
{
  public class PrijavaZaTakmicenje
   {
      [Key]
      public int Id { get; set; }
      public string Ime_Tima { get; set; }
      public string Razred { get; set; }
      public string NazivSkole { get; set; }

      public int TakmicenjeId { get; set; }
      public virtual Takmicenje Takmicenje { get; set; }

   }
}
