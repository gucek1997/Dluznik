using Dluznik.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dluznik
{
    public class DluznikApp
    {
    
        public DluznikManager DluznikManager { get; set; }  = new DluznikManager();
        
        public void IntroduceDeptorApp()
        {
            Console.WriteLine("Aplikacja Dłużnik");


        }

        public void AddDluznik()
        {
            Console.WriteLine("Podaj nazwe dluznika: ");
            var userName = Console.ReadLine();


            Console.WriteLine("Podaj Kwotę długu: ");
            var userAmount = Console.ReadLine();

            var amountInDecimal = default(decimal);

            while (!decimal.TryParse(userAmount, out amountInDecimal))
            {
                Console.WriteLine("Podano niepoprawną kwotę ");
                Console.WriteLine("Podaj Kwotę długu: ");

                userAmount = Console.ReadLine();
            }

            DluznikManager.AddDluznik(userName, amountInDecimal);
      
        }

        public void DeleteDluznik()
        {
            Console.WriteLine("Podaj nazwe dluznika którego chcesz usunąć z listy: ");
            
            var userName = Console.ReadLine();

            DluznikManager.DeleteDluznik(userName);

            Console.WriteLine("Udało się usunąć dłużnika");
        }

        public void ListAllBorrower()
        {
            Console.WriteLine("Oto lista twoich dłużników: ");

            foreach (var dluznik in DluznikManager.ListBorrowers())
            {

                Console.WriteLine(dluznik);
                
            }

        }

        public void AskForAction()
        {
            var userinput = default(string);    

            while (userinput != "exit")
            {
                Console.WriteLine("Podaj czynność którą chcesz wykonać: ");
                Console.WriteLine("add - Dodawanie użytkowania ");
                Console.WriteLine("del - Usuwanie użytkowania ");
                Console.WriteLine("list - Lista użytkowników ");
                Console.WriteLine("exit - wyjście z programu ");


                userinput = Console.ReadLine();
                userinput = userinput.ToLower();

                switch (userinput)
                {
                    case "add":
                        AddDluznik();
                        break;
                    case "del":
                        DeleteDluznik();
                        break;
                    case "list":
                        ListAllBorrower();
                        break;
                    default:
                        Console.WriteLine("Podano złą wartość");
                        break;
                }

            }


        }



    }
}
