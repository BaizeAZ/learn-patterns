using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateExample1
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account("HJJ");
            account.Deposit(200);
            account.Deposit(1000);
            account.WithDrow(800);
            account.WithDrow(500);
            account.Deposit(2000);
            Console.ReadKey();
        }
    }
    /// <summary>
    /// Context
    /// </summary>
    class Account
    {
        private AccountState _state;
        private string _owner;

        public Account(string owner)
        {
            _owner = owner;
            _state = new SilverState(0.0,this);
        }
        public string GetOwner
        {
            get { return _owner; }
        }
        public double GetBalance
        {
            get { return _state.Balance; }
        }
        public AccountState State
        {
            get { return _state; }
            set { _state = value; }
        }
        public void Deposit(double amount)
        {
            _state.Deposit(amount);
            Console.WriteLine("Deposited " + amount + "---");
            Console.WriteLine(" Balance = " + this.GetBalance);
            Console.WriteLine(" Status = " + this.State.GetType().Name+"\n");
            
        }
        public void WithDrow(double amount)
        {
            _state.Withdrow(amount);
            Console.WriteLine("Deposited " + amount + "---");
            Console.WriteLine(" Balance = " + this.GetBalance);
            Console.WriteLine(" Status = " + this.State.GetType().Name+"\n");
        }
        public void PayInterest()
        {
            _state.PayInterest();
            Console.WriteLine("Interest Pay---");
            Console.WriteLine(" Balance = " + this.GetBalance);
            Console.WriteLine(" Status = " + this.State.GetType().Name + "\n");
        }
    }
    /// <summary>
    /// BaseState
    /// </summary>
    abstract class AccountState
    {
        protected Account account;
        protected double balance;
        protected double interest;
        protected double lowerLimit;
        protected double upperLimit; 

        public Account Account
        {
            get { return account; }
            set { account = value; }
        }
        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public abstract void Deposit(double amount);
        public abstract void Withdrow(double amount);
        public abstract void PayInterest();
    }

    class RedState : AccountState
    {
        private double _serviceFee;
        public RedState(AccountState state)
        {
            this.balance = state.Balance;
            this.account = state.Account;
            Initialize();
        }
        private void Initialize()
        {
            interest = 0.0;
            lowerLimit = -100.0;
            upperLimit = 0.0;
            _serviceFee = 15.00;
        }
        public override void Deposit(double amount)
        {
            balance += amount;
            StateChangeCheck();
        }
        public override void Withdrow(double amount)
        {
            balance = balance - _serviceFee;
            Console.WriteLine("No funds available for withdrawal!");
        }
        public override void PayInterest()
        {
            // No interest is paid
        }
        private void StateChangeCheck()
        {
            if (balance>upperLimit)
            {
                account.State = new SilverState(this);
            }
        }
    }

    class SilverState:AccountState
    {
        public SilverState(AccountState state): 
            this(state.Balance,state.Account)
        {            
        }
        public SilverState(double balance,Account account)
        {
            this.account = account;
            this.balance = balance;
            Initailize();
        }
        private void Initailize()
        {
            interest = 0.0;
            lowerLimit = 0.0;
            upperLimit = 1000.0;
        }
        public override void Deposit(double amount)
        {
            balance += amount;
            StateChangeCheck();
        }
        public override void Withdrow(double amount)
        {
            balance -= amount;
            StateChangeCheck();
            
        }
        public override void PayInterest()
        {
            balance += balance * interest;
            StateChangeCheck();
        }
        private void StateChangeCheck()
        {
            if (balance<lowerLimit)
            {
                account.State = new RedState(this);
            }
            else if (balance>upperLimit)
            {
                account.State = new GoldState(this);
            }
        }

        class GoldState : AccountState
        {
            public GoldState(AccountState state) 
                : this(state.Balance, state.Account)
            {
            }
            public GoldState(double balance,Account account)
            {
                this.balance = balance;
                this.account = account;

            }
            private void Initialize()
            {
                interest = 0.05;
                lowerLimit = 1000.0;
                upperLimit = 10000000.0;
            }
            public override void Deposit(double amount)
            {
                balance += amount;
                StateChangeCheck();                
            }
            public override void Withdrow(double amount)
            {
                balance -= amount;
                StateChangeCheck();               
            }
            public override void PayInterest()
            {
                balance += balance * interest;
                StateChangeCheck();                
            }
            private void StateChangeCheck()
            {
                if (balance < 0.0)
                {
                    account.State = new RedState(this);
                }
                if (balance<lowerLimit)
                {
                    account.State = new SilverState(this);
                }
            }
        }
    }

    
}
