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
using System.Data;
using System.Data.SqlClient;

namespace DemoDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string cnnStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=people;Integrated Security=True";
        peopleEntities db = new peopleEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DemoADO_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection cnnSql = new SqlConnection(cnnStr);
            string cmdStr = "INSERT INTO People(FirstName,LastName,Age) VALUES('John','Wayne',111)";

            SqlCommand cmdSql = new SqlCommand(cmdStr, cnnSql);
            cnnSql.Open();
            cmdSql.ExecuteNonQuery();
            cnnSql.Close();

        }

        private void ReadData_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cnnSql = new SqlConnection(cnnStr);
            string cmdStr = "Select * From People";
            SqlCommand cmdSql = new SqlCommand(cmdStr, cnnSql);
            cnnSql.Open();
            SqlDataReader dr = cmdSql.ExecuteReader();
            string wynik = "";
            while (dr.Read())
            {
                wynik += $"ID: {dr["PersonID"]}, {dr["FirstName"]},{dr["LastName"]}, Age: {dr["Age"]}\n" ;
            }
            dr.Close();
            cnnSql.Close();
            MessageBox.Show(wynik);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cnnSql = new SqlConnection(cnnStr);
            string cmdStr = "Select * From People";
            DataSet ds = new DataSet();
            SqlDataAdapter daSql = new SqlDataAdapter(cmdStr,cnnSql);
            SqlCommandBuilder cmdBuild = new SqlCommandBuilder();

            cmdBuild.DataAdapter = daSql;
            //daSql.SelectCommand = new SqlCommand(cmdStr,cnnSql);
            daSql.UpdateCommand = cmdBuild.GetUpdateCommand();
            daSql.InsertCommand = cmdBuild.GetInsertCommand();
            daSql.DeleteCommand = cmdBuild.GetDeleteCommand();

            daSql.Fill(ds, "People");
            string name = ds.Tables["People"].Rows[1]["LastName"].ToString();
            MessageBox.Show(name);
            string wynik = "";

            for(int i = 0; i < ds.Tables["People"].Rows.Count; i++)
            {
                wynik += $"{ds.Tables["People"].Rows[i]["FirstName"].ToString()}" +
                    $"{ds.Tables["People"].Rows[i]["LastName"].ToString()}"; 
            }

            ds.Tables["People"].Rows[1]["LastName"] = "Nowak";

            daSql.Update(ds,"People");
        }

        private void EFFRead_Click(object sender, RoutedEventArgs e)
        {

            string wynik = "";
            foreach(var item in db.People)
            {
                wynik += $"ID: {item.PersonID}, Name: {item.FirstName},{item.LastName}\n";
            }
            MessageBox.Show(wynik);
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            var wynik = from p in db.People
                        where p.Age >= 100
                        select p;
            string info = "";

            foreach(var item in wynik)
            {
                info += item.FirstName;
            }

            MessageBox.Show(info);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Person newPerson = new Person()
            {
                PersonID = 7,
                FirstName = "Jan",
                LastName = "Komuz",
                Age = 711
            };

            db.People.Add(newPerson);
            var personToUpdate = (from p in db.People
                                 where p.PersonID == 2
                                 select p).Single();

            personToUpdate.FirstName = "Chris";

            db.SaveChanges();
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PhotoContext photosDb = new PhotoContext();
            Photo newPhoto = new Photo()
            {
                Title = "Photo1",
                DateToken = DateTime.Now.AddDays(-30)
            };

            photosDb.Photos.Add(newPhoto);

            photosDb.SaveChanges();
            MessageBox.Show("Done");
        }
    }
}
