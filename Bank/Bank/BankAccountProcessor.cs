namespace Bank
{
    using System;

    namespace Bank
    {
        class BankAccountProcessor
        {
            static void Main(string[] args)
            {
                try
                {
                    decimal initAmount = decimal.Parse(Console.ReadLine());
                    BankAccount account = new BankAccount(initAmount);

                    Console.WriteLine("Enter the deposit amount: ");
                    decimal depositAmount = decimal.Parse(Console.ReadLine());
                    account.Deposit(depositAmount);
                    Console.WriteLine("Amount after deposit: " + account.Amount);

                    Console.WriteLine("Enter the withdrawal amount: ");
                    decimal withdrawAmount = decimal.Parse(Console.ReadLine());
                    account.Withdraw(withdrawAmount);
                    Console.WriteLine("Amount after withdrawal: " + account.Amount);
                }
               
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
               
            }
        }
    }
}