using Debtor.Core;
using System;

namespace Debtor
{
    public class DebtorApp 
    {

        public BorrowerManager BorrowerManager { get; set; } = new BorrowerManager();   



        public void Introduce()
        {
            Console.WriteLine("Witaj w menadżerze dłużników");
        }
        public void AddBorrower()
        {
            Console.WriteLine("Podaj nazwę użytkownika którego chcesz dodać do listy");
            var name = Console.ReadLine();

            System.Console.WriteLine("Podaj kwotę jego długu");
            var value = Console.ReadLine();
            var amountInDecimal = default(decimal); 

            
            while (!decimal.TryParse(value, out amountInDecimal)) 
            {
                Console.WriteLine("Podano niepoprawny format kwoty");
                Console.WriteLine("Podaj kwotę długu");
                value = Console.ReadLine();

            }
            BorrowerManager.AddBorrower(name, amountInDecimal); 
            
        }
        public void DeleteBorrower()
        {
            Console.WriteLine("Podaj nazwę użytkownika którego chcesz usunąć z listy");
            var name = Console.ReadLine();          

            BorrowerManager.RemoveBorrower(name);
        }

        public void ReduceAmmount()
        {
            Console.WriteLine("Podaj nazwę użytkownika któremu chcesz zredukować kwotę długu");
            var name = Console.ReadLine();

            Console.WriteLine("Podaj kwotę o jaką chcesz zmodyfikować dług");
            var amount = Console.ReadLine();
            var amountInDecimal = default(decimal);

            while (!decimal.TryParse(amount, out amountInDecimal)) 
            {
                Console.WriteLine("Podano niepoprawny format kwoty");
                Console.WriteLine("Podaj kwotę o jaką chcesz zmniejszyć dług");
                amount = Console.ReadLine();

            }

           
            BorrowerManager.ReduceAmount(name, amountInDecimal);
        }
        public void ListAllBorrowers()
        {
            Console.WriteLine("Oto lista wszystkich dłużników:");
           foreach (var borrower in BorrowerManager.ListBorrowers())  
            {
                Console.WriteLine(borrower);  
            }

            Console.WriteLine("Oto suma wszystkich długów:" + (BorrowerManager.AllAmounts()));
        }

        public void AskForAction()
        {
            var userAction = default(string);

            
            while (userAction != "exit") 
            { 
            Console.WriteLine("Podaj czynnośc, którą chcesz użyć:");
            Console.WriteLine("add - dodawanie użytykownika");
            Console.WriteLine("del - usuwanie użytykownika");
            Console.WriteLine("reduce - zmniejszenie kwoty długu");
            Console.WriteLine("list - wypisywanie listy użytykowników");
            Console.WriteLine("exit - zakończzenie programu");


            userAction = Console.ReadLine();
            userAction = userAction.ToLower(); 

                switch (userAction)
                {
                    case "add":
                        AddBorrower();
                        break;
                    case "del":
                        DeleteBorrower();
                        break;
                    case "reduce":
                        ReduceAmmount();
                        break;
                
                      
                    case "list":
                        ListAllBorrowers();
                        break;

                    defalult:
                        Console.WriteLine("Podano złą wartość");
                        break;
                }

                    
            }

        }


    }
}
