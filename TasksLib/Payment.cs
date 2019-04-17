using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksLib
{
    public delegate decimal CalcInterest(decimal amount);
    public delegate void Overpaid(object sender, decimal amount);

    public class Payment:ToDoItem
    {
        public decimal  Amount { get; set; }

        public Payment(string title, decimal amount) : base(title)
        {
            Amount = amount;
        }

        public void Refund(decimal amount)
        {
            Amount -= amount;
            if (OnPaid != null)
            {
                OnPaid(this, new EventArgs());
            }
            if(Amount<0 && OnOverPaid != null)
            {
                OnOverPaid(this, amount);
            }
        }

        public CalcInterest calculator;
        public event Overpaid OnOverPaid;
        public event EventHandler OnPaid;

        public void Interest()
        {
            if(calculator!=null)
            Amount += calculator(Amount);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void Interest2(Func<decimal,DateTime,decimal> calculator)
        {
            Amount += calculator(Amount, DueDate);
        }
    }
}
