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

namespace Projekat.Pages.Pocetna
{
   /// <summary>
   /// Interaction logic for OrganizujTakmicenje.xaml
   /// </summary>
   public partial class OrganizujTakmicenje : Window
   {
      private static TakmicenjeDbContext context = new TakmicenjeDbContext();
      string UserName = "";
      public OrganizujTakmicenje(string UserNameKorisnika)
      {
         InitializeComponent();
         UserName = UserNameKorisnika;
      }

      private  void Potvrdi_Click(object sender, RoutedEventArgs e)
      {
         var naziv = nazivDb.Text;
         var razred = razredDb.Text;
         var rok = rokZaPrijavuDb.SelectedDate;
         var datum = datumDb.SelectedDate;

         if (naziv != null && razred != null && rok != null && datum != null)
         {
         var takmicenje = new Takmicenje
         {
            NazivTakmicenja = naziv,
            RazredTakmicenja = razred,
            RokZaPrijavu = (DateTime)rok,
            DatumTakmicenja = (DateTime)datum,
            StatusTakmicenja = "u toku",
            DozvolaZaPrijavu = "dozvoljeno"
         };
         
            context.Takmicenja.AddAsync(takmicenje);
            context.SaveChanges();
            MessageBox.Show("Uspesno ste organizovali takmicenje");
         }
         else
         {
            MessageBox.Show("Niste popunili sva polja ");

         }

      }

      private void NazadClick(object sender, RoutedEventArgs e)
      {
         var window = new PocetnaAdmin(UserName);
         window.Show();
         this.Close();

      }
   }
}
