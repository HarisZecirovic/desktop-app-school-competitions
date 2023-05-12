using EntityFramework.Data;
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
   /// Interaction logic for PregledSvihClanova.xaml
   /// </summary>
   public partial class PregledSvihClanova : Window
   {
      TakmicenjeDbContext context = new TakmicenjeDbContext();
      TakmicenjeDbContext context2 = new TakmicenjeDbContext();
      TakmicenjeDbContext context3 = new TakmicenjeDbContext();
      TakmicenjeDbContext context4 = new TakmicenjeDbContext();
      TakmicenjeDbContext context5 = new TakmicenjeDbContext();
      TakmicenjeDbContext context6 = new TakmicenjeDbContext();





      public List<Podaci> korisnici2 { get; set; }
      public List<Podaci> korisnici { get; set; }

      Podaci osobine = new Podaci();
      Podaci osobine2 = new Podaci();

      string UserName = "";
      public PregledSvihClanova(string UserNameKorisnika)
      {
         InitializeComponent();
         UserName = UserNameKorisnika;
      }

      private void PrikaziClanove(object sender, RoutedEventArgs e)
      {
         var rezultat =
            from u in context.Users
            join k in context.Ucenici
            on u equals k.User

            select new
            {
               Ime = u.Ime,
               Razred = k.Razred,
               Prezime = u.Prezime,
               Tip = u.Tip,
               UserName = u.UserName,
               Id = k.Id,
               Drzava = u.Drzava,
               Mesto = u.Mesto
            };
         var rezultat2 =
            from u in context.Users
            join s in context.Skola
            on u equals s.User

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
         korisnici2 = new List<Podaci>();
         foreach (var podaci in rezultat)
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
         foreach (var podaci2 in rezultat2)
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

      }
      private bool UserFilter(object item)
      {
         if (String.IsNullOrEmpty(textBox.Text))
         {
            return true;
         }

         else
            return ((item as Podaci).Ime.IndexOf(textBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);


      }

      private void Search(object sender, TextChangedEventArgs e)
      {
         CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listView.ItemsSource);
         view.Filter = UserFilter;
         CollectionViewSource.GetDefaultView(listView.ItemsSource).Refresh();
      }

      private async void Ukloni(object sender, RoutedEventArgs e)
      {
         if (listView.SelectedItem != null)
         {
            Podaci selektovanaOsoba = listView.SelectedItem as Podaci;

            var dialogResult = MessageBox.Show("Da li ste sigurni da zelite da obrisete osobu " + selektovanaOsoba.UserName, "Odbijanje", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {

               var osoba = context.Users.Find(selektovanaOsoba.UserName);
               //proveravam tip osobe
               if (osoba.Tip == "skola")
               {
                  var skola = context.Skola.Find(selektovanaOsoba.Id);
                  var timovi =
                     from t in context2.Timovi
                     where t.SkolaId == selektovanaOsoba.Id
                     select new
                     {
                        ImeTima = t.ImeTima
                     };
                  
                   //proveravam da li osoba ima tim, ukoliko ima brisem njegove timove
                  if(timovi != null)
                  {
                     
                     foreach(var tim in timovi)
                     {
                        var rezultat =
                           from t in context4.Timovi
                           join c in context4.Clanovi
                           on t equals c.Tim
                           where c.ImeTimaUcenika == tim.ImeTima
                           select new
                           {
                              c.Id
                           };
                        //var clanovi =
                        //    from c in context5.Clanovi
                        //    where c.ImeTimaUcenika == tim.ImeTima
                        //    select new
                        //    {
                        //       Id = c.Id
                        //   };
                        //brisem i clanove tima skole koje zelim da obrisem
                        if(rezultat != null)
                        {
                           foreach(var clan in rezultat)
                           {
                              var clanTima = context6.Clanovi.Find(clan.Id);
                              context5.Clanovi.Remove(clanTima);
                           }
                        }
                          
                     }
                     foreach(var tim in timovi)
                     {
                        var team = context3.Timovi.Find(tim.ImeTima);
                        context3.Timovi.Remove(team);
                     }
                  }
                  context.Skola.Remove(skola);
               }
               else
               {
                  var ucenik = await context.Ucenici.FindAsync(selektovanaOsoba.Id);
                  var clanovi =
                     from c in context4.Clanovi
                     where c.UcenikId == ucenik.Id
                     select new
                     {
                        id = c.Id
                     };
                  //ukoliko je ucenik proveravam da li je clan nekog tima, ako jeste izbacujem ga iz tima i onda brisem iz baze
                  if(clanovi != null)
                  {
                     foreach(var clan in clanovi)
                     {
                        var clanKorisnik = context6.Clanovi.Find(clan.id);
                        context6.Clanovi.Remove(clanKorisnik);
                     }
                  }
                  context.Ucenici.Remove(ucenik);
               }

               context.Users.Remove(osoba);
               context6.SaveChanges();
               context5.SaveChanges();
               context3.SaveChanges();

               context.SaveChanges();

               //Da osvezim listu korisnika
               PrikaziClanove(null, null);
               listView.ItemsSource = null;
               listView.ItemsSource = korisnici2;

               DataContext = this;
            }
         }
         else
         {
            MessageBox.Show("Morate da selektujete radnika kojeg zelite da obrisete!");
         }
      }

      private void NazadClick(object sender, RoutedEventArgs e)
      {
         var window = new PocetnaAdmin(UserName);
         window.Show();
         this.Close();
      }
   }
}
