namespace Bank
{
    public class BankAccount
    {
        decimal amount;

        public BankAccount(decimal initAmount)
        {
            Amount = initAmount;
        }

        public decimal Amount
        {
            get
            {
                return amount;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Amount cannot be negative!");
                }
                else
                {
                    amount = value;
                }
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit cannot be negative or zero!");
            }
            Amount += amount;
        }

        public void Withdraw(decimal widthdrawSum)
        {
            if (widthdrawSum > amount)
            {
                throw new ArgumentException("Withdrawal exceeds account balance!");
            }
            else if (widthdrawSum <= 0)
            {
                throw new ArgumentException("Withdrawal cannot be negative or zero!");
            }
            else
            {
                decimal fee = widthdrawSum * 0.05m; // Default fee
                
                if (widthdrawSum <= 1000)
                {
                    fee = widthdrawSum * 0.02m;
                }
               
                Amount -= (widthdrawSum + fee);
            }
        }
    }
}
