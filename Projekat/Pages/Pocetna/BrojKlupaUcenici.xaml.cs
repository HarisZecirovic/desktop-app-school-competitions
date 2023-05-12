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
   /// Interaction logic for BrojKlupaUcenici.xaml
   /// </summary>
   public partial class BrojKlupaUcenici : Window
   {
      TakmicenjeDbContext context = new TakmicenjeDbContext();
      TakmicenjeDbContext context2 = new TakmicenjeDbContext();
      TakmicenjeDbContext context3 = new TakmicenjeDbContext();
      TakmicenjeDbContext context4 = new TakmicenjeDbContext();



      public List<Podaci> korisnici2 { get; set; }
      public List<Podaci> korisnici { get; set; }
      Podaci osobine = new Podaci();
      Podaci osobine2 = new Podaci();

      int idTakmicenja = 0;
      
      public BrojKlupaUcenici(int id)
      {
         InitializeComponent();
         idTakmicenja = id;
         listView2.ItemsSource = null;
         listView2.ItemsSource = korisnici;
      }

      private void Prikazi(object sender, RoutedEventArgs e)
      {
         //prikazujem timove koji su se prijavili za takmicenje
         var result =
            from p in context.PrijaveZaTakmicenje
            where p.TakmicenjeId == idTakmicenja
            select new
            {
               ImeTima = p.Ime_Tima,
               Razred = p.Razred,
               Id = p.Id,
               Skola = p.NazivSkole
              
            };
         korisnici2 = new List<Podaci>();
         foreach (var podaci in result)
         {
            osobine = new Podaci
            {
               ImeTima = podaci.ImeTima,
               Razred = podaci.Razred,
               Id = podaci.Id,
               Skola = podaci.Skola


            };
            korisnici2.Add(osobine);
         }
         DataContext = this;
         listView2.ItemsSource = null;
         listView2.ItemsSource = korisnici;

      }

      private void PrikaziClanove(object sender, MouseButtonEventArgs e)
      {
         //prikazujem clanove selektovanog tima
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

            //var klupa = context3.RasporediSedenja.Find(idTakmicenja);
            //var bodovi = context4.Rezultati.Find(idTakmicenja);
            
            

            korisnici = new List<Podaci>();

            foreach (var podaci in result)
            {
               if (podaci.Dozvola != "")
               {
                  //nalazim podatke o uceniku, kao i broj klupe i bodove
                  var rezultat = context2.Users.Find(podaci.UserName);
                  var klupa =
               from r in context3.RasporediSedenja
               where r.IdTakmicenja == idTakmicenja && r.UserNameUcenika == podaci.UserName
               select new
               {
                  BrojKlupe = r.BrojKlupe,
                  Id = r.Id
               };
                  var bodovi =
                     from rez in context4.Rezultati
                     where rez.IdTakmicenja == idTakmicenja && rez.UserNameUcenika == podaci.UserName
                     select new
                     {
                        Bodovi = rez.Bodovi,
                        Id = rez.Id
                     };
                  //proveravam da li postoje bodovi za ucenika
                  if (klupa != null && bodovi != null)
                  {
                     

                        osobine2 = new Podaci
                        {
                           Ime = rezultat.Ime,
                           Prezime = rezultat.Prezime,
                           Id = podaci.Id,
                           UserName = podaci.UserName,
                           



                        };
                     //upisujem klupu i broj bodova
                     foreach(var klupe in klupa)
                     {
                        osobine2.brojKlupe = klupe.BrojKlupe;
                        osobine2.IdKlupe = klupe.Id;
                     }
                     foreach(var bod in bodovi)
                     {
                        osobine2.Bodovi = bod.Bodovi;
                        osobine2.IdBodova = bod.Id;
                     }
                        korisnici.Add(osobine2);
                     
                     
                  }
                  else if(klupa != null && bodovi == null)
                  {
                     
                        osobine2 = new Podaci
                        {
                           Ime = rezultat.Ime,
                           Prezime = rezultat.Prezime,
                           Id = podaci.Id,
                           UserName = podaci.UserName,
                           
                           Bodovi = "Nije pregledano"



                        };
                     foreach (var klupe in klupa)
                     {
                        osobine2.brojKlupe = klupe.BrojKlupe;
                        osobine2.IdKlupe = klupe.Id;
                     }
                     korisnici.Add(osobine2);
                     
                  }
                  else if(klupa == null && bodovi == null)
                  {
                     osobine2 = new Podaci
                     {
                        Ime = rezultat.Ime,
                        Prezime = rezultat.Prezime,
                        Id = podaci.Id,
                        UserName = podaci.UserName,
                        brojKlupe = 0,
                        Bodovi = "Nije pregledano"

                     };
                     korisnici.Add(osobine2);
                  }
               }

            }
            DataContext = this;





            //Da osvezim listu korisnika
            //PrikaziClanove(null, null);
            listView2.ItemsSource = null;
            listView2.ItemsSource = korisnici;



         }
         else
         {
            MessageBox.Show("Morate da selektujete radnika kojeg zelite da obrisete!");
         }
      }

      private void DodajKlupu_Click(object sender, MouseButtonEventArgs e)
      {
         Podaci selektovaniTim = listView.SelectedItem as Podaci;
         Podaci selektovanaOsoba = listView2.SelectedItem as Podaci;
         if (listView.SelectedItem != null)
         {
            var result =
               from r in context.RasporediSedenja
               where r.IdTakmicenja == idTakmicenja && r.UserNameUcenika == selektovanaOsoba.UserName
               select new
               {
                  BrojKlupe = r.BrojKlupe
               };
            int broj = result.Count();
            if (broj == 0)
            {
               var window = new DodajKlupu(idTakmicenja, selektovaniTim.Id, selektovaniTim.ImeTima, selektovanaOsoba.UserName, selektovaniTim.Skola);
               window.Closed += Window_Closed;
               window.Show();
            }
            else
            {
               MessageBox.Show("Ucenik ima klupu ");
               return;
            }
         }
         else
         {
            MessageBox.Show("Morate da izaberete tim");
         }


      }

      private void DodajBodove(object sender, RoutedEventArgs e)
      {
         if (listView2.SelectedItem != null)
         {
            Podaci selektovanaOsoba = listView2.SelectedItem as Podaci;

            var window = new DodajRezultate(idTakmicenja, selektovanaOsoba.UserName, selektovanaOsoba.Ime, selektovanaOsoba.Prezime);
            window.Closed += Window_Closed;
            window.Show();
         }
      }

      private void Window_Closed(object sender, EventArgs e)
      {
         PrikaziClanove(null, null);
         listView2.ItemsSource = null;
         listView2.ItemsSource = korisnici;
         DataContext = this;

      }

      private void ZavrsiTakmicenje(object sender, RoutedEventArgs e)
      {
         var dialogResult = MessageBox.Show("Da li ste sigurni da zelite da zavrsite takmicenje " , "Odbijanje", MessageBoxButton.YesNo);
         if (dialogResult == MessageBoxResult.Yes)
         {
            var takmicenje = context.Takmicenja.Find(idTakmicenja);
            takmicenje.StatusTakmicenja = "zavrseno";
            context.SaveChanges();
         }
      }

      private void Focus(object sender, RoutedEventArgs e)
      {
         
      }

      private void ResetujBodove_Click(object sender, RoutedEventArgs e)
      {
         if (listView2.SelectedItem != null)
         {
            Podaci selektovanaOsoba = listView2.SelectedItem as Podaci;

            var bodoviReset = context.Rezultati.Find(selektovanaOsoba.IdBodova);
            context.Rezultati.Remove(bodoviReset);
            context.SaveChanges();
            MessageBox.Show("Resetovali ste bodove za ucenika " + selektovanaOsoba.Ime);
            PrikaziClanove(null, null);
            listView2.ItemsSource = null;
            listView2.ItemsSource = korisnici;
            DataContext = this;
         }


      }

      private void ResetujKlupu_Click(object sender, RoutedEventArgs e)
      {
         if (listView2.SelectedItem != null)
         {
            Podaci selektovanaOsoba = listView2.SelectedItem as Podaci;

            var bodoviReset = context.RasporediSedenja.Find(selektovanaOsoba.IdKlupe);
            context.RasporediSedenja.Remove(bodoviReset);
            context.SaveChanges();
            MessageBox.Show("Resetovali ste klupu za ucenika " + selektovanaOsoba.Ime);
            PrikaziClanove(null, null);
            listView2.ItemsSource = null;
            listView2.ItemsSource = korisnici;
            DataContext = this;
         }
      }

      private void Nazad_Click(object sender, RoutedEventArgs e)
      {
         var window = new PocetnaAdmin("admin");
         window.Show();
         this.Close();
      }
   }
}
