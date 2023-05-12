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
   /// Interaction logic for BiranjeRegistracije.xaml
   /// </summary>
   public partial class BiranjeRegistracije : Window
   {
      public BiranjeRegistracije()
      {
         InitializeComponent();
      }
      private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
      {
         if (Korisnik.SelectedIndex == 0)
         {
            Registracija registracija = new Registracija();
            registracija.Show();
            this.Close();
         }
         else
         {
            Registracija2 registracija = new Registracija2();
            registracija.Show();
            this.Close();
         }
      }
   }
}
