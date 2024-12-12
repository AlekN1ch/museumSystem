using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace raschet
{
    public partial class Form1 : Form
    {
        public static string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Autorization.accdb";
        public OleDbConnection myConnection;
        public Form1()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connection);
            myConnection.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "autorizationDataSet.autorizationTable". При необходимости она может быть перемещена или удалена.
            this.autorizationTableTableAdapter.Fill(this.autorizationDataSet.autorizationTable);
            Start();
            button1.Visible = true;
            button2.Visible = false;
        }
        public void Start()
        {
            string query1 = "SELECT login FROM autorizationTable ORDER BY Код";
            OleDbCommand command1 = new OleDbCommand(query1, myConnection);
            OleDbDataReader reade1r = command1.ExecuteReader();
            listBox1.Items.Clear();
            while (reade1r.Read())
            {
                listBox1.Items.Add(reade1r[0].ToString());
            }
            reade1r.Close();
            string query10 = "SELECT password FROM autorizationTable ORDER BY Код";
            OleDbCommand command10 = new OleDbCommand(query10, myConnection);
            OleDbDataReader reade10r = command10.ExecuteReader();
            listBox2.Items.Clear();
            while (reade10r.Read())
            {
                listBox2.Items.Add(reade10r[0].ToString());
            }
            reade10r.Close();

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool acces = false;
            bool accesPas = false;
            foreach (var item in listBox1.Items)
            {
                if (textBox1.Text == item.ToString())
                {
                    acces = true;
                    foreach (var item1 in listBox2.Items)
                    {
                        if (textBox2.Text == item1.ToString())
                        {
                            accesPas = true;
                        }

                    }

                }

            }
            if (acces && accesPas)
            {
                MessageBox.Show("Вход успешно совершен");
                Form2 f2 = new Form2();
                f2.Show();
            }
            else
            {
                MessageBox.Show("Неверные данные");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool acces = true;

            string newLogin = textBox1.Text;
            string newPassword = textBox2.Text;
            foreach (var item in listBox1.Items)
            {
                if (textBox1.Text == item.ToString())
                {
                    acces = false;
                }

            }
            if (acces)
            {
                MessageBox.Show("Регистрация прошла успешно");
                string quary = "INSERT INTO autorizationTable([login],[password]) VALUES" + "('" + newLogin + "','" + newPassword + "')";
                OleDbCommand command = new OleDbCommand(quary, myConnection);
                command.ExecuteNonQuery();
                Start();
                button2.Visible = false;
                button1.Visible = true;
                
            }
            else
            {
                MessageBox.Show("Данный логин уже зарегистрирован");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            button1.Visible = false;
            label5.Visible = true;
            label2.Visible = false;
            label6.Visible = true;
            label1.Visible = false;
            
        }

        private void label6_Click(object sender, EventArgs e)
        {
            label6.Visible = false;
            label2.Visible = true;
            label5.Visible = false;
            label1.Visible = true;
            button1.Visible = true;
            button2.Visible = false;
        }
    }
}
