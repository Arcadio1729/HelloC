using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace DemoAsync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LongRun_Click(object sender, RoutedEventArgs e)
        {
            //Task task1 = new Task(()=>LongRunTask());
            //task1.Start();

            var task1 = Task.Run(()=>LongRunTask());

            Task[] tasks = new Task[3]
            {
                Task.Run(()=>LongRunTask()),
                Task.Run(()=>LongRunTask()),
                Task.Run(()=>LongRunTask())
            };


            Task.WaitAll(tasks);

        }

        private void LongRunTask()
        {
            MessageBox.Show("rozpoczynam");
            Thread.Sleep(5000);
            MessageBox.Show("Koniec liczenia");
        }

        public string LongRunTaks2()
        {
            Thread.Sleep(12500);
            return "Ended";
        }

        public async Task<string> GetData()
        {
            Task<string> task1 = Task.Run<string>(() => LongRunTaks2());
            return await task1;
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Task<string> task1 = Task.Run<string>(()=>LongRunTaks2());
            infoText.Text = await task1;
            MessageBox.Show("Zakończono");

        }

        private void InfoText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private async void GetData_Click(object sender, RoutedEventArgs e)
        {
            string info = await GetData();
            infoText.Text = info;
        }

        private void Dispatcher_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                infoText.Dispatcher.BeginInvoke(
                    new Action(() =>
                    {
                        infoText.Text = "Start";
                    }));

                Thread.Sleep(2000);
            });
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;

            var task1 = Task.Run(() => LongRunTaks2(),ct);
            cts.Cancel();
        }

        private void doWork(CancellationToken token)
        {
            Thread.Sleep(4000);
            token.ThrowIfCancellationRequested();
        }
    }
}
