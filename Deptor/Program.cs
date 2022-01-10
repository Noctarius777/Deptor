using System;

namespace Debtor
{
    class Program
    {
        static void Main(string[] args)
        {
            var deptorApp = new DebtorApp();
            deptorApp.Introduce();
            deptorApp.AskForAction();
            
        }
    }
}
