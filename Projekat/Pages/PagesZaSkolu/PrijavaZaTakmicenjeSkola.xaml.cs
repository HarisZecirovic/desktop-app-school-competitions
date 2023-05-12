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
   /// Interaction logic for PrijavaZaTakmicenjeSkola.xaml
   /// </summary>
   public partial class PrijavaZaTakmicenjeSkola : Window
   {
      TakmicenjeDbContext context = new TakmicenjeDbContext();
      TakmicenjeDbContext context2 = new TakmicenjeDbContext();
      TakmicenjeDbContext context3 = new TakmicenjeDbContext();


      public List<Podaci> tim { get; set; }
      public List<Takmicenje> takmicenje { get; set; }

      Podaci osobine = new Podaci();
      Takmicenje osobine2= new Takmicenje();



      int idKorisnika = 0;
      string UserNameKorisnika = "";
      public PrijavaZaTakmicenjeSkola(int Id, string UserName)
      {
         InitializeComponent();
         idKorisnika = Id;
         UserNameKorisnika = UserName;
      }

      private void Prikazi(object sender, RoutedEventArgs e)
      {
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
        tim = new List<Podaci>();
         
         foreach (var podaci in result)
         {
            var skola = context2.Skola.Find(idKorisnika);

            osobine = new Podaci
            {
               ImeTima = podaci.ImeTima,
               Razred = podaci.Razred,
               Skola = skola.NazivSkole

            };
            tim.Add(osobine);
            var rokovi =
               from t in context3.Takmicenja
               where t.DozvolaZaPrijavu == "dozvoljeno" && t.StatusTakmicenja == "u toku"
               select new
               {
                  Razred = t.RazredTakmicenja,
                  Rok = t.RokZaPrijavu,
                  Naziv = t.NazivTakmicenja,
                  Datum = t.DatumTakmicenja,
                  Id = t.Id

               };
            //ukoliko je istekao rok za prijavu, korisnik nece moci da se prijavi za takmicenje
            foreach(var rok in rokovi)
            {
               if (rok.Rok < DateTime.Now)
               {
                  var Rok = context2.Takmicenja.Find(rok.Id);
                  Rok.DozvolaZaPrijavu = "isteklo";
                  context2.SaveChanges();


               }
            }

         }
         DataContext = this;

         var result2 =
               from t in context.Takmicenja
               where t.DozvolaZaPrijavu == "dozvoljeno" && t.StatusTakmicenja == "u toku"
               select new
               { 
                  Razred = t.RazredTakmicenja,
                  Rok = t.RokZaPrijavu,
                  Naziv = t.NazivTakmicenja,
                  Datum = t.DatumTakmicenja,
                  Id = t.Id
               
               };
         takmicenje = new List<Takmicenje>();
         foreach(var podaci in result2)
         {
           
            osobine2 = new Takmicenje
            {
               NazivTakmicenja = podaci.Naziv,
               RokZaPrijavu = podaci.Rok,
               RazredTakmicenja = podaci.Razred,
               DatumTakmicenja = podaci.Datum,
               Id = podaci.Id
            };
            takmicenje.Add(osobine2);
            
         }
         DataContext = this;




      }

      private void PrijaviSe_Click(object sender, RoutedEventArgs e)
      {
         if (listView.SelectedItem != null && listView2.SelectedItem != null)
         {
            Podaci selektovaniTim = listView.SelectedItem as Podaci;
            Takmicenje selektovanoTakmicenje = listView2.SelectedItem as Takmicenje;
            var BrojClanova =
               from c in context2.Clanovi
               where c.ImeTimaUcenika == selektovaniTim.ImeTima
               select new
               {
                  imeTima = c.ImeTimaUcenika
               };
            var brojC = BrojClanova.Count();
            //proveravam da li u tom timu ima clanova, ukoliko nema skola nece moci da se prijavi za takmicenje
            if(brojC == 0)
            {
               MessageBox.Show("Nemate ni jednog clana tima");
               return;
            }
            var prijava = new PrijavaZaTakmicenje
            {
               Ime_Tima = selektovaniTim.ImeTima,
               Razred = selektovaniTim.Razred,
               NazivSkole = selektovaniTim.Skola,
               TakmicenjeId = selektovanoTakmicenje.Id
            };
            var result =
               from p in context.PrijaveZaTakmicenje
               where selektovaniTim.ImeTima == p.Ime_Tima && p.TakmicenjeId == selektovanoTakmicenje.Id
               select new PrijavaZaTakmicenje();
            var brojac = result.Count();

            if (brojac > 0)
            {
               MessageBox.Show("Vec ste se prijavili za ovo takmicenje");
               return;
            }
            else if (selektovaniTim.Razred.ToLower() == selektovanoTakmicenje.RazredTakmicenja.ToLower())
            {
               context2.PrijaveZaTakmicenje.Add(prijava);
               context2.SaveChanges();
               MessageBox.Show("Uspesno ste se prijavili za takmicenje ");
            }
            else
            {
               MessageBox.Show("Takmicenje nije za vas razred");
            }
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
