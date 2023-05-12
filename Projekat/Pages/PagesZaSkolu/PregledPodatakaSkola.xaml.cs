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

namespace Projekat.Pages.PagesZaSkolu
{
   /// <summary>
   /// Interaction logic for PregledPodatakaSkola.xaml
   /// </summary>
   public partial class PregledPodatakaSkola : Window
   {
      TakmicenjeDbContext context = new TakmicenjeDbContext();
      TakmicenjeDbContext context2 = new TakmicenjeDbContext();


      int IdKorisnika = 0;
      string UserNameKorisnika = "";
      public PregledPodatakaSkola(int Id, string UserName)
      {
         InitializeComponent();
         IdKorisnika = Id;
         UserNameKorisnika = UserName;
      }

      private void Prikazi(object sender, RoutedEventArgs e)
      {
         var results =
            from u in context.Users
            join r in context.Skola
            on u equals r.User
            where r.Id == IdKorisnika && u.UserName == UserNameKorisnika
            select new
            {
               Ime = u.Ime,
               Prezime = u.Prezime,
               Lozinka1 = u.Lozinka,
               Lozinka2 = u.Lozinka,
               NazivSkole = r.NazivSkole,
               Mesto = u.Mesto, 
               Drzava = u.Drzava,
               Telefon = u.Telefon,
               ElPosta = u.ElPosta,
               UserName = u.UserName
            };
         foreach(var result in results)
         {
            imeDb.Text = result.Ime;
            prezimeDb.Text = result.Prezime;
            skolaDb.Text = result.NazivSkole;
            mestoDb.Text = result.Mesto;
            drzavaDb.Text = result.Drzava;
            telefonDb.Text = result.Telefon;
            elPostaDb.Text = result.ElPosta;

            
            
            
         }
      }

      private void Potvrdi_Click(object sender, RoutedEventArgs e)
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
            var user = context.Users.Find(UserNameKorisnika);
            user.Ime = imeDb.Text;
            user.Prezime = prezimeDb.Text;
            user.Mesto = mestoDb.Text;
            user.Drzava = drzavaDb.Text;
            user.ElPosta = elPostaDb.Text;
            user.Telefon = telefonDb.Text;

            var skola = context2.Skola.Find(IdKorisnika);
            skola.NazivSkole = skolaDb.Text;
            context.SaveChanges();
            context2.SaveChanges();
            MessageBox.Show("Morate popuniti sva polja");
         }
         else
         {
            MessageBox.Show("Morate popuniti sva polja");
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

      private void PromeniLozinku(object sender, RoutedEventArgs e)
      {
         var window = new PromeniLozinku(IdKorisnika, UserNameKorisnika);
         window.Show();
         this.Close();
      }

      private void Nazad_Click(object sender, RoutedEventArgs e)
      {
         var window = new PocetnaSkola(IdKorisnika, UserNameKorisnika);
         window.Show();
         this.Close();
      }
   }
}
