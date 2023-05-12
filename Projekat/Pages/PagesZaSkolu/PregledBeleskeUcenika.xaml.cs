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
   /// Interaction logic for PregledBeleskeUcenika.xaml
   /// </summary>
   public partial class PregledBeleskeUcenika : Window
   {
      TakmicenjeDbContext context = new TakmicenjeDbContext();
      int IdKorisnika = 0;
      string UserNameKorisnika = "";
      string UserNameUcenika = "";


      public List<Beleska> korisnici2 { get; set; }
      Beleska beleska = new Beleska();
      public PregledBeleskeUcenika(int Id, string UserName, string UserNameUcenikaKorisnika)
      {
         InitializeComponent();
         IdKorisnika = Id;
         UserNameKorisnika = UserName;
         UserNameUcenika = UserNameUcenikaKorisnika;
      }

      private void Prikazi(object sender, RoutedEventArgs e)
      {
         //prikaz beleske selektvanog ucenika
         var result =
            from b in context.Beleske
            where b.UserNameUcenika == UserNameUcenika
            select new
            {
               Beleska = b.TesktBeleske,
               UserName = b.UserNameUcenika
            };

         //ispisujem beleske

         korisnici2 = new List<Beleska>();
         foreach (var rezultat in result)
         {
            beleska = new Beleska
            {
               TesktBeleske = rezultat.Beleska
            };
            korisnici2.Add(beleska);
            
         }
         DataContext = this;

      }

      private void Izadji_Click(object sender, RoutedEventArgs e)
      {
         var window = new PregledClanovaTima(IdKorisnika, UserNameKorisnika);
         window.Show();
         this.Close();
      }
   }
}
