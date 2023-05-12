using EntityFramework.Data;
using Projekat.Pages.PagesZaSkolu;
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
   /// Interaction logic for PregledPodatakaUcenik.xaml
   /// </summary>
   public partial class PregledPodatakaUcenik : Window
   {
      TakmicenjeDbContext context = new TakmicenjeDbContext();
      TakmicenjeDbContext context2 = new TakmicenjeDbContext();
      TakmicenjeDbContext context3 = new TakmicenjeDbContext();

      int IdKorisnika = 0;
      string UserNameKorisnika = "";
      public PregledPodatakaUcenik(int Id, string UserName)
      {
         InitializeComponent();
         IdKorisnika = Id;
         UserNameKorisnika = UserName;
      }

      private void Prikazi(object sender, RoutedEventArgs e)
      {
         var results =
            from u in context.Users
            join r in context.Ucenici
            on u equals r.User
            where r.Id == IdKorisnika && u.UserName == UserNameKorisnika
            select new
            {
               Ime = u.Ime,
               Prezime = u.Prezime,
               Lozinka1 = u.Lozinka,
               Lozinka2 = u.Lozinka,
               Jmbg = r.Jmbg,
               Mesto = u.Mesto,
               Drzava = u.Drzava,
               Telefon = u.Telefon,
               ElPosta = u.ElPosta,
               UserName = u.UserName,
               Pol = r.Pol,
               DatumRodjenja = r.DatumRodjenja,
               Razred = r.Razred
            };
         foreach (var result in results)
         {
            imeDb.Text = result.Ime;
            prezimeDb.Text = result.Prezime;
            mestoDb.Text = result.Mesto;
            drzavaDb.Text = result.Drzava;
            telefonDb.Text = result.Telefon;
            elPostaDb.Text = result.ElPosta;
            jmbgDb.Text = result.Jmbg;
            if (result.Pol == "muski")
            {
               radioButton1.IsChecked = true;
            }
            else
            {
               radioButton2.IsChecked = true;
            }
            datumDb.SelectedDate = result.DatumRodjenja;
            razredDb.Text = result.Razred;



         }
      }

      private void Potvrdi(object sender, RoutedEventArgs e)
      {
         int brojac = 0;

         foreach (var tb in FindVisualChildren<TextBox>(Forma1))
         {
            if (tb.Text == "")
            {
               brojac++;
            }
         }
         if (brojac == 0)
         {
            var clan =
               from c in context3.Clanovi
               where c.UserNameUcenika == UserNameKorisnika
               select new
               {
                  ImeTima = c.ImeTimaUcenika
               };

            var user = context.Users.Find(UserNameKorisnika);
            user.Ime = imeDb.Text;
            user.Prezime = prezimeDb.Text;
            user.Mesto = mestoDb.Text;
            user.Drzava = drzavaDb.Text;
            user.ElPosta = elPostaDb.Text;
            user.Telefon = telefonDb.Text;

            var ucenik = context2.Ucenici.Find(IdKorisnika);
            ucenik.Jmbg = jmbgDb.Text;
            ucenik.DatumRodjenja = (DateTime)datumDb.SelectedDate;
            if ((bool)radioButton1.IsChecked)
            {
               ucenik.Pol = "muski";
            }
            else
            {
               ucenik.Pol = "zenski";
            }
            var broj = clan.Count();
            if (razredDb.Text != ucenik.Razred)
            {
               if (broj > 0)
               {
                  MessageBox.Show("Morate prvo da napustite tim da bi promenili razred");
               }
               else
               {
                  ucenik.Razred = razredDb.Text;
               }
            }

            context.SaveChanges();
            context2.SaveChanges();
         }
         else
         {
            MessageBox.Show("Niste popunili sva polja");
         }
      }

      public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
      {


         for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
         {
            var child = VisualTreeHelper.GetChild(depObj, i);

            if (child != null && child is T)
               yield return (T)child;

            foreach (T childOfChild in FindVisualChildren<T>(child))
               yield return childOfChild;
         }
      }

      private void PromeiLozinku_Click(object sender, RoutedEventArgs e)
      {
         var window = new PromeniLozinku(IdKorisnika, UserNameKorisnika);
         window.Show();
         this.Close();
      }

      private void IzadjiClick(object sender, RoutedEventArgs e)
      {
         var window = new PocetnaZaUcenike(IdKorisnika, UserNameKorisnika);
         window.Show();
         this.Close();
      }
   }
}
