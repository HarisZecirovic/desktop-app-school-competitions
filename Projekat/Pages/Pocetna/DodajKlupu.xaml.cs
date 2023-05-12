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
   /// Interaction logic for DodajKlupu.xaml
   /// </summary>
   public partial class DodajKlupu : Window
   {
      TakmicenjeDbContext context = new TakmicenjeDbContext();
      TakmicenjeDbContext context2 = new TakmicenjeDbContext();
      TakmicenjeDbContext context3 = new TakmicenjeDbContext();



      int idTakmicenja = 0;
      string imeTimaUcenika = "";
      string UserNameUcenika = "";
      string imeSkoleUcenika = "";
      int idPrijaveZaTakmicenje = 0;


      public DodajKlupu(int id,int idPrijave,  string imeTima, string UserName, string ImeSkole)
      {
         InitializeComponent();
         idTakmicenja = id;
         imeTimaUcenika = imeTima;
         UserNameUcenika = UserName;
         imeSkoleUcenika = ImeSkole;
         idPrijaveZaTakmicenje = idPrijave;
      }

      private void Button_Click(object sender, RoutedEventArgs e)
      {
         
         string broj = textBox.Text;
         int brojac = 0;
         if (broj != null)
         {
            //ako je broj unete klupe razlicito od null, pretrazi raspored sedenja gde je IdTakmicenja, trenutno takmicenje
            var results =
               from r in context2.RasporediSedenja
               where r.IdTakmicenja == idTakmicenja
               select new
               {
                  brojKlupe = r.BrojKlupe
               };
            foreach (var result in results)
            {
               //proveravam da li u raspored sedenja postoji uneta klupa
               if (result.brojKlupe == int.Parse(broj))
               {
                  brojac++;
               }
            }
            //nalazim klupu ispred i klupu iza 
            int klupaIspred = int.Parse(broj) + 1;
            int klupaIZa = int.Parse(broj) - 1;
            int query = results.Count();
            
            //var zauzeta = context3.RasporediSedenja.Find(UserNameUcenika);

            //proveravam da li se unosi prva klupa, ukoliko ni jedna nije dodana jos
            if (query == 0)
            {
               //ako je brojac = 0 tj. nema u bazi takva klupa
               if (brojac == 0)
               {

                  var klupa = new RasporedSedenja
                  {
                     IdTakmicenja = idTakmicenja,
                     ImeTima = imeTimaUcenika,
                     UserNameUcenika = UserNameUcenika,
                     NazivSkole = imeSkoleUcenika,
                     BrojKlupe = int.Parse(broj),
                     BrojZadnjeKlupe = int.Parse(broj),
                     PrijavaZaTakmicenjeId = idPrijaveZaTakmicenje


                  };
                  context.RasporediSedenja.Add(klupa);
                  context.SaveChanges();
               }
               else
               {
                  MessageBox.Show("Klupa je zauzeta");
                  return;
               }
            }
            else
            {
               if (brojac == 0)
               {
                  //ovde sad proveravam dozvolu za klupu
                  string[] arr = new string[3];
                  List<string> list = new List<string>();
                  //trazim iz baze klupu iza i klupu ispred i dodajem u niz
                  var ucenici1 =
                     from r in context.RasporediSedenja
                     where r.IdTakmicenja == idTakmicenja && r.BrojKlupe == klupaIZa
                     select new
                     {
                        UserName = r.UserNameUcenika
                     };
                  int i = 0;
                  //ovde se dodaje klupa iza
                  foreach (var ucenik in ucenici1)
                  {
                     arr[i] = ucenik.UserName;
                     i++;
                  }
                  var ucenici2 =
                     from r in context.RasporediSedenja
                     where r.IdTakmicenja == idTakmicenja && r.BrojKlupe == klupaIspred
                     select new
                     {
                        UserName = r.UserNameUcenika
                     };
                  //ovde se dodaje klupa ispred
                  foreach (var ucenik in ucenici2)
                  {
                     arr[i] = ucenik.UserName;
                     i++;
                  }
                  //u redu ima najvise 5 klupa i proveravam da li je klupa prva u redu
                  //ako je klupa prva onda proveravam klupu desno od nje
                  //ako su iste onda nece moci tu da se doda klupa
                  if(int.Parse(broj) % 5 == 1)
                  {
                     //proveravam da li posstoji ucenik desno od klupe koja se dodaje
                     if(arr[1] != null)
                     {
                        var skola2 = "";
                        var rezultat2 =
                       from r in context.RasporediSedenja
                       where r.IdTakmicenja == idTakmicenja && r.UserNameUcenika == arr[1]
                       select new
                       {
                          NazivSkole = r.NazivSkole
                       };
                        foreach (var rezultati2 in rezultat2)
                        {
                           skola2 = rezultati2.NazivSkole;
                        }
                        if (skola2 == imeSkoleUcenika && int.Parse(broj) == klupaIspred - 1)
                        {
                           MessageBox.Show("Ne mozete tu klupu izabrati zbog skola");
                           return;

                        }
                        else
                        {
                           var klupa = new RasporedSedenja
                           {
                              IdTakmicenja = idTakmicenja,
                              ImeTima = imeTimaUcenika,
                              UserNameUcenika = UserNameUcenika,
                              NazivSkole = imeSkoleUcenika,
                              BrojKlupe = int.Parse(broj),
                              BrojZadnjeKlupe = int.Parse(broj),
                              PrijavaZaTakmicenjeId = idPrijaveZaTakmicenje


                           };
                           context.RasporediSedenja.Add(klupa);
                           context.SaveChanges();
                        }

                     }
                     else
                     {
                        var klupa = new RasporedSedenja
                        {
                           IdTakmicenja = idTakmicenja,
                           ImeTima = imeTimaUcenika,
                           UserNameUcenika = UserNameUcenika,
                           NazivSkole = imeSkoleUcenika,
                           BrojKlupe = int.Parse(broj),
                           BrojZadnjeKlupe = int.Parse(broj),
                           PrijavaZaTakmicenjeId = idPrijaveZaTakmicenje


                        };
                        context.RasporediSedenja.Add(klupa);
                        context.SaveChanges();
                     }
                  }
                  //ako je klupa skroz desno, onda proveravam da li na klupi levo do nje postoji ucenik sa istom skolom
                  else if(int.Parse(broj) %  5 == 0)
                  {
                     if(arr[0] != null)
                     {
                        var skola1 = "";
                        var rezultat =
                       from r in context.RasporediSedenja
                       where r.IdTakmicenja == idTakmicenja && r.UserNameUcenika == arr[0]
                       select new
                       {
                          NazivSkole = r.NazivSkole
                       };
                        foreach (var rezultati in rezultat)
                        {
                           skola1 = rezultati.NazivSkole;
                        }
                        if (skola1 == imeSkoleUcenika && int.Parse(broj) == klupaIZa + 1)
                        {
                           MessageBox.Show("Ne mozete tu klupu izabrati zbog skola");
                           return;
                        }
                        else
                        {
                           var klupa = new RasporedSedenja
                           {
                              IdTakmicenja = idTakmicenja,
                              ImeTima = imeTimaUcenika,
                              UserNameUcenika = UserNameUcenika,
                              NazivSkole = imeSkoleUcenika,
                              BrojKlupe = int.Parse(broj),
                              BrojZadnjeKlupe = int.Parse(broj),
                              PrijavaZaTakmicenjeId = idPrijaveZaTakmicenje


                           };
                           context.RasporediSedenja.Add(klupa);
                           context.SaveChanges();
                        }


                     }
                     else
                     {
                        var klupa = new RasporedSedenja
                        {
                           IdTakmicenja = idTakmicenja,
                           ImeTima = imeTimaUcenika,
                           UserNameUcenika = UserNameUcenika,
                           NazivSkole = imeSkoleUcenika,
                           BrojKlupe = int.Parse(broj),
                           BrojZadnjeKlupe = int.Parse(broj),
                           PrijavaZaTakmicenjeId = idPrijaveZaTakmicenje


                        };
                        context.RasporediSedenja.Add(klupa);
                        context.SaveChanges();
                     }

                  }
                  //ovde proveravam za sve ostale slucajeve
                 else if (arr[0] != null && arr[1] != null)
                  {
                     var skola1 = "";
                     var skola2 = "";
                     //var rezultat = context.RasporediSedenja.Find(arr[0]);
                     //var rezultat2 = context2.RasporediSedenja.Find(arr[1]);
                     var rezultat =
                       from r in context.RasporediSedenja
                       where r.IdTakmicenja == idTakmicenja && r.UserNameUcenika == arr[0]
                       select new
                       {
                          NazivSkole = r.NazivSkole
                       };
                     foreach (var rezultati in rezultat)
                     {
                        skola1 = rezultati.NazivSkole;
                     }

                     var rezultat2 =
                       from r in context.RasporediSedenja
                       where r.IdTakmicenja == idTakmicenja && r.UserNameUcenika == arr[1]
                       select new
                       {
                          NazivSkole = r.NazivSkole
                       };
                     foreach (var rezultati2 in rezultat2)
                     {
                        skola2 = rezultati2.NazivSkole;
                     }
                     
                     if (skola1 == imeSkoleUcenika && skola2 == imeSkoleUcenika && int.Parse(broj) == klupaIspred - 1)
                     {
                        MessageBox.Show("Ne mozete tu klupu izabrati zbog skola");
                        return;

                     }
                     else if (skola1 == imeSkoleUcenika && skola2 != imeSkoleUcenika && int.Parse(broj) == klupaIZa + 1)
                     {
                        MessageBox.Show("Ne mozete tu klupu izabrati zbog skola");
                        return;
                     }
                     else if (skola1 != imeSkoleUcenika && skola2 == imeSkoleUcenika && int.Parse(broj) == klupaIspred -1 || int.Parse(broj) == klupaIspred + 1)
                     {
                        MessageBox.Show("Ne mozete tu klupu izabrati zbog skola");
                        return;
                     }
                     else
                     {
                        var klupa = new RasporedSedenja
                        {
                           IdTakmicenja = idTakmicenja,
                           ImeTima = imeTimaUcenika,
                           UserNameUcenika = UserNameUcenika,
                           NazivSkole = imeSkoleUcenika,
                           BrojKlupe = int.Parse(broj),
                           BrojZadnjeKlupe = int.Parse(broj),
                           PrijavaZaTakmicenjeId = idPrijaveZaTakmicenje


                        };
                        context.RasporediSedenja.Add(klupa);
                        context.SaveChanges();
                     }
                  }
                  else if (arr[0] != null && arr[1] == null)
                  {
                     //var rezultat = context.RasporediSedenja.Find(arr[0]);
                     var rezultat =
                        from r in context.RasporediSedenja
                        where r.IdTakmicenja == idTakmicenja && r.UserNameUcenika == arr[0]
                        select new
                        {
                           NazivSkole = r.NazivSkole
                        };
                     var skola1 = "";
                     foreach(var rezultati in rezultat)
                     {
                        skola1 = rezultati.NazivSkole;
                     }
                     
                     if (skola1 == imeSkoleUcenika && int.Parse(broj) == klupaIZa + 1)
                     {
                        MessageBox.Show("Ne mozete tu klupu izabrati zbog skola");
                        return;
                     }
                     else
                     {
                        var klupa = new RasporedSedenja
                        {
                           IdTakmicenja = idTakmicenja,
                           ImeTima = imeTimaUcenika,
                           UserNameUcenika = UserNameUcenika,
                           NazivSkole = imeSkoleUcenika,
                           BrojKlupe = int.Parse(broj),
                           BrojZadnjeKlupe = int.Parse(broj),
                           PrijavaZaTakmicenjeId = idPrijaveZaTakmicenje


                        };
                        context.RasporediSedenja.Add(klupa);
                        context.SaveChanges();
                     }
                  }
                  else if (arr[0] == null && arr[1] != null)
                  {
                     //var rezultat2 = context2.RasporediSedenja.Find(arr[1]);
                     //var skola2 = rezultat2.NazivSkole;
                     var skola2 = "";
                     var rezultat2 =
                       from r in context.RasporediSedenja
                       where r.IdTakmicenja == idTakmicenja && r.UserNameUcenika == arr[1]
                       select new
                       {
                          NazivSkole = r.NazivSkole
                       };
                     foreach (var rezultati2 in rezultat2)
                     {
                        skola2 = rezultati2.NazivSkole;
                     }
                     if (skola2 == imeSkoleUcenika && int.Parse(broj) == klupaIspred - 1 || int.Parse(broj) == klupaIZa + 1)
                     {
                        MessageBox.Show("Ne mozete tu klupu izabrati zbog skola");
                        return;
                     }
                     else
                     {
                        var klupa = new RasporedSedenja
                        {
                           IdTakmicenja = idTakmicenja,
                           ImeTima = imeTimaUcenika,
                           UserNameUcenika = UserNameUcenika,
                           NazivSkole = imeSkoleUcenika,
                           BrojKlupe = int.Parse(broj),
                           BrojZadnjeKlupe = int.Parse(broj),
                           PrijavaZaTakmicenjeId = idPrijaveZaTakmicenje


                        };
                        context.RasporediSedenja.Add(klupa);
                        context.SaveChanges();
                     }
                  }
                  else
                  {
                     var klupa = new RasporedSedenja
                     {
                        IdTakmicenja = idTakmicenja,
                        ImeTima = imeTimaUcenika,
                        UserNameUcenika = UserNameUcenika,
                        NazivSkole = imeSkoleUcenika,
                        BrojKlupe = int.Parse(broj),
                        BrojZadnjeKlupe = int.Parse(broj),
                        PrijavaZaTakmicenjeId = idPrijaveZaTakmicenje


                     };
                     context.RasporediSedenja.Add(klupa);
                     context.SaveChanges();
                  }

               }
               else
               {
                  MessageBox.Show("Klupa je zauzeta");
                  return;
               }
            }
            
            
         }
         else
         {
            MessageBox.Show("Niste Uneli broj klupe");
         }
      }

      
   }
}
