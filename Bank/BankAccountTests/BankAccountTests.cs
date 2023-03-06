using Bank;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace BankAccountTests
{
    public class BankAccountTests
    {
        private BankAccount bankAccount;

        [SetUp]
        public void Setup()
        {
            this.bankAccount = new BankAccount(1000);
        }

        [TestCase(1000, 1000)]
        [TestCase(0, 0)]
        public void Test_GetAmount_PositiveValue(decimal initialAmount, decimal expectedAmount)
        {
            // Arrange and Act
            bankAccount = new BankAccount(initialAmount);

            var value = bankAccount.Amount;

            // Assert
            Assert.That(value, Is.EqualTo(expectedAmount));
        }

        [TestCase(-1000, "Amount cannot be negative!")]
        public void Test_GetAmount_NegativeValue(decimal initialAmount, string message)
        {
            // Assert
            Assert.That(() => new BankAccount(initialAmount),
                Throws.ArgumentException.With.Message.EqualTo(message));
        }

        [TestCase(1000, 500, 1500)]
        public void Test_Deposit_PositiveValue(decimal initialAmount, decimal deposit, decimal expectedAmount)
        {
            // Arrange
            bankAccount = new BankAccount(initialAmount);

            // Act
            bankAccount.Deposit(deposit);

            // Assert
            Assert.That(bankAccount.Amount, Is.EqualTo(expectedAmount));
        }

        [TestCase(1000, -1000, "Deposit cannot be negative or zero!")]
        [TestCase(1000, 0, "Deposit cannot be negative or zero!")]
        public void Test_Deposit_NegativeValue(decimal initialAmount, decimal deposit, string message)
        {
            // Assert
            Assert.That(() => new BankAccount(initialAmount).Deposit(deposit),
                Throws.ArgumentException.With.Message.EqualTo(message));
        }


        [TestCase(1000, 500, 800, 684.00)]
        [TestCase(2000, 1000, 1500, 1425.00)]
        public void Test_Withdraw_PositiveValue(decimal initialAmount, decimal deposit, decimal withdrawSum, decimal amountTotal)
        {
            // Arrange
            bankAccount = new BankAccount(initialAmount);

            // Act
            bankAccount.Deposit(deposit);
            bankAccount.Withdraw(withdrawSum);
            var value = bankAccount.Amount;

            // Assert
            Assert.That(value, Is.EqualTo(amountTotal));
        }

        [TestCase(1000, 1000, -1000, "Withdrawal cannot be negative or zero!")]
        [TestCase(1000,1000, 0, "Withdrawal cannot be negative or zero!")]
        [TestCase(1000, 1000, 3000, "Withdrawal exceeds account balance!")]
        public void Test_Withdraw_NegativeValue(decimal initialAmount, decimal deposit, decimal withdrawSum, string message)
        {
            // Arrange
            bankAccount = new BankAccount(initialAmount);
            
            // Act
            bankAccount.Deposit(deposit);

            // Assert
            Assert.That(() => bankAccount.Withdraw(withdrawSum),
                Throws.ArgumentException.With.Message.EqualTo(message));
        }
    }
}