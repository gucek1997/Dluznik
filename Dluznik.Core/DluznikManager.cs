using System.Collections.Generic;
using System;
using System.IO;

namespace Dluznik.Core
{
    public class DluznikManager
    {

        private List<Dluznik> Dluznicy { get; set; }

        private String Filename { get; set; } = "borrowers.txt";     

        //inicjalizacja listy
        public DluznikManager()
        {

            Dluznicy = new List<Dluznik>();

            if(!File.Exists(Filename))
            {
                return;
            }

         //zapisywanie dłużników w pliku



            var filelines = File.ReadAllLines(Filename);
            foreach(var line in filelines)
            {
               var lineItems =    line.Split(';');


                if (decimal.TryParse(lineItems[1], out var amountInDecimal))
                {
                    AddDluznik(lineItems[0], amountInDecimal,false);
                }
                
              
            }


        }



        //dodawanie
        public void AddDluznik(string name,decimal amount, bool shouldSaveToFile = true)
        {

            var dluznik = new Dluznik
            {
                Name = name,
                Amount = amount 

            };


            Dluznicy.Add(dluznik);

            if(shouldSaveToFile)
            {
                File.WriteAllLines(Filename, new List<string> { dluznik.ToString() });

            }





       
        }

        // usuwanie 
        public void DeleteDluznik(string name,bool shouldSaveToFile = true)
        {
            foreach(var dluznik in Dluznicy )
            {
                if(dluznik.Name == name)
                {
                    Dluznicy.Remove(dluznik);
                    break;
                }
        
            }


            if (shouldSaveToFile)
            {
                var dluznicyToSave = new List<string>();

                foreach (var dluznik in Dluznicy)
                {
                    dluznicyToSave.Add(dluznik.ToString());
                }



                File.Delete(Filename);
                File.WriteAllLines(Filename, dluznicyToSave);

            }






        }

        public List<string> ListBorrowers()
        {
            var borrwersString = new List<string>();
            var indexer = 1;

            foreach(var dluznik in Dluznicy)
            {
                var borrwerString = indexer + ". " + dluznik.Name + " - " + dluznik.Amount + " zł";
                indexer++;
                borrwersString.Add(borrwerString);

            }
            return borrwersString;
            
        }


    }
}