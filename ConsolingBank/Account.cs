using System;

namespace ConsolingBank
{
    public class Account
    {
        private double _balance;
        private const double Rate = 0.035;

        public Account(string name, int accountNumber, double balance)
        {
            Name = name;
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public int AccountNumber { get; }
        public double Balance
        {
            get => _balance;
            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("The balance can not be set to an amount less than 0.");
                }
                _balance = value;
            }
        }
        public string Name { get; }

        public double AddInterest() => Balance *= (1 + Rate);

        public double Deposit(double amount)
        {
            if (amount < 0)
            {
                throw new InvalidOperationException("The amount can not be less than 0.");
            }

            return Balance += amount;
        }

        public void DisplayAccount()
        {
            Console.WriteLine($"{AccountNumber}\t{Name}\t{_balance:c}");
        }

        public double Withdraw(double amount, double fee)
        {
            if (_balance > amount + fee || 0 > amount + fee)
            {
                return Balance -= (amount + fee);
            }
            else
            {
                throw new InvalidOperationException("Manage your account wisely so you do not overdraw.");
            }
        }
    }
}