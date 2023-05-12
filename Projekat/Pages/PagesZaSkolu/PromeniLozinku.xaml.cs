using EntityFramework.Data;
using Projekat.Pages.PagesZaUcenike;
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
   /// Interaction logic for PromeniLozinku.xaml
   /// </summary>
   public partial class PromeniLozinku : Window
   {
      TakmicenjeDbContext context = new TakmicenjeDbContext();

      int IdKorisnika = 0;
      string UserNameKorisnika = "";
      public PromeniLozinku(int Id, string UserName)
      {
         InitializeComponent();
         IdKorisnika = Id;
         UserNameKorisnika = UserName;
      }

      private void Potvrdi_Click(object sender, RoutedEventArgs e)
      {
         var staraLozinka = staraLozinkaD.Password;
         var NovaLozinka = lozinka1Db.Password;
         var PonovljenaLozinka = lozinka2Db.Password;

         var hashStara = Hash.GetStringSha256Hash(staraLozinka);
         var hashNova = Hash.GetStringSha256Hash(NovaLozinka);
         var user = context.Users.Find(UserNameKorisnika);
         if(hashStara == user.Lozinka)
         {
            if(NovaLozinka == PonovljenaLozinka)
            {
               user.Lozinka = hashNova;
               context.SaveChanges();
               MessageBox.Show("Uspesno ste promenili lozinku");

            }
            else
            {
               txtGreska.Text = "Lozinke se ne poklapaju";
            }
         }
         else
         {
            txtGreska.Text = "Stara lozinka nije ispravna";
         }
      }

      private void Zatvori_Click(object sender, RoutedEventArgs e)
      {
         var user = context.Users.Find(UserNameKorisnika);
         if(user.Tip == "skola")
         {
            var window = new PocetnaSkola(IdKorisnika, UserNameKorisnika);
            window.Show();
            this.Close();
         }
         else if(user.Tip == "ucenik")
         {
            var window = new PocetnaZaUcenike(IdKorisnika, UserNameKorisnika);
            window.Show();
            this.Close();
         }
      }
   }
}
