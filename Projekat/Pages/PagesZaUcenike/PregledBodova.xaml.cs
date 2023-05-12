using EntityFramework.Data;
using EntityFramework.Domain;
using Projekat.Pages.PagesZaSkolu;
using Projekat.Pages.Pocetna;
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
   /// Interaction logic for PregledBodova.xaml
   /// </summary>
   public partial class PregledBodova : Window
   {
      private static TakmicenjeDbContext context = new TakmicenjeDbContext();
      private static TakmicenjeDbContext context2 = new TakmicenjeDbContext();

      public List<Podaci> rezultati { get; set; }
      Rezultati rez = new Rezultati();
      Podaci podaci = new Podaci();

      string UserName = "";
      int IdKorisnika = 0;
      int IdTakmicenja = 0;
      public PregledBodova(int Id, string UserNameKorisnika, int IdUsera)
      {
         InitializeComponent();
         IdTakmicenja = Id;
         UserName = UserNameKorisnika;
         IdKorisnika = IdUsera;

         
      }
      private bool UserFilter(object item)
      {
         if (String.IsNullOrEmpty(textBox.Text))
         {
            return true;
         }
        
         else
            return ((item as Podaci).Ime.IndexOf(textBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);

        
      }

      private void PrikaziBodoveLoad(object sender, RoutedEventArgs e)
      {
         var results =
            from r in context.Rezultati
            where r.IdTakmicenja == IdTakmicenja
            orderby r.Bodovi descending
            select new
            {
               UserName = r.UserNameUcenika,
               Bodovi = r.Bodovi,
               Ime = r.ImeUcenika,
               Prezime = r.PrezimeUcenika
            };
         rezultati = new List<Podaci>();
         int i = 1;
         foreach (var result in results)
         {
            
            
            podaci = new Podaci
            {
               Id = i++,
               Ime = result.Ime,
               Prezime = result.Prezime,
               Bodovi = result.Bodovi
            };
            rezultati.Add(podaci);
            

         }
         DataContext = this;

      }

      private void SearchList(object sender, TextChangedEventArgs e)
      {
         CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listView.ItemsSource);
         view.Filter = UserFilter;
         CollectionViewSource.GetDefaultView(listView.ItemsSource).Refresh();
      }

      private void NazadClick(object sender, RoutedEventArgs e)
      {
         var user = context.Users.Find(UserName);
         if(user.Tip == "skola")
         {
            var window = new PregledTakmicenja(IdKorisnika, UserName);
            window.Show();
            this.Close();
         }
         else if(user.Tip == "ucenik")
         {
            var window = new PocetnaZaUcenike(IdKorisnika, UserName);
            window.Show();
            this.Close();
         }
         else
         {
            var window = new PocetnaAdmin(UserName);
            window.Show();
            this.Close();
         }
      }
   }
}
