using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TasksLib;

namespace TaskClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ToDoManager mng1 = new ToDoManager();
                ITaskManager itm = mng1;
                mng1.AddTask("Todo 1", DateTime.Now);
                mng1.AddPayment("Payment 1", DateTime.Now, 111.23M);
                mng1.AddProjectTask("Project Task 1", "Demo Project");
                Console.WriteLine("Lista zadań");
                foreach(var item in mng1.TaskList())
                {
                    Console.WriteLine(item.ItemInfo());
                }

                Console.WriteLine("List płatności");
                foreach(var item in mng1.Payments)
                {
                    Console.WriteLine(item.ItemInfo());
                }
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                Console.Read();
            }
        }
        static decimal Calculator(decimal amount)
        {
            return amount * 0.2M;
        }
        static decimal Calculator(decimal amount,DateTime d)
        {
            return amount * 0.2M;
        }
        static void P1_OnPaid(object sender, EventArgs e)
        {
            Console.WriteLine("Wypłacono kwotę");
        }
        static void P1_OnOverPaid(object sender,decimal am)
        {
            Console.WriteLine($"Wystąpiło zdarzenie przekroczenia salda. Kwota: {am}");
        }

        static void obslugazadan4()
        {
            Payment p1 = new Payment("Rata1", 234M);
            p1.DueDate = DateTime.Now.AddDays(-3);

            p1.calculator += new CalcInterest(Calculator);
            p1.OnOverPaid += P1_OnOverPaid;
            p1.OnOverPaid += (S, a) => Console.WriteLine(a);
            p1.calculator += am =>
            {
                decimal rate = 0.2M;
                return am * rate;
            };


            p1.calculator += am => am * 0.2M;
            p1.OnPaid += P1_OnPaid;
            p1.OnPaid += (o, ea) => Console.WriteLine("Zdarzenie spłaty");

            p1.Interest();
            p1.Interest2(Calculator);
            p1.Interest2((am, dd) => am * 0.2M);

            Console.WriteLine(p1.Amount);
        }
        static void obslugazadan3()
        {
            TaskStatus ts = TaskStatus.Close;
            Console.WriteLine(ts);
            TaskNumber tn1 = new TaskNumber();
            TaskNumber tn2;
            TaskNumber tn3 = new TaskNumber("Demo", 4);
            Console.WriteLine(tn3);
            TaskNumber nr4 = "Test/12/3";
            TaskNumber nr5 = tn3 + 5;
            Console.WriteLine(nr5);
        }
        static void obslugazadan2()
        {
            ToDoItem td1 = new ToDoItem("Read Pan Tadeusz");
            ToDoItem td2 = new ToDoItem("Go on tutorials", DateTime.Now.AddMinutes(112));

            ProjectTask pt1 = new ProjectTask("Task 1");
           // pt1.Project = "Testing";
            pt1.StartDate = DateTime.Now.AddDays(2);
            pt1.DueDate = DateTime.Now.AddDays(30);
            //pt1.Status = "Plan";

            td1 = pt1;

            ShortProject sp1 = new ShortProject();

            sp1.ProjectName = "Test short project";
            sp1.DateFrom = DateTime.Parse("2017-07-17");
            sp1.DateTo = DateTime.Parse("2019-09-01");

            Console.WriteLine(sp1.ProjectInfo());
            Console.WriteLine(sp1.ProjectStatus());

            ProjectBase pb1 = sp1;

            Console.WriteLine(td1.ItemInfo());
            Console.WriteLine(pt1.ItemInfo());
            Console.WriteLine();
            Console.WriteLine(td1.CompleteInfo());
            Console.WriteLine(pt1.CompleteInfo());

        }
        static void obslugazadan()
        {
            ToDoItem td1 = new ToDoItem("Read Pan Tadeusz");
            ToDoItem td2 = new ToDoItem("Go on tutors", DateTime.Now.AddMinutes(112));

            ProjectTask pt1 = new ProjectTask("Task 1");
            pt1.StartDate = DateTime.Now;
            Console.WriteLine(td1.ItemInfo());
            Console.WriteLine(td2.ItemInfo());
            Console.WriteLine(pt1.ItemInfo());
            Console.WriteLine($"Liczba obiektów: {ToDoItem.ToDoCount()}");

            //ToDoItem td3 = td2;
            //td3.Title = "";
            td1.StartDate = DateTime.Now;
            //DateTime date = (DateTime)td3.StartDate;
            Console.WriteLine(td1.ItemInfo());
        }
        static void PrzeciazeniaDemo()
        {
            decimal[] numbers = new decimal[3];
            //Array nr = Array.CreateInstance(typeof(decimal), 10);
            decimal[] numbersy = { 12.11M, 234M, 49.30M };
            Console.WriteLine(Arithmetics.AddNumbers(123, 32, 432, 123, 54, 192, 30));
            Console.Read();
        }
    }
}
