using EntityFramework.Data;
using EntityFramework.Domain;
using Projekat.Pages.PagesZaUcenike;
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
   /// Interaction logic for PregledArhiviranihTakmicenja.xaml
   /// </summary>
   public partial class PregledArhiviranihTakmicenja : Window
   {
      TakmicenjeDbContext context = new TakmicenjeDbContext();
      TakmicenjeDbContext context2 = new TakmicenjeDbContext();

      public List<Takmicenje> takmicenje { get; set; }
      Takmicenje tak = new Takmicenje();
      string UserName = "";

      public PregledArhiviranihTakmicenja(string UserNameKorisnika)
      {
         InitializeComponent();
         UserName = UserNameKorisnika;
      }

      private void Prikazi(object sender, RoutedEventArgs e)
      {
         var results =
            from t in context.Takmicenja
            where t.StatusTakmicenja == "arhivirano"
            select new
            {
               NazivTakmicenja = t.NazivTakmicenja,
               StatusTakmicenja = t.StatusTakmicenja,
               RazredTakmicenja = t.RazredTakmicenja,
               DatumTakmicenja = t.DatumTakmicenja,
               IdTakmicenja = t.Id
            };
         takmicenje = new List<Takmicenje>();
         foreach(var result in results)
         {
            tak = new Takmicenje
            {
               NazivTakmicenja = result.NazivTakmicenja,
               StatusTakmicenja = result.StatusTakmicenja,
               RazredTakmicenja = result.RazredTakmicenja,
               DatumTakmicenja = result.DatumTakmicenja,
               Id = result.IdTakmicenja
            };
            takmicenje.Add(tak);
         }
         DataContext = this;
      }

      private void Pregled_Rezultata(object sender, MouseButtonEventArgs e)
      {
         if (listView.SelectedItem != null)
         {
            Takmicenje selektovanoTakmicenje = listView.SelectedItem as Takmicenje;
            var window = new PregledBodova(selektovanoTakmicenje.Id, "admin", 1);
            window.Show();
            this.Close();
         }

      }

      private void Nazad(object sender, RoutedEventArgs e)
      {
         var window = new PocetnaAdmin(UserName);
         window.Show();
         this.Close();
      }
   }
}
