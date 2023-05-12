using EntityFramework.Data;
using EntityFramework.Domain;
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
   /// Interaction logic for PregledTakmicenja.xaml
   /// </summary>
   public partial class PregledTakmicenja : Window
   {
      TakmicenjeDbContext context = new TakmicenjeDbContext();
      TakmicenjeDbContext context2 = new TakmicenjeDbContext();

      public List<Takmicenje> takmicenje { get; set; }
      Takmicenje tak = new Takmicenje();

      int Id = 0;
      string UserName = "";
      public PregledTakmicenja(int IdSkole, string UserNameSkole)
      {
         InitializeComponent();
         Id = IdSkole;
         UserName = UserNameSkole;
      }

      private void PrikaziTakmicenja(object sender, RoutedEventArgs e)
      {
         //da prikazem takmicenja na koja se skola prijavila
         var skola = context.Skola.Find(Id);

         var prijave =
            from p in context.PrijaveZaTakmicenje
            where p.NazivSkole == skola.NazivSkole
            select new
            {
               Id = p.TakmicenjeId
            };
         takmicenje = new List<Takmicenje>();
         if (prijave != null)
         {
            foreach (var prijava in prijave)
            {
               var takmicenjeSkola = context2.Takmicenja.Find(prijava.Id);
               tak = new Takmicenje
               {
                  NazivTakmicenja = takmicenjeSkola.NazivTakmicenja,
                  RazredTakmicenja = takmicenjeSkola.RazredTakmicenja,
                  StatusTakmicenja = takmicenjeSkola.StatusTakmicenja,
                  DatumTakmicenja = takmicenjeSkola.DatumTakmicenja,
                  Id = takmicenjeSkola.Id
                  
               };
               takmicenje.Add(tak);
            }
            DataContext = this;
         }
      }

      private void PrikaziRezultate(object sender, MouseButtonEventArgs e)
      {
         Takmicenje selektovanoTakmicenje = listView.SelectedItem as Takmicenje;
         var window = new PregledBodova(selektovanoTakmicenje.Id, UserName, Id);
         window.Show();
         this.Close();

      }

      private void NazadClick(object sender, RoutedEventArgs e)
      {
         var window = new PocetnaSkola(Id, UserName);
         window.Show();
         this.Close();
      }
   }
}
