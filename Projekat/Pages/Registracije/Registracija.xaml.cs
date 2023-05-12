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

namespace Projekat.Pages.Registracije
{
   /// <summary>
   /// Interaction logic for Registracija.xaml
   /// </summary>
   public partial class Registracija : Window
   {
      TakmicenjeDbContext context = new TakmicenjeDbContext();
      public Registracija()
      {
         InitializeComponent();
      }
      private void Window_MouseDown(object sender, MouseButtonEventArgs e)
      {
         if (e.LeftButton == MouseButtonState.Pressed)
         {
            DragMove();
         }
      }
      private void Close(object sender, RoutedEventArgs e)
      {
         this.Close();
      }

      private void Potvrdi(object sender, RoutedEventArgs e)
      {
         var radio1 = radioButton1.Content;
         var radio2 = radioButton2.Content;
         var datum = datumDb.SelectedDate;
         var ime = imeDb.Text;
         var prezime = prezimeDb.Text;
         var jmbg = jmbgDb.Text;
         var mesto = mestoDb.Text;
         var userName = usernameDb.Text;
         var telefon = telefonDb.Text;
         var elPosta = elPostaDb.Text;
         var lozinka1 = lozinka1Db.Password;
         var lozinka2 = lozinka2Db.Password;
         var drzava = drzavaDb.Text;
         var razred = razredDb.Text;
         var password = Hash.GetStringSha256Hash(lozinka1);
         string polOsobe = "";
         if ((bool)radioButton1.IsChecked)
         {
            polOsobe = "muski";
         }
         else
         {
            polOsobe = "zenski";
         }
          
         var korisnik = new User
         {
            Ime = ime,
            Prezime = prezime,
            UserName = userName,
            Lozinka = password,
            Mesto = mesto,
            Drzava = drzava,
            Telefon = telefon,
            ElPosta = elPosta,
            Tip = "ucenik",
            Dozvola = ""
         };

         var ucenik = new Ucenik
         {
            Jmbg = jmbg,
            Pol = polOsobe,
            DatumRodjenja = (DateTime)datum,
            Razred = razred,
            UserNameUcenika = userName,
            User = korisnik

         };

         int brojac = 0;

         foreach (var tb in FindVisualChildren<TextBox>(Forma1))
         {
            if (tb.Text == "")
            {
               brojac++;
            }
         }
         var result = context.Users.Where(q => q.UserName.Equals(userName)).ToList();
         if (result.Count > 0)
         {
            txtGreska.Text = "Ovo korisnicko ime je vec zauzeto";

         }
         else if (brojac > 0)
         {
            MessageBox.Show("Niste popunili sva polja! ");
            return;

         }
         else if (lozinka1 != lozinka2)
         {
            MessageBox.Show("Lozinke se ne podudaraju! ");
            return;
         }
         else
         {

            context.Add(korisnik);
            context.Add(ucenik);

            context.SaveChanges();
            MessageBox.Show("Popunili ste registraciju, sada sacekajte da vas administrator prihvati! ");
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
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
   }
}
