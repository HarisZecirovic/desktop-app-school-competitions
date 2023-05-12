using EntityFramework.Data;
using EntityFramework.Domain;
using Microsoft.EntityFrameworkCore;
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
   /// Interaction logic for PocetnaSkola.xaml
   /// </summary>
   public partial class PocetnaSkola : Window
   {
      TakmicenjeDbContext context = new TakmicenjeDbContext();
      TakmicenjeDbContext context2 = new TakmicenjeDbContext();
      TakmicenjeDbContext context3 = new TakmicenjeDbContext();


      public List<Podaci> korisnici2 { get; set; }

      Podaci osobine = new Podaci();
      int idKorisnika = 0;
      string UserNameKorisnika = "";
      public PocetnaSkola(int Id, string UserName)
      {
         InitializeComponent();
         idKorisnika = Id;
         UserNameKorisnika = UserName;
         label.Content = Id;
         label1.Content = UserName;
      }
      private void Tim(object sender, RoutedEventArgs e)
      {
         NapraviTimSkola tim = new NapraviTimSkola(idKorisnika,UserNameKorisnika);
         tim.Show();
         this.Close();
      }

      private void Prihvati_Click(object sender, RoutedEventArgs e)
      {
         //da odobrim ucenika za tim
         if (listView.SelectedItem != null)
         {
            Podaci selektovanaOsoba = listView.SelectedItem as Podaci;

            var dialogResult = MessageBox.Show("Da li ste sigurni da zelite da odobrite ucenika " + selektovanaOsoba.Ime, "Odobravanje", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
               var result = context.Clanovi.Find(selektovanaOsoba.Id);
               result.Dozvola = "odobreno";
               context.SaveChanges();

               //Da osvezim listu korisnika
               Prikazi(null, null);
               listView.ItemsSource = null;
               listView.ItemsSource = korisnici2;


            }
         }
         else
         {
            MessageBox.Show("Morate da selektujete radnika kojeg zelite da obrisete!");
         }

      }

      private async void Prikazi(object sender, RoutedEventArgs e)
      {
         //var rezultat =
         //   from t in context.Timovi
         //   where t.SkolaId == idKorisnika
         //   select new 
         //   {
         //      ImeTima = t.ImeTima
         //   };
         //var rezultat2 =
         //   from t in context.Timovi
         //   join c in context.Clanovi
         //   on t equals c.Tim
         //   where c.Dozvola == "" && c.Tim == rezultat
         //   select new
         //   {
         //      IdUcenika = c.UcenikId
         //   };

         //prikazujem ucenike koji su poslali zahtev za tim
         var rezultat3 =
            from t in context.Timovi
            join c in context.Clanovi
            on t equals c.Tim
            where t.SkolaId == idKorisnika && c.Dozvola == ""
            select new
            {
               ImeTima = t.ImeTima,
               IdUcenika = c.UcenikId,
               IdClana = c.Id
            };

         // var result = await context.Timovi.Where(q => q.Clanovi.Any(x => x.Dozvola == "" && q.SkolaId == idKorisnika)).Select(new Clanovi());


         korisnici2 = new List<Podaci>();

         //ispisujem podatke ucenika
         foreach (var podaci in rezultat3)
         {
            var IdUcenikaZaTim = await context2.Ucenici.FindAsync(podaci.IdUcenika);
            var UserName = IdUcenikaZaTim.UserNameUcenika;
            var korisnik = await context3.Users.FindAsync(UserName);


            osobine = new Podaci
            {
               Ime = korisnik.Ime,
               Prezime = korisnik.Prezime,
                  DatumRodjenja = IdUcenikaZaTim.DatumRodjenja,
                  Razred = IdUcenikaZaTim.Razred,
                  ImeTima = podaci.ImeTima,
                  Id = podaci.IdClana
                  
                  



               };
            
            
            
            korisnici2.Add(osobine);




         }
         DataContext = this;
      }

      private void Odbij_Click(object sender, RoutedEventArgs e)
      {
         //da se odbiju ucenici koji salju zahtev za tim
         if (listView.SelectedItem != null)
         {
            Podaci selektovanaOsoba = listView.SelectedItem as Podaci;

            var dialogResult = MessageBox.Show("Da li ste sigurni da zelite da odbijete ucenika " + selektovanaOsoba.Ime, "Odobijanje", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
               var result = context.Clanovi.Find(selektovanaOsoba.Id);
               context.Clanovi.Remove(result);
               context.SaveChanges();

               //Da osvezim listu korisnika
               Prikazi(null, null);
               listView.ItemsSource = null;
               listView.ItemsSource = korisnici2;


            }
         }
         else
         {
            MessageBox.Show("Morate da selektujete radnika kojeg zelite da obrisete!");
         }

      }

      private void Pregled_Clanova(object sender, RoutedEventArgs e)
      {
         var window = new PregledClanovaTima(idKorisnika, UserNameKorisnika);
         window.Show();
         this.Close();
      }

      private void Prijava_Click(object sender, RoutedEventArgs e)
      {
         var window = new PrijavaZaTakmicenjeSkola(idKorisnika, UserNameKorisnika);
         window.Show();
         this.Close();
      }

      private void PregledTakmicenjSkola_Click(object sender, RoutedEventArgs e)
      {
         var window = new PregledTakmicenja(idKorisnika, UserNameKorisnika);
         window.Show();
         this.Close();
      }

      private void Podaci_Click(object sender, RoutedEventArgs e)
      {
         var window = new PregledPodatakaSkola(idKorisnika, UserNameKorisnika);
         window.Show();
         this.Close();
      }

      private void OdjaviSe_Click(object sender, RoutedEventArgs e)
      {
         var window = new MainWindow();
         window.Show();
         this.Close();
      }
   }
}
