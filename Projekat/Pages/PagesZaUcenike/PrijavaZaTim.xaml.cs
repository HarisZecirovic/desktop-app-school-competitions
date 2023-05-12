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

namespace Projekat.Pages.PagesZaUcenike
{
   /// <summary>
   /// Interaction logic for PrijavaZaTim.xaml
   /// </summary>
   public partial class PrijavaZaTim : Window
   {
      TakmicenjeDbContext context = new TakmicenjeDbContext();
      TakmicenjeDbContext context2 = new TakmicenjeDbContext();

      public List<Podaci> korisnici2 { get; set; }

      Podaci osobine = new Podaci();
      int IdUcenika = 0;
      string UserNameUcenika = "";
      public PrijavaZaTim(int Id, string UserName)
      {
         InitializeComponent();
         IdUcenika = Id;
         UserNameUcenika = UserName;
      }

      private void Window_MouseDown(object sender, MouseButtonEventArgs e)
      {
         if (e.LeftButton == MouseButtonState.Pressed)
         {
            DragMove();
         }

      }

      private void Potvrdi(object sender, RoutedEventArgs e)
      {
         var ucenik = context.Ucenici.Find(IdUcenika);
         var razred = ucenik.Razred;


         if (listView.SelectedItem != null)
         {
            
            Podaci selektovanaOsoba = listView.SelectedItem as Podaci;
            if (razred.ToLower() == selektovanaOsoba.Razred.ToLower())
            {
               var brojac = 0;
               var clan =
                  from u in context.Ucenici
                  join c in context.Clanovi
                  on u.Id equals c.UcenikId
                  where c.UcenikId == IdUcenika
                  select new Clanovi();
               brojac = clan.Count();
               if(brojac > 0)
               {
                  MessageBox.Show("Vec ste poslali zahtev za tim");
                  return;

               }
              

               
               

               var dialogResult = MessageBox.Show("Da li ste sigurni da zelite da posaljete zahtev " + selektovanaOsoba.UserName, "Zahtev", MessageBoxButton.YesNo);
               if (dialogResult == MessageBoxResult.Yes)
               {
                 
                  

                     var rezultatUcenika = context.Ucenici.Find(IdUcenika);
                     DateTime datumRodjenja = rezultatUcenika.DatumRodjenja;
                     var tim = context.Timovi.Find(selektovanaOsoba.ImeTima);
                     var clanovi = new Clanovi
                     {
                        DatumRodjenja = datumRodjenja,
                        Dozvola = "",
                        UserNameUcenika = UserNameUcenika,
                        UcenikId = IdUcenika,
                        ImeTimaUcenika = selektovanaOsoba.ImeTima,
                        ImeSkole = selektovanaOsoba.Skola,
                        Tim = tim
                     };

                     context.Clanovi.Add(clanovi);
                     context.SaveChanges();

                     //Da osvezim listu korisnika
                     Prikazi(null, null);
                     listView.ItemsSource = null;
                     listView.ItemsSource = korisnici2;
                  


               }
            }
            else
            {
               MessageBox.Show("Razredi se ne podudaraju");
            }
         }
         else
         {
            MessageBox.Show("Morate da selektujete radnika kojeg zelite da obrisete!");
         }

      }

      private async void Prikazi(object sender, RoutedEventArgs e)
      {
         var tim = await context.Timovi.ToListAsync();
         korisnici2 = new List<Podaci>();

         foreach(var podaci in tim)
         {
            var id = await context.Skola.FindAsync(podaci.SkolaId);
            var imeSkole = id.NazivSkole;
            osobine = new Podaci
            {
               ImeTima = podaci.ImeTima,
               Razred = podaci.Razred,
               Id = podaci.SkolaId,
               Skola = imeSkole
            };
            korisnici2.Add(osobine);




         }
         DataContext = this;
      }

      private void Nazad_Click(object sender, RoutedEventArgs e)
      {
         var window = new PocetnaZaUcenike(IdUcenika, UserNameUcenika);
         window.Show();
         this.Close();
      }
   }
}
