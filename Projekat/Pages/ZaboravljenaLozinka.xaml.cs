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

namespace Projekat.Pages
{
   /// <summary>
   /// Interaction logic for ZaboravljenaLozinka.xaml
   /// </summary>
   public partial class ZaboravljenaLozinka : Window
   {
      private static TakmicenjeDbContext context = new TakmicenjeDbContext();

      public ZaboravljenaLozinka()
      {
         InitializeComponent();
      }

      private void Nazad(object sender, RoutedEventArgs e)
      {
         
         this.Close();
      }

      private void Potvrdi_Click(object sender, RoutedEventArgs e)
      {
         var korisnickoIme = username.Text;
         var lozinka1 = lozinka1Db.Password;
         var lozinka2 = lozinka2Db.Password;
         var password = Hash.GetStringSha256Hash(lozinka1);
         if (string.IsNullOrEmpty(korisnickoIme) || string.IsNullOrEmpty(lozinka1) || string.IsNullOrEmpty(lozinka2))
         {
            txtGreska.Text = "Morate da popunite sva polja";
            return;
         }
         var result = context.Users.Find(korisnickoIme);
         if(result != null)
         {
            if(lozinka1 == lozinka2)
            {
               result.Lozinka = password;
               context.SaveChanges();
               MessageBox.Show("Uspesno ste promenili lozinku");
            }
            else
            {
               MessageBox.Show("Ne podudaraju vam se lozinke");
            }
         }
         else
         {
            txtGreska.Text = "Ne postoji takvo korisnicko ime";
         }
      }
   }
}
