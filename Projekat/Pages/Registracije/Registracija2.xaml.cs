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

namespace Projekat.Pages.Registracije
{
   /// <summary>
   /// Interaction logic for Registracija2.xaml
   /// </summary>
   public partial class Registracija2 : Window
   {
      TakmicenjeDbContext context = new TakmicenjeDbContext();
      public Registracija2()
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

      private void Izadji(object sender, RoutedEventArgs e)
      {
         this.Close();
      }

      private void Potvrdi(object sender, RoutedEventArgs e)
      {
         var ime = imeDb.Text;
         var prezime = prezimeDb.Text;
         var username = usernameDb.Text;
         var lozinka1 = lozinka1Db.Password;
         var lozinka2 = lozinka2Db.Password;
         var mesto = mestoDb.Text;
         var drzava = drzavaDb.Text;
         var skola = skolaDb.Text;
         var telefon = telefonDb.Text;
         var elPosta = elPostaDb.Text;
         var UserName = usernameDb.Text;
         var password = Hash.GetStringSha256Hash(lozinka1);


         var korisnik = new User
         {
            Ime = ime,
            Prezime = prezime,
            UserName = username,
            Lozinka = password,
            Mesto = mesto,
            Drzava = drzava,
            Telefon = telefon,
            ElPosta = elPosta,
            Tip = "skola",
            Dozvola = ""
         };
         
         var NovaSkola = new Skola
         {
            NazivSkole = skola,
            UserNameSkole = username,
            User = korisnik
         };
         int brojac = 0;
         
         foreach (var tb in FindVisualChildren<TextBox>(Forma1))
         {
            if(tb.Text == "")
            {
               brojac++;
            }  
         }
         var result = context.Users.Where(q => q.UserName.Equals(UserName)).ToList();
         if(result.Count > 0)
         {
            txtGreska.Text = "Ovo korisnicko ime je vec zauzeto";
            
         }
         
         
         else if(brojac > 0)
         {
            MessageBox.Show("Niste popunili sva polja! ");
            return;

         }
         else if(lozinka1 != lozinka2)
         {
            MessageBox.Show("Lozinke se ne podudaraju! ");
            return;
         }
         else {
            context.Add(korisnik);
            context.Add(NovaSkola);

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
