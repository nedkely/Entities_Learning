using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Entities_Learning.Databases;
using Entities_Learning.Databases.Tables;

namespace Entities_Learning
{
    public partial class Form1 : Form
    {
        DatabaseContext databaseContext = null;
        Person tbPerson = null;

        public Form1()
        {
            InitializeComponent();
            Open_Connection();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            Display_Personels();
            //tbPerson = new Person(){ Nickname = "farhad_ing", Salary = 3500 };

            //databaseContext.Persons.Add(tbPerson);
            //databaseContext.SaveChanges();
        }

        string _ConnectionString;
        void Open_Connection()
        {
            var ConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ToString();
            _ConnectionString = ConnectionString.ToString();
            databaseContext = new DatabaseContext(ConnectionString);
        }

        private void Display_Personels()
        {
            try
            {
                //databaseContext.Persons.Load();
                //var DataSource = databaseContext.Persons.Local;

                List<Person> people = new List<Person>();
                people = databaseContext.Persons.ToList();

                lstPeople.DataSource = people;
                lstPeople.ValueMember = "Id";
                lstPeople.DisplayMember = "Display";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
            finally 
            {
                databaseContext.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            databaseContext.Dispose();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                databaseContext = new DatabaseContext(_ConnectionString);

                var item = new Person() { Code = 1, Nickname = "farhad", Salary = 3500 };
                databaseContext.Persons.Add(item);
                databaseContext.SaveChanges();             
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
            finally
            {
                databaseContext.Dispose();
            }
        }
    }
}