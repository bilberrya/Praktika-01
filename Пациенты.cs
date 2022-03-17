using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab
{
    public partial class Пациенты : Form
    {
        int r = 0, s, p;
        string ConnStr = @"Data Source=sql;Initial Catalog='44-Практика-Иконникова А.В.-2022';Integrated Security=True";
        public Пациенты()
        {
            InitializeComponent();
            FillUsers();
        }

        private void FillUsers()
        {
            string SqlText = null;
            if (MyClass.dolgnost == "lab")
            {
                if (p == 0)
                {
                    if (s == 0)
                        SqlText = "SELECT id, name, gender, age FROM [Users]";
                    else if (s == 1)
                        SqlText = "SELECT id, name, gender, age FROM [Users] order by name asc";
                    else if (s == 2)
                        SqlText = "SELECT id, name, gender, age FROM [Users] order by name desc";
                }
                else if (p == 1)
                {
                    if (s == 0)
                        SqlText = "SELECT id, name, gender, age FROM [Users] where age < 18";
                    else if (s == 1)
                        SqlText = "SELECT id, name, gender, age FROM [Users] where age < 18 order by name asc";
                    else if (s == 2)
                        SqlText = "SELECT id, name, gender, age FROM [Users] where age < 18 order by name desc";
                }
                else if (p == 2)
                {
                    if (s == 0)
                        SqlText = "SELECT id, name, gender, age FROM [Users] where age >= 18 and age < 45";
                    else if (s == 1)
                        SqlText = "SELECT id, name, gender, age FROM [Users] where age >= 18 and age < 45 order by name asc";
                    else if (s == 2)
                        SqlText = "SELECT id, name, gender, age FROM [Users] where age >= 18 and age < 45 order by name desc";
                }
                else if (p == 3)
                {
                    if (s == 0)
                        SqlText = "SELECT id, name, gender, age FROM [Users] where age >= 45";
                    else if (s == 1)
                        SqlText = "SELECT id, name, gender, age FROM [Users] where age >= 45 order by name asc";
                    else if (s == 2)
                        SqlText = "SELECT id, name, gender, age FROM [Users] where age >= 45 order by name desc";
                }
                
            }
            else if (MyClass.dolgnost == "admin")
            {
                if (p == 0)
                {
                    if (s == 0)
                        SqlText = "SELECT * FROM [Users]";
                    else if (s == 1)
                        SqlText = "SELECT * FROM [Users] order by name asc";
                    else if (s == 2)
                        SqlText = "SELECT * FROM [Users] order by name desc";
                }
                else if (p == 1)
                {
                    if (s == 0)
                        SqlText = "SELECT * FROM [Users] where age < 18";
                    else if (s == 1)
                        SqlText = "SELECT * FROM [Users] where age < 18 order by name asc";
                    else if (s == 2)
                        SqlText = "SELECT * FROM [Users] where age < 18 order by name desc";
                }
                else if (p == 2)
                {
                    if (s == 0)
                        SqlText = "SELECT * FROM [Users] where age >= 18 and age < 45";
                    else if (s == 1)
                        SqlText = "SELECT * FROM [Users] where age >= 18 and age < 45 order by name asc";
                    else if (s == 2)
                        SqlText = "SELECT * FROM [Users] where age >= 18 and age < 45 order by name desc";
                }
                else if (p == 3)
                {
                    if (s == 0)
                        SqlText = "SELECT * FROM [Users] where age >= 45";
                    else if (s == 1)
                        SqlText = "SELECT * FROM [Users] where age >= 45 order by name asc";
                    else if (s == 2)
                        SqlText = "SELECT * FROM [Users] where age >= 45 order by name desc";
                }
            }
            SqlDataAdapter da = new SqlDataAdapter(SqlText, ConnStr);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Users]");
            dataGridView1.DataSource = ds.Tables["[Users]"].DefaultView;
        }

        public void MyExecuteNonQuery(string SqlText)
        {
            SqlConnection cn;
            SqlCommand cmd;

            cn = new SqlConnection(ConnStr);
            cn.Open();
            cmd = cn.CreateCommand();
            cmd.CommandText = SqlText;
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") || (textBox2.Text != "") || (textBox3.Text != "") || (textBox4.Text != ""))
            {
                if (MyClass.dolgnost == "admin")
                {
                    string SqlText = "insert into [Users] ([name],[login],[password],[gender],[age]) VALUES (\'" + textBox1.Text + "\', \'" + textBox2.Text + "\', \'" + textBox3.Text + "\', \'" + textBox4.Text + "\', " + textBox5.Text + ")";
                    MyExecuteNonQuery(SqlText);
                    FillUsers();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                }
                else if (MyClass.dolgnost == "lab")
                    MessageBox.Show("У вас недостаточно прав для редактирования таблицы.", "Внимание!");
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MyClass.dolgnost == "admin")
            {
                int index, n;
                n = dataGridView1.Rows.Count;
                if (n == 1) return;
                index = dataGridView1.CurrentRow.Index;
                string id = dataGridView1[0, index].Value.ToString(); ;
                if (r == 0)
                {
                    string name, login, password, gender, age;
                    name = dataGridView1[1, index].Value.ToString();
                    login = dataGridView1[2, index].Value.ToString();
                    password = dataGridView1[3, index].Value.ToString();
                    gender = dataGridView1[4, index].Value.ToString();
                    age = dataGridView1[5, index].Value.ToString();
                    textBox1.Text = name;
                    textBox2.Text = login;
                    textBox3.Text = password;
                    textBox4.Text = gender;
                    textBox5.Text = age;
                    r = 1;
                }
                else if (r == 1)
                {
                    string SqlText = "update [Users] set name = \'" + textBox1.Text + "\', login = \'" + textBox2.Text + "\', password = \'" + textBox3.Text + "\', gender = \'" + textBox4.Text + "\', age = " + textBox5.Text + " where id = " + id;
                    MyExecuteNonQuery(SqlText);
                    FillUsers();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    r = 0;
                }
            }
            else if (MyClass.dolgnost == "lab")
                MessageBox.Show("У вас недостаточно прав для редактирования таблицы.", "Внимание!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MyClass.dolgnost == "admin")
            {
                int index;
                string id;
                index = dataGridView1.CurrentRow.Index;
                id = Convert.ToString(dataGridView1[0, index].Value);
                string SqlText = "delete from [Users] WHERE id = " + id;
                MyExecuteNonQuery(SqlText);
                FillUsers();
            }
            else if (MyClass.dolgnost == "lab")
                MessageBox.Show("У вас недостаточно прав для редактирования таблицы.", "Внимание!");
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox6.Text != "")
                {
                    string strok = textBox6.Text;
                    string SqlText;
                    if (MyClass.dolgnost == "admin")
                        SqlText = "select * from [Users]";
                    else SqlText = "select id, name, gender, age from [Users]";
                    SqlText = SqlText + "where id Like \'%" + strok + "%\' or name like \'%" + strok +
                        "%\' or login like \'%" + strok + "%\' or password like \'%" + strok + "%\' or gender like \'%" + strok +
                        "%\' or age like \'%" + strok + "%\'";
                    MyExecuteNonQuery(SqlText);
                    SqlDataAdapter da = new SqlDataAdapter(SqlText, ConnStr);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "[Users]");
                    dataGridView1.DataSource = ds.Tables["[Users]"].DefaultView;
                    textBox6.Text = "";
                }
                else FillUsers();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == "Без фильтра")
                p = 0;
            else if (comboBox2.SelectedItem == "До 18")
                p = 1;
            else if (comboBox2.SelectedItem == "18 - 45")
                p = 2;
            else if (comboBox2.SelectedItem == "45 и более")
                p = 3;
            FillUsers();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Без сортировки")
                s = 0;
            else if (comboBox1.SelectedItem == "Имя: по возрастанию")
                s = 1;
            else if (comboBox1.SelectedItem == "Имя: по убыванию")
                s = 2;
            FillUsers();
        }
    }
}
