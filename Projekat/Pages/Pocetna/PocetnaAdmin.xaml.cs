using EntityFramework.Data;
using EntityFramework.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
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
   /// Interaction logic for PocetnaAdmin.xaml
   /// </summary>
   public partial class PocetnaAdmin : Window
   {
      TakmicenjeDbContext context = new TakmicenjeDbContext();
      public List<Podaci> korisnici2 { get; set; }

      Podaci osobine = new Podaci();
      public List<User> korisnici { get; set; }
      User user = new User();
      public List<Takmicenje> takmicenje { get; set; }
      Takmicenje tak = new Takmicenje();
      string UserNameKorisnika = "";
      public PocetnaAdmin(string Username )
      {
         InitializeComponent();

         string UserNameKorisnika = Username;
         label1.Content = UserNameKorisnika;
      }

    

      private async void Prikazi(object sender, RoutedEventArgs e)
      {
         
         
         //var result = context.Users.Where(q => q.Dozvola.Equals("")).ToList();
         var rezultat =
            from u in context.Users
            join k in context.Ucenici
            on u equals k.User
            where u.Dozvola == ""
            select new 
            {
               Ime = u.Ime,
               Razred = k.Razred,
               Prezime = u.Prezime,
               Tip =u.Tip,
               UserName = u.UserName,
               Id = k.Id,
               Drzava = u.Drzava,
               Mesto = u.Mesto
            };
         var rezultat2 =
            from u in context.Users
            join s in context.Skola
            on u equals s.User
            where u.Dozvola == ""
            select new
            {
               Ime = u.Ime,
               Skola = s.NazivSkole,
               Prezime = u.Prezime,
               Tip = u.Tip,
               UserName = u.UserName,
               Id = s.Id,
               Drzava = u.Drzava,
               Mesto = u.Mesto
            };
         
            

            


         //korisnici = new List<User>();

         korisnici2 = new List<Podaci>();
         //foreach (var podaci in result)
         //{
         //   user = new User
         //   {
         //      Ime = podaci.Ime,
         //      Prezime = podaci.Prezime,
         //      Telefon = podaci.Telefon,
         //      Mesto = podaci.Mesto,
         //      Drzava = podaci.Drzava,
         //      Tip = podaci.Tip,
         //      ElPosta = podaci.ElPosta
               
               
         //   };
         //   korisnici.Add(user);


         //}
         foreach(var podaci in rezultat)
         {
            osobine = new Podaci
            {
               Ime = podaci.Ime,
               Prezime = podaci.Prezime,
               Razred = podaci.Razred,
               Tip = podaci.Tip,
               UserName = podaci.UserName,
               Id = podaci.Id,
               Mesto = podaci.Mesto,
               Drzava = podaci.Drzava
               
            };
            korisnici2.Add(osobine);
           
         }
         foreach(var podaci2 in rezultat2)
         {
            osobine = new Podaci
            {
               Ime = podaci2.Ime,
               Prezime = podaci2.Prezime,
               Skola = podaci2.Skola,
               Tip = podaci2.Tip,
               UserName = podaci2.UserName,
               Id = podaci2.Id,
               Mesto = podaci2.Mesto,
               Drzava = podaci2.Drzava

            };
            korisnici2.Add(osobine);
         }
         DataContext = this;
         // listView.Items.Add(korisnici);
         // listView.Items[0].ToString();

         var results =
            from t in context.Takmicenja
            where t.StatusTakmicenja == "u toku" || t.StatusTakmicenja == "zavrseno"
            select new
            {
               NazivTakmicenja = t.NazivTakmicenja,
               RazredTakmicenja = t.RazredTakmicenja,
               DatumTakmicenja = t.DatumTakmicenja,
               StatusTakmicenja = t.StatusTakmicenja,
               IdTakmicenja = t.Id
            
            };
         takmicenje = new List<Takmicenje>();
         foreach(var result in results)
         {
            tak = new Takmicenje
            {
               NazivTakmicenja = result.NazivTakmicenja,
               RazredTakmicenja = result.RazredTakmicenja,
               DatumTakmicenja = result.DatumTakmicenja,
               StatusTakmicenja = result.StatusTakmicenja,
               Id = result.IdTakmicenja
            };
            takmicenje.Add(tak);
         }
         DataContext = this;
   


      }
      private void Dodaj(object sender, RoutedEventArgs e)
      {
         
         if (listView.SelectedItem != null)
         {
            Podaci selektovanaOsoba = listView.SelectedItem as Podaci;
            
            var dialogResult = MessageBox.Show("Da li ste sigurni da zelite da odobrite radnika " + selektovanaOsoba.UserName, "Odobravanje", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
               var result = context.Users.Find(selektovanaOsoba.UserName);

               result.Dozvola = "dozvoljeno";
               
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
        // Prikazi(null, null);


      }

      private async void Odbij(object sender, RoutedEventArgs e)
      {
         if (listView.SelectedItem != null)
         {
            Podaci selektovanaOsoba = listView.SelectedItem as Podaci;

            var dialogResult = MessageBox.Show("Da li ste sigurni da zelite da odbijete radnika " + selektovanaOsoba.UserName, "Odbijanje", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
            
               var osoba = context.Users.Find(selektovanaOsoba.UserName);
               if(osoba.Tip == "skola")
               {
                  var skola = context.Skola.Find(selektovanaOsoba.Id);
                  context.Skola.Remove(skola);
               }
               else
               {
                  var ucenik = await context.Ucenici.FindAsync(selektovanaOsoba.Id);
                  context.Ucenici.Remove(ucenik);
               }
               
               context.Users.Remove(osoba);
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
         //Prikazi(null, null);

      }

      private void OrganizujTamicenje_click(object sender, RoutedEventArgs e)
      {
         var window = new OrganizujTakmicenje(UserNameKorisnika);
         window.Show();
         this.Close();
      }

      private void Prikazi_Timove(object sender, MouseButtonEventArgs e)
      {
         if (listView2.SelectedItem != null)
         {
            Takmicenje selektovanaOsoba = listView2.SelectedItem as Takmicenje;
            var window = new BrojKlupaUcenici(selektovanaOsoba.Id);
            window.Show();
            this.Close();
         }

      }

      private void PregledKorisnika(object sender, RoutedEventArgs e)
      {
         var window = new PregledSvihClanova(UserNameKorisnika);
         window.Show();
         this.Close();
      }

      private void ArhivirajTakmicenje_Click(object sender, RoutedEventArgs e)
      {
         if (listView2.SelectedItem != null)
         {
            Takmicenje selektovanoTakmicnje = listView2.SelectedItem as Takmicenje;
            var arhiviraj = context.Takmicenja.Find(selektovanoTakmicnje.Id);
            var dialogResult = MessageBox.Show("Da li ste sigurni da zelite da arhivirate takmicenje? " , "Arhiviranje", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
               arhiviraj.StatusTakmicenja = "arhivirano";
               context.SaveChanges();
               Prikazi(null, null);
               listView2.ItemsSource = null;
               listView2.ItemsSource = takmicenje;
               DataContext = this;
               

            }
         }

      }

      private void Pregled_Arhiviranih(object sender, RoutedEventArgs e)
      {
         var window = new PregledArhiviranihTakmicenja(UserNameKorisnika);
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
