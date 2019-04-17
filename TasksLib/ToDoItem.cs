using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksLib
{
    //private, internal, public
    public class ToDoItem
    {
        static int LastId = 0;

        protected int ItemID;
        protected string title;
        public DateTime DueDate { get; set; }
        public DateTime? StartDate { get; set; }

        public ToDoItem()
        {
            title = "Nothing to do";
            DueDate = DateTime.Now;
            NewId();
            ItemID = LastId;
            StartDate = null;
        }

        public ToDoItem(string title)
        {
            this.title = title;
            DueDate = DateTime.Now;
            NewId();
            ItemID = LastId;
            StartDate = null;
        }

        public ToDoItem(string title, DateTime duedate)
        {
            this.title = title;
            DueDate = duedate;
            NewId();
            ItemID = LastId;
            StartDate = null;
        }

        public string ItemInfo()
        {
            string info = $"Id: {ItemID}, {Title}, DueDate:{DueDate}, completed: {Completed},Task started at {StartDate}";
            return info;
        }

        public void CompleteTask()
        {
            Completed = true;
        }

        private static int NewId()
        {
            return ++LastId;
        }

        public static int ToDoCount()
        {
            return LastId;
        }

        public string Title
        {
            get { return title; }
            set
            {
                if (value.Length == 0)
                {
                    throw new FormatException("Ciąg zerowej długości.");
                }
                title = value;
            }
        }

        public virtual string CompleteInfo()
        {
            return $"Todo: {title}, complete: {Completed}";
        }

        public bool Completed { get; private set; }

        public override string ToString()
        {
            return ItemInfo();
        }
    }
    
    public class Arithmetics
    {
        public static decimal AddNumbers(string nr1, string nr2)
        {
            var number1 = decimal.Parse(nr1);
            var number2 = decimal.Parse(nr2);
            return number1 + number2;
        }

        public static decimal AddNumbers(params decimal[] d_arr)
        {
            decimal return_sum = 0M;
            for(int i = 0; i < d_arr.Length; i++)
            {
                return_sum += d_arr[i];
            }
            return return_sum;
        }
    }


}
