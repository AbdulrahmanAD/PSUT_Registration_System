using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO; 

//
//
//
//
//
// Group members
// Abdulrahman Abudabaseh, Osama Alsarairah
//
//
//
//

namespace visual_project
{
    public partial class Form1 : Form
    {
        SQLiteConnection visual_db;
        public Form1()
        {
            InitializeComponent();
        }
        int sum = 0;
        int num = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            button4.BackColor = Color.Wheat;
            button1.BackColor = Color.Wheat;
            button2.BackColor = Color.Wheat;
            button3.BackColor = Color.Wheat;
            button5.BackColor = Color.Wheat;
            button6.BackColor = Color.Wheat;
            label11.BackColor = Color.Red;
            button5.BackColor = Color.Wheat;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                visual_db = new SQLiteConnection("Data Source=Student.sqlite; Version=3;");
                visual_db.Open();
                MessageBox.Show("Database connected succesfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM Students";
                SQLiteCommand command = new SQLiteCommand(sql, visual_db);
                SQLiteDataReader reader = command.ExecuteReader();

                SQLiteDataAdapter adap = new SQLiteDataAdapter(sql, visual_db);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Refresh();



                MessageBox.Show("SELECT executed successfully");
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void Add_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                
                Student s = new Student();
                if (textBox1.Text.Length > 0)
                {
                    s.Name = textBox1.Text;
                }
                else
                    s.Name = "-";
                if (int.Parse(textBox6.Text) > 18 && int.Parse(textBox6.Text) < 100)
                    s.Age = int.Parse(textBox6.Text);
                else
                    s.Age = 18;

                if (radioButton1.Checked)
                    s.Major = "CS";
                else if (radioButton2.Checked)
                    s.Major = "SE";
                else if (radioButton3.Checked)
                    s.Major = "GD";
                else s.Major = "-";


                s.First = int.Parse(numericUpDown1.Value.ToString());

                s.Second = int.Parse(numericUpDown2.Value.ToString());

                s.Final = int.Parse(numericUpDown3.Value.ToString());

                s.Total = s.First + s.Second + s.Final;

                sum += s.Total;

                string sql = $"INSERT INTO Students (Name, Age, Major, First, Second, Final, Total) values ('{s.Name}', '{s.Age}', '{s.Major}', '{s.First}', '{s.Second}', '{s.Final}', '{s.Total}')";
                SQLiteCommand command = new SQLiteCommand(sql, visual_db);
                int x = command.ExecuteNonQuery();
                MessageBox.Show($"{x} Inserted successfully");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Student student = new Student();

                student.First = int.Parse(numericUpDown4.Value.ToString());

                student.Second = int.Parse(numericUpDown5.Value.ToString());

                student.Final = int.Parse(numericUpDown6.Value.ToString());

                student.Total = student.First + student.Second + student.Final;
                string sql = $"UPDATE Students SET First = '{student.First}', Second ='{student.Second}', Final='{student.Final}', Total='{student.Total}' WHERE ID='{int.Parse(textBox10.Text)}'";
                SQLiteCommand command = new SQLiteCommand(sql, visual_db);
                int x = command.ExecuteNonQuery();
                MessageBox.Show($"{x} Edited successfully");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            { 
                string sql = $"DELETE FROM Students WHERE ID='{int.Parse(textBox10.Text)}'";
                SQLiteCommand command = new SQLiteCommand(sql, visual_db);
                int x = command.ExecuteNonQuery();
                MessageBox.Show($"{x} Deleted successfully");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            visual_db.Close();
            Application.Exit();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown3.Maximum = 40;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                var reader = new StreamReader("Students_from_db.txt");
                int i = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    string[] sp = line.Split(',');

                    string name = sp[0];
                    int age = int.Parse(sp[1]);
                    string major = sp[2];
                    int first = int.Parse(sp[3]);
                    int second = int.Parse(sp[4]);
                    int final = int.Parse(sp[5]);

                    int total = first + second + final;
                    string sql = $"INSERT INTO Students (Name, Age, Major, First, Second, Final, Total) values ('{name}', '{age}', '{major}', '{first}', '{second}', '{final}', '{total}')";
                    SQLiteCommand command = new SQLiteCommand(sql, visual_db);
                    int x = command.ExecuteNonQuery();
                    i++;
                }
                MessageBox.Show($"{i} Students where inserted successfuly from Students_Data.txt");
                reader.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM Students";
            SQLiteCommand command = new SQLiteCommand(sql, visual_db);
            int x = command.ExecuteNonQuery();
            MessageBox.Show($"{x} Deleted successfully");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                var reader = new StreamReader("Students_from_db.txt");
                var writer = new StreamWriter("Students_Data.txt");
                int i = 0;
                while (!reader.EndOfStream)
                {
                    string s = reader.ReadLine();
                    writer.WriteLine(s);

                }
                MessageBox.Show("Data inserted successfuly");
                reader.Close();
                writer.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
