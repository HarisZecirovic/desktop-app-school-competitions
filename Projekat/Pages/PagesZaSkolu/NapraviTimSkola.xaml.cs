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
   /// Interaction logic for NapraviTimSkola.xaml
   /// </summary>
   public partial class NapraviTimSkola : Window
   {
      int IdSkole = 0;
      string UserNameSkole = "";
      TakmicenjeDbContext context = new TakmicenjeDbContext();
      public NapraviTimSkola(int Id, string UserName)
      {
         InitializeComponent();
         
          IdSkole = Id;
          UserNameSkole = UserName; 

      }

      private void Window_MouseDown(object sender, MouseButtonEventArgs e)
      {
         if (e.LeftButton == MouseButtonState.Pressed)
         {
            DragMove();
         }
      }

      private async void Potvrdi(object sender, RoutedEventArgs e)
      {
         var imeTima = imeTimaDb.Text;
         var razred = razredDb.Text;

         var tim = new Tim
         {
            ImeTima = imeTima,
            Razred = razred,
            SkolaId = IdSkole

         };
         int brojac = 0;
         //proveravam da li ima vec ima tim sa tim razredom
         var proveriRazred =
            from t in context.Timovi
            where t.Razred.ToLower() == razred.ToLower() && t.SkolaId == IdSkole
            select new
            {
               Razred = t.Razred
            };
         
         var BrojRazreda = proveriRazred.Count();
         //proveravam da li su popunjena sva polja
         foreach (var tb in FindVisualChildren<TextBox>(Forma1))
         {
            if (tb.Text == "")
            {
               brojac++;
            }
         }
         if(brojac > 0)
         {
            MessageBox.Show("Niste popunili sva polja! ");
            return;
         }
         else if(BrojRazreda != 0)
         {
            MessageBox.Show("Vec imate tim sa ovim razredom");
            return;
         }
         else
         {
            await context.AddAsync(tim);
            await context.SaveChangesAsync();
            MessageBox.Show("Uspesno ste napravili tim ");

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

      private void Nazad_Click(object sender, RoutedEventArgs e)
      {
         var window = new PocetnaSkola(IdSkole, UserNameSkole);
         window.Show();
         this.Close();
      }
   }
}
