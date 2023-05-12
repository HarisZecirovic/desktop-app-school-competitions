using EntityFramework.Data;
using EntityFramework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projekat.Pages.Pocetna
{
   /// <summary>
   /// Interaction logic for DodajRezultate.xaml
   /// </summary>
   public partial class DodajRezultate : Window
   {
      TakmicenjeDbContext context = new TakmicenjeDbContext();
      int IdTakmicenja = 0;
      string UserNameUcenika = "";
      string ImeUcenika = "";
      string PrezimeUcenika = "";
      public DodajRezultate(int Id, string UserName, string Ime, string Prezime)
      {
         InitializeComponent();
         IdTakmicenja = Id;
         UserNameUcenika = UserName;
         ImeUcenika = Ime;
         PrezimeUcenika = Prezime;

      }

      private void Dodaj(object sender, RoutedEventArgs e)
      {
         var bodovi = textBox.Text;
         var rezultati = new Rezultati
         {
            Bodovi = bodovi,
            UserNameUcenika = UserNameUcenika,
            IdTakmicenja = IdTakmicenja,
            PrezimeUcenika = PrezimeUcenika,
            ImeUcenika = ImeUcenika
         };
         context.Rezultati.Add(rezultati);
         context.SaveChanges();
      }
   }
}
