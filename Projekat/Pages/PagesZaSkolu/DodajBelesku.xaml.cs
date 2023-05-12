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
   /// Interaction logic for DodajBelesku.xaml
   /// </summary>
   public partial class DodajBelesku : Window
   {
      TakmicenjeDbContext context = new TakmicenjeDbContext();

      //podaci za ucenika i za skolu
      string UserNameUcenika = "";
      string ImeTimaUcenika = "";
      string UserNameSkole = "";
      int IdSkole = 0;
      public DodajBelesku(string UserName, string ImeTima, string UserNameS, int IdS)
      {
         InitializeComponent();
         UserNameUcenika = UserName;
         ImeTimaUcenika = ImeTima;
         UserNameSkole = UserNameS;
         IdSkole = IdS;
         
      }

      private async void Dodaj_Belesku(object sender, RoutedEventArgs e)
      {
         var text = textBox.Text;
         var beleska = new Beleska
         {
            UserNameUcenika = UserNameUcenika,
            ImeTimaUcenika = ImeTimaUcenika,
            TesktBeleske = text
            
         };
         await context.Beleske.AddAsync(beleska);
         await context.SaveChangesAsync();
         MessageBox.Show("Uspesno ste dodali belesku");


      }

      private void Nazad_Click(object sender, RoutedEventArgs e)
      {
         var window = new PregledClanovaTima(IdSkole, UserNameSkole);
         window.Show();
         this.Close();
      }
   }
}
