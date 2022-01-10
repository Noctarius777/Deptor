using System;
using System.Collections.Generic;
using System.IO;

namespace Debtor.Core
{
    public class BorrowerManager
    {
        private List<Borrower> Borrowers { get; set; }    

        private string FileName { get; set; } = "borrowers.txt";

       
        public BorrowerManager()  
        {
            Borrowers = new List<Borrower>();

            if (!File.Exists(FileName))  

            {
                return;
            }

            var fileLines = File.ReadAllLines(FileName);

            foreach (var line in fileLines)
            {
                var sortedLines = line.Split(';');               
                  
                    if (decimal.TryParse(sortedLines[1], out var amountInDecimal)) 
                    {

                        AddBorrower(sortedLines[0], amountInDecimal, false);
                  
                    }  
            }

        }

        public void AddBorrower(string name, decimal amount, bool shouldSaveToFile = true)
        {
            var borrower = new Borrower   
            {
                Name = name,             
                Amount = amount
            };                              
            Borrowers.Add(borrower); 
            
            if (shouldSaveToFile)  
            {
                File.AppendAllLines(FileName, new List<string> { borrower.ToString()});
            }
        }

        public void RemoveBorrower(string name, bool shouldSaveToFile = true) 
        {
            foreach (var borrower in Borrowers)
            {
                if (borrower.Name == name)
                {
                    Borrowers.Remove(borrower);
                    break;  
                }
            }
            if(shouldSaveToFile)
            {
                var borrowersToSave = new List<string>();
                foreach (var borrower in Borrowers)
                {
                    borrowersToSave.Add(borrower.ToString());
                }
                File.Delete(FileName);
                File.WriteAllLines(FileName,borrowersToSave );
            }
        }

        public List<string> ListBorrowers()  
        {
            var borrowersStrings = new List<string>(); 
            var indexer = 1;
                                 

            foreach (var borrower in Borrowers) 
            {
                var borrowerString = indexer + "." + borrower.Name + " - " + borrower.Amount + " zł."; 
                indexer++;
                borrowersStrings.Add(borrowerString); 
            }
            return borrowersStrings;
        }
        public decimal AllAmounts()
        {
            decimal AllAmounts = 0;
            
            foreach (var borrower in Borrowers) 
            {
                
                AllAmounts = AllAmounts+(borrower.Amount); 
                                              
            }

            return AllAmounts;
        }

        public void ReduceAmount(string name, decimal amount, bool shouldSaveToFile = true)  
        {
            foreach (var borrower in Borrowers)
            {
                if (borrower.Name == name)
                {
                    borrower.Amount= borrower.Amount + amount;

                    break;  
                }
            }
            if (shouldSaveToFile)
            {
                var borrowersToSave = new List<string>();
                foreach (var borrower in Borrowers)
                {
                    borrowersToSave.Add(borrower.ToString());
                }
                File.Delete(FileName);
                File.WriteAllLines(FileName, borrowersToSave);
            }
        }



    }
}
