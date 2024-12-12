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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace raschet
{
    public partial class Form2 : Form
    {
        public static string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=museum.accdb";
        public OleDbConnection myConnection;
        public Form2()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connection);
            myConnection.Open();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            listBox2.Visible = false;
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = true;
            button4.Visible = false;
            label2.BackColor = Color.MediumSeaGreen;
            label1.BackColor = SystemColors.AppWorkspace;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "museumDataSet.Eksponats". При необходимости она может быть перемещена или удалена.
            this.eksponatsTableAdapter.Fill(this.museumDataSet.Eksponats);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "museumDataSet.EventsTable". При необходимости она может быть перемещена или удалена.
            this.eventsTableTableAdapter.Fill(this.museumDataSet.EventsTable);

            listBox1.Visible = true;
            listBox2.Visible = false;
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = true;
            button4.Visible = false;
            label2.BackColor = Color.MediumSeaGreen;
            label1.BackColor = SystemColors.AppWorkspace;
            Filler();
            timer1.Start();
        }
        
        public void Filler()
        {
            string query1 = "SELECT eventName FROM EventsTable ORDER BY Код";
            OleDbCommand command1 = new OleDbCommand(query1, myConnection);
            OleDbDataReader reade1r = command1.ExecuteReader();
           listBox1.Items.Clear();
            while (reade1r.Read())
            {
                listBox1.Items.Add(reade1r[0].ToString());
            }
            reade1r.Close();
            string query10 = "SELECT eksponatName FROM Eksponats ORDER BY Код";
            OleDbCommand command10 = new OleDbCommand(query10, myConnection);
            OleDbDataReader reade10r = command10.ExecuteReader();
            listBox2.Items.Clear();
            while (reade10r.Read())
            {
                listBox2.Items.Add(reade10r[0].ToString());
            }
            reade10r.Close();
            
        }
        private void label1_Click(object sender, EventArgs e)
        {
            listBox2.Visible = true;
            listBox1.Visible = false;
            button2.Visible=true;
            button1.Visible=false;
            button4.Visible = true;
            button3.Visible = false;
            label1.BackColor = SystemColors.ActiveCaption;
            label2.BackColor = SystemColors.AppWorkspace;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
           
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.eksponatsTableAdapter.Fill(this.museumDataSet.Eksponats);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "museumDataSet.EventsTable". При необходимости она может быть перемещена или удалена.
            this.eventsTableTableAdapter.Fill(this.museumDataSet.EventsTable);
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        public static string name, data, time;

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_RightToLeftChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Del1();
        }
        public void Del1()
        {
            try
            {
                string name = listBox1.SelectedItem.ToString();
                string quare = " DELETE FROM  EventsTable WHERE[eventName] = " + "('" + name + "')";
                OleDbCommand command = new OleDbCommand(quare, myConnection);
                command.ExecuteNonQuery();
                this.eventsTableTableAdapter.Fill(this.museumDataSet.EventsTable);
                Filler();
            }
            catch { }
        }
        public void Del2()
        {
            try
            {
                string name = listBox2.SelectedItem.ToString();
                string quare = " DELETE FROM  Eksponats WHERE[eksponatName ] = " + "('" + name + "')";
                OleDbCommand command = new OleDbCommand(quare, myConnection);
                command.ExecuteNonQuery();
                this.eksponatsTableAdapter.Fill(this.museumDataSet.Eksponats);
                Filler();
            }
            catch {}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Del2();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }
        public static string nameEvent;

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.eksponatsTableAdapter.Fill(this.museumDataSet.Eksponats);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "museumDataSet.EventsTable". При необходимости она может быть перемещена или удалена.
            this.eventsTableTableAdapter.Fill(this.museumDataSet.EventsTable);
            Filler() ;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            nameEvent = listBox1.SelectedItem.ToString();
            Form5 form5 = new Form5();
            form5.ShowDialog();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            

        }
    }
}
