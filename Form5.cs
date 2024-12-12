using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace raschet
{
    public partial class Form5 : Form
    {
        public static string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=museum.accdb";
        public OleDbConnection myConnection;
        public Form5()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connection);
            myConnection.Open();
        }
        public string name = "";
        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "museumDataSet.GhuestTable". При необходимости она может быть перемещена или удалена.
            this.ghuestTableTableAdapter.Fill(this.museumDataSet.GhuestTable);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "museumDataSet.Eksponats". При необходимости она может быть перемещена или удалена.
            this.eksponatsTableAdapter.Fill(this.museumDataSet.Eksponats);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "museumDataSet.EventsTable". При необходимости она может быть перемещена или удалена.
            this.eventsTableTableAdapter.Fill(this.museumDataSet.EventsTable);
            Start();
            button5.Visible = false;
            listBox3.Visible = false;
        }
        public void Start()
        {
            name = Form2.nameEvent;
            label1.Text = name;
            string query = "SELECT eventTime FROM EventsTable WHERE eventName=" + "('" + name + "')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            string time = command.ExecuteScalar().ToString();
            string query1 = "SELECT data FROM EventsTable WHERE eventName=" + "('" + name + "')";
            OleDbCommand command1 = new OleDbCommand(query1, myConnection);
            string data = command1.ExecuteScalar().ToString();
            label2.Text = data;
            label3.Text = time;
            string query2 = "SELECT ghuestName FROM GhuestTable WHERE eventName=" + "('" + name + "')";
            OleDbCommand command2 = new OleDbCommand(query2, myConnection);
            OleDbDataReader reader = command2.ExecuteReader();
            listBox1.Items.Clear();
            while (reader.Read())
            {
                listBox1.Items.Add(reader[0].ToString());
            }
            reader.Close();
            string query3 = "SELECT eksponatName FROM Eksponats ORDER BY Код";
            OleDbCommand command3 = new OleDbCommand(query3, myConnection);
            OleDbDataReader reader3 = command3.ExecuteReader();
            listBox3.Items.Clear();
            while (reader3.Read())
            {
                listBox3.Items.Add(reader3[0].ToString());
            }
            reader3.Close();
        }
        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                string guestName = textBox1.Text;
                string query = "INSERT INTO GhuestTable ([ghuestName],[eventName]) VALUES " + "('" + guestName + "','" + name + "')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
                Start();
            }
        }


        public void Del1()
        {
            try
            {
                string name = listBox1.SelectedItem.ToString();
                string quare = " DELETE FROM  GhuestTable WHERE[ghuestName] = " + "('" + name + "')";
                OleDbCommand command = new OleDbCommand(quare, myConnection);
                command.ExecuteNonQuery();
                this.ghuestTableTableAdapter.Fill(this.museumDataSet.GhuestTable);
                Start();
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Del1();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button5.Visible = true;
            listBox3.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Visible = false;
            listBox3.Visible = false;
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string choice = listBox3.SelectedItem.ToString();
            listBox2.Items.Add(choice);
        }
        public void Del2()
        {
            string choice = listBox2.SelectedItem.ToString();
            listBox2.Items.Remove(choice);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Del2();
        }
    }
}
