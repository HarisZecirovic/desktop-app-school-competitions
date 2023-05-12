using EntityFramework.Data;
using EntityFramework.Domain;
using Projekat.Pages;
using Projekat.Pages.PagesZaSkolu;
using Projekat.Pages.PagesZaUcenike;
using Projekat.Pages.Pocetna;
using Projekat.Pages.Registracije;

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekat
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      Podaci osobine = new Podaci();
      private static TakmicenjeDbContext context = new TakmicenjeDbContext();
      public MainWindow()
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
      private void Zatvori(object sender, RoutedEventArgs e)
      {
         this.Close();
      }
      private void OtvoriRegistraciju(object sender, RoutedEventArgs e)
      {
         //otvori regitraciju prozor
         BiranjeRegistracije registracija = new BiranjeRegistracije();
         registracija.Show();
         this.Close();
      }

      private void Login(object sender, RoutedEventArgs e)
      {
         var korisnickoIme = username.Text;
         var lozinka = password.Password;

         if(string.IsNullOrEmpty(korisnickoIme) || string.IsNullOrEmpty(lozinka))
         {
            txtGreska.Text = "Morate da popunite sva polja";
            return;
         }

         var result = context.Users.Find(korisnickoIme);
         var hash = Hash.GetStringSha256Hash(lozinka);

         //ako result nije null i ako se lozinka poklapa sa lozinkom iz baze
         if (result != null && hash == result.Lozinka)
         {
            var ime = result.UserName;
            //ako ima dozvolu za logovanje(ako je admin odobrio)
            if (result.Dozvola != "")
            {
               if (result.Tip == "skola")
               {
                  var rezultat2 =
               from u in context.Users
               join s in context.Skola
               on u equals s.User
               where s.User == result
               select new { Id = s.Id };
                  foreach (var podaci in rezultat2)
                  {
                     osobine = new Podaci
                     {
                        Id = podaci.Id
                     };
                  }





                  var id = osobine.Id;

                  var window = new PocetnaSkola(id, ime);
                  window.Show();
                  this.Close();
               }
               else if (result.Tip == "ucenik")
               {
                  var rezultat2 =
                  from u in context.Users
                  join s in context.Ucenici
                  on u equals s.User
                  where s.User == result
                  select new
                  {
                     Id = s.Id,
                     UserName = s.User
                  };
                  foreach (var podaci in rezultat2)
                  {
                     osobine = new Podaci
                     {
                        Id = podaci.Id,
                        User = podaci.UserName
                     };
                  }
                  var id = osobine.Id;
                  var imeUcenika = osobine.User;
                  var window = new PocetnaZaUcenike(id, ime);
                  window.Show();
                  this.Close();
               }
               else
               {
                  var window = new PocetnaAdmin(ime);
                  window.Show();
                  this.Close();
               }
               //var window = new PocetnaAdmin(ime);
               //window.Show();
            }
            else
            {
               MessageBox.Show("Jos niste prihvaceni od strane administratora");
            }
           
         }
         else
         {
            txtGreska.Text = "Neispravna lozinka ili korisnicko ime";
         }



      }

      private void Label_Click(object sender, MouseButtonEventArgs e)
      {
         var window = new ZaboravljenaLozinka();
         window.Show();
         this.Close();

      }
   }
}
