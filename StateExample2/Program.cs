using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateExample2
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    interface ATMState
    {
        void InsertCard();
        void EjectCard();
        void InsertPin(int pin);
        void RequestCash(int cash);
    }

    class ATMMachine
    {
        public ATMState hasCard { get; protected set; }
        public ATMState noCard { get; protected set; }
        public ATMState hasCorrectPin { get; protected set; }
        public ATMState atmOutofMoney { get; protected set; }     

        public ATMState atmState { get; protected set; }

        public int cashInMachine = 2000;
        public bool correntPinEntered = false;

        public ATMMachine()
        {
            hasCard = new HasCard(this);
            noCard = new NoCard(this);
            hasCorrectPin = new HasPin(this);
            atmOutofMoney = new NoCash(this);

            atmState = noCard;
            if (cashInMachine<0)
            {
                atmState = atmOutofMoney;
            }
        }

        public void SetATMState(ATMState state)
        {
            atmState = state;
        }

        public void SetCachInATM(int amount)
        {
            cashInMachine = amount;
        }

        public void EjectCard()
        {
            atmState.EjectCard();
        }

        public void InsertCard()
        {
            atmState.InsertCard();
        }

        public void InsertPin(int pin)
        {
            atmState.InsertPin(pin);
        }

        public void RequestCash(int cash)
        {
            atmState.RequestCash(cash);
        }

        public ATMState GetCurrentState()
        {
            return atmState;
        }

        public int GetCashInMachine()
        {
            return cashInMachine;
        }
    }

    class HasCard : ATMState
    {
        public ATMMachine atm;

        public HasCard(ATMMachine _atm)
        {
            atm = _atm;
        }

        public void EjectCard()
        {
            Console.WriteLine("Card Ejected");
            atm.SetATMState(atm.noCard);
        }

        public void InsertCard()
        {
            Console.WriteLine("You can't insert one than more card");            
        }

        public void InsertPin(int pin)
        {
            if (pin == 123456)
            {
                Console.WriteLine("Corrent pin entered");
                atm.correntPinEntered = true;
                atm.SetATMState(atm.hasCorrectPin);
            }
            else
            {
                Console.WriteLine("Wrong pin entered");
                atm.correntPinEntered = false;
                Console.WriteLine("Card Ejected");
                atm.SetATMState(atm.noCard);
            }            
        }
        public void RequestCash(int cash)
        {
            Console.WriteLine("Enter pin first");
        }
    }

    class NoCard : ATMState
    {
        public ATMMachine atm;
        public NoCard(ATMMachine _atm)
        {
            atm = _atm;
        }
        public void EjectCard()
        {
            Console.WriteLine("Enter a card first");            
        }

        public void InsertCard()
        {
            Console.WriteLine("Card inserted");
            atm.SetATMState(atm.hasCard);
        }

        public void InsertPin(int pin)
        {
            Console.WriteLine("Enter a card first");
        }

        public void RequestCash(int cash)
        {
            Console.WriteLine("Enter a card first");
        }
    }

    class HasPin : ATMState
    {
        public ATMMachine atm;
        public HasPin(ATMMachine _atm)
        {
            atm = _atm;
        }

        public void EjectCard()
        {
            Console.WriteLine("Card Ejected");
            atm.SetATMState(atm.noCard);
        }

        public void InsertCard()
        {
            Console.WriteLine("You can't insert one than more card");
        }

        public void InsertPin(int pin)
        {
            Console.WriteLine("Pin already entered");
        }

        public void RequestCash(int cash)
        {
            if (cash>atm.cashInMachine)
            {
                Console.WriteLine("Don't have enough cash");
                atm.SetATMState(atm.noCard);
                Console.WriteLine("Card Ejected");
            }
            else
            {
                Console.WriteLine(cash + "provided by ATM");
                atm.cashInMachine -= cash;
                atm.SetATMState(atm.noCard);
                if (atm.cashInMachine<=0)
                {
                    atm.SetATMState(atm.atmOutofMoney);
                }
                Console.WriteLine("Card Ejected");
            }
        }
    }

    class NoCash : ATMState
    {
        public ATMMachine atm;
        public NoCash(ATMMachine _atm)
        {
            atm = _atm;
        }
        public void EjectCard()
        {
            Console.WriteLine("There are no money");
        }

        public void InsertCard()
        {
            Console.WriteLine("There are no money");
        }

        public void InsertPin(int pin)
        {
            Console.WriteLine("There are no money");
        }

        public void RequestCash(int cash)
        {
            Console.WriteLine("There are no money");
        }
    }
}
