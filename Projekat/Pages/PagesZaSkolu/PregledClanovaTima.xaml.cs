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

namespace Projekat.Pages.PagesZaSkolu
{
   /// <summary>
   /// Interaction logic for PregledClanovaTima.xaml
   /// </summary>
   public partial class PregledClanovaTima : Window
   {
      TakmicenjeDbContext context = new TakmicenjeDbContext();
      TakmicenjeDbContext context2 = new TakmicenjeDbContext();

      int idKorisnika = 0;
      string UserNameKorisnika = "";
      public List<Podaci> korisnici2 { get; set; }
      public List<Podaci> korisnici { get; set; }


      Podaci osobine = new Podaci();
      Podaci osobine2 = new Podaci();

      public PregledClanovaTima(int Id, string UserName)
      {
         InitializeComponent();
         idKorisnika = Id;
         UserNameKorisnika = UserName;
      }

      private void Prikazi(object sender, RoutedEventArgs e)
      {
         //ispisujem ime timova koje skola ima
         var result =
            from s in context.Skola
            join t in context.Timovi
            on s.Id equals t.SkolaId
            where t.SkolaId == idKorisnika
            select new
            {
               ImeTima = t.ImeTima,
               Razred = t.Razred
            };
         korisnici2 = new List<Podaci>();
         foreach (var podaci in result)
         {
            osobine = new Podaci
            {
               ImeTima = podaci.ImeTima,
               Razred = podaci.Razred

            };
            korisnici2.Add(osobine);
         }
         DataContext = this;
      }

      private void Prikazi_Clanove(object sender, MouseButtonEventArgs e)
      {
         //na osnovu selektovanog tima prikazuje clanove toga tima
         if (listView.SelectedItem != null)
         {
            Podaci selektovanaOsoba = listView.SelectedItem as Podaci;

            var result =
               from c in context.Clanovi
               where c.ImeTimaUcenika == selektovanaOsoba.ImeTima
               select new
               {
                  UserName = c.UserNameUcenika,
                  Dozvola = c.Dozvola,
                  Id = c.Id
               };
            korisnici = new List<Podaci>();

            foreach (var podaci in result)
            {
               if (podaci.Dozvola != "")
               {
                  var rezultat = context2.Users.Find(podaci.UserName);
                  osobine2 = new Podaci
                  {
                     Ime = rezultat.Ime,
                     Prezime = rezultat.Prezime,
                     Id = podaci.Id,
                     UserName = podaci.UserName

                  };
                  korisnici.Add(osobine2);
               }
               
            }
            DataContext = this;





            //Da osvezim listu korisnika
            //Prikazi(null, null);
            listView2.ItemsSource = null;
            listView2.ItemsSource = korisnici;



         }
         else
         {
            MessageBox.Show("Morate da selektujete radnika kojeg zelite da obrisete!");
         }
      }

      private void Izbaci_Click(object sender, RoutedEventArgs e)
      {
         //da izbaci zeljenog ucenika
         if (listView2.SelectedItem != null)
         {
            Podaci selektovanaOsoba = listView2.SelectedItem as Podaci;
            var dialogResult = MessageBox.Show("Da li ste sigurni da zelite da izbacite ucenika " + selektovanaOsoba.Ime, "Odobijanje", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
               var result = context.Clanovi.Find(selektovanaOsoba.Id);
               context.Clanovi.Remove(result);
               context.SaveChanges();

               //Da osvezim listu korisnika
               Prikazi(null, null);
               listView2.ItemsSource = null;
               listView2.ItemsSource = korisnici;


            }
         }

      }

      private void Dodaj_Belesku(object sender, RoutedEventArgs e)
      {
         if (listView.SelectedItem != null & listView2.SelectedItem != null)
         {
            Podaci selektovaniTim = listView.SelectedItem as Podaci;
            Podaci selektovanaOsoba = listView2.SelectedItem as Podaci;

            var window = new DodajBelesku(selektovanaOsoba.UserName, selektovaniTim.ImeTima, UserNameKorisnika, idKorisnika);
            window.Show();
            this.Close();
         }
      }

      private void Prikazi_Belesku(object sender, MouseButtonEventArgs e)
      {
         if (listView2.SelectedItem != null)
         {
            Podaci selektovanaOsoba = listView2.SelectedItem as Podaci;
            var window = new PregledBeleskeUcenika(idKorisnika, UserNameKorisnika, selektovanaOsoba.UserName);
            window.Show();
            this.Close();
         }
         
      }

      private void Nazad_Click(object sender, RoutedEventArgs e)
      {
         var window = new PocetnaSkola(idKorisnika, UserNameKorisnika);
         window.Show();
         this.Close();
      }
   }
}
