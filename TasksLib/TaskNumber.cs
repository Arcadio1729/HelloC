using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksLib
{
    public struct TaskNumber
    {
        private string prefix;
        private int number;
        public string suffix { get; set; }

        public TaskNumber(string prefix, int number)
        {
            this.prefix = prefix;
            this.number = number;
            this.suffix = null;
        }

        private string FullNo()
        {
            string nr = $"{prefix}/{number}";
            if (suffix != null)
            {
                nr += $"/{suffix}";
            }
            return $"{prefix}/{number}";
        }

        public override string ToString()
        {
            return FullNo();
        }

        public int nr
        {
            get { return number; }
        }

        public static implicit operator TaskNumber(string strNo)
        {
            return Parse(strNo);
        }

        public static implicit operator String(TaskNumber tn)
        {
            return tn.ToString();
        }

        public static TaskNumber operator +(TaskNumber tn, int num)
        {
            TaskNumber tn1 = new TaskNumber(tn.prefix, tn.number + num);
            tn1.suffix = tn.suffix;
            return tn1;
        }

        public static TaskNumber Parse(string inputString)
        {
            int num = new int();
            if (!inputString.Contains("/"))
            {
                throw new FormatException("Wrong format number");
            }
            int position = inputString.IndexOf("/");
            string prefix = inputString.Substring(0, position);
            string suffix = null;
            int position2 = inputString.IndexOf("/", position + 1);
            if (position2 != -1)
            {
                inputString = inputString.Substring(position + 1);
                position = inputString.IndexOf("/");
                suffix = inputString.Substring(position + 1);
            }
            else
            {
                num = int.Parse(inputString.Substring(position + 1));
            }

            TaskNumber newTaskNumber = new TaskNumber(prefix, num);
            newTaskNumber.suffix = suffix;
            return newTaskNumber;
        }
    }
}
