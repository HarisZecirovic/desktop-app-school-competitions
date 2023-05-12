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

namespace Projekat.Pages.PagesZaUcenike
{
   /// <summary>
   /// Interaction logic for PocetnaZaUcenike.xaml
   /// </summary>
   public partial class PocetnaZaUcenike : Window
   {
      private static TakmicenjeDbContext context = new TakmicenjeDbContext();
      private static TakmicenjeDbContext context2 = new TakmicenjeDbContext();
      private static TakmicenjeDbContext context3 = new TakmicenjeDbContext();
      private static TakmicenjeDbContext context4 = new TakmicenjeDbContext();



      public List<Podaci> korisnici { get; set; }
      public List<Takmicenje> takmicenje { get; set; }


      int IdClana = 0;
      Podaci osobine = new Podaci();
      Takmicenje tak = new Takmicenje();

      int IdUcenika = 0;
      string UserNameUcenika = "";
      public PocetnaZaUcenike(int Id, string UserName)
      {
         InitializeComponent();
         IdUcenika = Id;
         UserNameUcenika = UserName;
         label.Content = Id;
         label1.Content = UserName;
      }

      private void Prijava(object sender, RoutedEventArgs e)
      {
         var window = new PrijavaZaTim(IdUcenika, UserNameUcenika);
         window.Show();
         this.Close();
      }

      private void Prikazi_Loaded(object sender, RoutedEventArgs e)
      {
         //ovde ispisujem ime tima i skolu u kojoj je ucenik clan
         //ispisujem i takmicenja na kojima se takmici
         //rezultate moze da vidi ukoliko je takmicenje zavrseno
         var imeTima = "";
         var result =
            from c in context.Clanovi
            where c.UserNameUcenika == UserNameUcenika && c.Dozvola == "odobreno"
            select new
            {
               ImeTima = c.ImeTimaUcenika,
               Skola = c.ImeSkole,
               Id = c.Id
            };
         var brojac = 0;
         brojac = result.Count();
         if (brojac > 0)
         {
            foreach (var podaci in result)
            {

               textBox.Text = "Vi ste clan " + podaci.ImeTima + " skole " + podaci.Skola;
               imeTima = podaci.ImeTima;
               IdClana = podaci.Id;
            }
         }
         else
         {
            textBox.Text = "Niste clan ni jednog tima ";
         }
         korisnici = new List<Podaci>();
         var rezultati =
            from c in context2.Clanovi
            where c.ImeTimaUcenika == imeTima
            select new
            {
               UserName = c.UserNameUcenika
            };
         foreach(var rezultat in rezultati)
         {
            var korisnik = context3.Users.Find(rezultat.UserName);
            osobine = new Podaci
            {
               Ime = korisnik.Ime,
               Prezime = korisnik.Prezime
            };
            korisnici.Add(osobine);
         }
         DataContext = this;

         var takmicenjeQuery =
            from p in context.PrijaveZaTakmicenje
            where p.Ime_Tima == imeTima
            select new
            {
               Id = p.TakmicenjeId
            };
         takmicenje = new List<Takmicenje>();
         textBox2.Text = "Takmicenje";
         foreach(var tak1 in takmicenjeQuery)
         {
            var rezultatTakmicenja = context4.Takmicenja.Find(tak1.Id);

            if (rezultatTakmicenja.StatusTakmicenja == "u toku" || rezultatTakmicenja.StatusTakmicenja == "zavrseno")
            {
               tak = new Takmicenje
               {
                  NazivTakmicenja = rezultatTakmicenja.NazivTakmicenja,
                  RazredTakmicenja = rezultatTakmicenja.RazredTakmicenja,
                  RokZaPrijavu = rezultatTakmicenja.RokZaPrijavu,
                  DatumTakmicenja = rezultatTakmicenja.DatumTakmicenja,
                  Id = rezultatTakmicenja.Id
                 
               };
               takmicenje.Add(tak);
            }
         }
         DataContext = this;




      }



      private void Napusti(object sender, RoutedEventArgs e)
      {
       
         //Ukoliko ucenik zeli da napusti tim
            
            var dialogResult = MessageBox.Show("Da li ste sigurni da zelite da napustite tim ", "Odobijanje", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
               var result = context.Clanovi.Find(IdClana);
            if (result != null)
            {

               context.Clanovi.Remove(result);
               context.SaveChanges();
            }

               //Da osvezim listu korisnika
               Prikazi_Loaded(null, null);
               listView.ItemsSource = null;
               listView.ItemsSource = korisnici;


            }
         
      }

      private void PrikaziBodove(object sender, MouseButtonEventArgs e)
      {
         Takmicenje selektovanoTakmicenje = listView2.SelectedItem as Takmicenje;
         var takmicenje = context.Takmicenja.Find(selektovanoTakmicenje.Id);
            if(takmicenje.StatusTakmicenja == "zavrseno")
         {
            var window = new PregledBodova(selektovanoTakmicenje.Id, UserNameUcenika, IdUcenika);
            window.Show();
            this.Close();
         }
         else
         {
            MessageBox.Show("Takmicenje jos nije zavrseno");
         }
         
         

      }

      private void Podaci_Click(object sender, RoutedEventArgs e)
      {
         var window = new PregledPodatakaUcenik(IdUcenika, UserNameUcenika);
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
