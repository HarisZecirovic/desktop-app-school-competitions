using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Domain
{
   public class User
   {
      [Key]
      public string UserName { get; set; }

      public string Ime { get; set; }
      public string Prezime { get; set; }
      public string Lozinka { get; set; }
      public string Mesto { get; set; }
      public string Drzava { get; set; }
      public string Telefon { get; set; }
      public string ElPosta { get; set; }
      public string Tip { get; set; }
      public string Dozvola { get; set; }
      public IList<Skola> Skola {get;} = new List<Skola>();
      public IList<Ucenik> Ucenici { get; } = new List<Ucenik>();


      //public List<Ucenik> Ucenik { get; set; }
      //public List<Skola> Skola { get; set; }
   }
}
