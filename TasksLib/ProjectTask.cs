using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksLib
{

    public class ProjectTask: ToDoItem
    {
        public ShortProject Project { get; set; }
        public TaskNumber TaskNo { get; set; }
        public DateTime? EndDate { get; set; }
        public TaskStatus Status { get; set; }

        public ProjectTask():base()
        {
            Status = TaskStatus.Plan;
        }

        public ProjectTask(string title):base()
        {
            this.title = title;
            Status = TaskStatus.Plan;
        }

        public new string ItemInfo()
        {
            return $"Project {Project}, taskno: {TaskNo}, status: {Status}";
        }

        public override string CompleteInfo()
        {
            return "Project task " + base.CompleteInfo();
        }

        public override string ToString()
        {
            return ItemInfo();
        }

}
}

   /* public sealed class SpecialProjectTask
    {


        public new string CompleteInfo()
        {
            return base.CompleteInfo();
        }
    }*/
    

