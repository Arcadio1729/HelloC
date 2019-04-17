using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TasksLib;
using System.IO;

namespace WPFTaskClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ToDoManager todomng = new ToDoManager();

        string filepath = @"C:\Users\Student\Desktop\Niezakonczone.txt";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
           InfoLabel.Content = InfoText.Text;
           
        }

        private void NewTaskButton_Click(object sender, RoutedEventArgs e)
        {
            TaskDialog taskDialog = new TaskDialog();
            bool? wynikDialog = taskDialog.ShowDialog();
            if (wynikDialog.Value)
            {
                todomng.AddTask(taskDialog.titleBox.Text,
                    taskDialog.DueDatePicker.SelectedDate.Value); 
            }
            taskList.ItemsSource = todomng.TaskList().Select(t=>t.Title);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string info = "";
            foreach(var item in todomng.TaskList())
            {
                info += item.ItemInfo() + System.Environment.NewLine;
            }

            MessageBox.Show(info,"Lista Zadań",
                MessageBoxButton.OK,MessageBoxImage.Information);
        }

        private void TaskList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            File.AppendAllLines(filepath, todomng.TaskList().Select(t=>t.Title));
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string info = File.ReadAllText(filepath);
            MessageBox.Show(info);
        }
    }
}
