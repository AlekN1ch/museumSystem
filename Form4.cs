using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace raschet
{
    public partial class Form4 : Form
    {
        public static string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=museum.accdb";
        public OleDbConnection myConnection;
        public string data;
        public Form4()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connection);
            myConnection.Open();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string data= textBox2.Text;
            string time = textBox3.Text;
            string query = "INSERT INTO EventsTable ([data],[eventTime],[eventName]) VALUES " + "('" + data + "','" + time + "','" + name + "')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
           
            this.Close();

        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "museumDataSet.EventsTable". При необходимости она может быть перемещена или удалена.
            this.eventsTableTableAdapter.Fill(this.museumDataSet.EventsTable);

        }
    }
}
