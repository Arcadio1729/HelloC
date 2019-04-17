using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksLib
{
    public class ToDoManager : ITaskManager
    {
        List<ToDoItem> todoitems = new List<ToDoItem>();

        public int TaskCount => todoitems.Count;

        public void AddTask(ToDoItem newTask)
        {
            todoitems.Add(newTask);
        }

        public void AddTask(string title, DateTime dueDate)
        {
            ToDoItem newToDo = new ToDoItem(title, dueDate);
            todoitems.Add(newToDo);
        }

        public void AddProjectTask(string title, string projectName)
        {
            ProjectTask newProjectTask = new ProjectTask(title);
            newProjectTask.Project = new ShortProject() { ProjectName = projectName };
            todoitems.Add(newProjectTask);
        }

        public void AddPayment(string title, DateTime dueDate, decimal amount)
        {
            Payment newPayment = new Payment(title, amount);
            newPayment.DueDate = dueDate;
            todoitems.Add(newPayment);
        }

        public IEnumerable<ToDoItem> TaskList()
        {
            return todoitems;
        }

        public IEnumerable<string> UncompletedTasks()
        {
            var wynik = from t in todoitems
                        where t.Completed == false
                        select t.ToString();

            return wynik;
        }

        public IEnumerable<Payment> Payments
        {
            get
            {
                return from p in todoitems
                       where p is Payment
                       select (Payment)p;
            }
        }
    }
}
