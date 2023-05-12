using EntityFramework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
   public class Podaci
   {
      public string UserName { get; set; }
      public string Ime { get; set; }
      public string Prezime { get; set; }
      public string Tip { get; set; }
      public string Razred { get; set; }
      public string Mesto { get; set; }
      public string Drzava { get; set; }
      public string Skola { get; set; }
      public string ImeTima { get; set; }
      public DateTime DatumRodjenja { get; set; }
      public int brojKlupe { get; set; }
      public int Id { get; set; }
      public User User { get; set; }
      public string Bodovi { get; set; }
      public int IdKlupe { get; set; }

      public int IdBodova { get; set; }











   }
}
