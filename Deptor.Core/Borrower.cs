using System;

namespace Debtor.Core
{
    public class Borrower // public
    {
        public string Name { get; set; }

        public decimal Amount { get; set; }  

        public override string ToString()
        {
            return Name + ";" + Amount.ToString();

        }

    }
}
