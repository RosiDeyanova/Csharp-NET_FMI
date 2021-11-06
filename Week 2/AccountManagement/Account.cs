using System;

namespace AccountManagement
{
    public class Account
    {
        #region Fields
        private DateTime dateCreated;
        private long id;
        private double interestAnnualrate;
        private decimal balance;
        #endregion

        #region Constructors
        public Account()
        {
            DateCreated = DateTime.Now;
            Balance = 0;
            InterestAnnualrate = 0.1;
            Id = 0;

        }
        public Account(DateTime dateCreated, long id, double interestAnnualrate, decimal balance)
        {
            DateCreated = dateCreated;
            Id = id;
            InterestAnnualrate = interestAnnualrate;
            Balance = balance;
        }

        public Account(Account account)
        {
            DateCreated = account.DateCreated;
            Id = account.Id;
            InterestAnnualrate = account.InterestAnnualrate;
            Balance = account.Balance;
        }

        #endregion    

        #region Properties
        public DateTime DateCreated
        {
            get { return dateCreated; }
            set { dateCreated = value != null ? value : DateTime.Now; }
        }

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public double InterestAnnualrate
        {
            get { return interestAnnualrate; }
            set { interestAnnualrate = value > 0 ? value : 0.01; }
        }

        public decimal Balance
        {
            get { return balance; }
            set { balance = value >= 0 ? value : 0; }
        }
        #endregion

        #region Methods
        public decimal Deposit(decimal amount)
        {
            if (amount >= 0)
            {
                Balance += amount;
            }
            else
            {
                Console.WriteLine("The amount can't be negative number");
            }
            return Balance;
        }

        public void Withdraw(decimal amount)
        {
            if (amount >= 0 && Balance - amount >= 0)
            {
                Balance -= amount;
            }
            else
            {
                Console.WriteLine("Error: Can't withdraw that much money!");
            }
        }

        public override string ToString()
        {
            string result = $"Account:\nBalance: {Balance}\nDateCreated:{DateCreated}\nInterestRate: {InterestAnnualrate}";
            return result;
        }
        #endregion 
    }
}