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
    public partial class Услуги : Form
    {
        int r = 0, s, p;
        string ConnStr = @"Data Source=desktop-jfut083;Initial Catalog='44-Практика-Иконникова А.В.-2022';Integrated Security=True";
        public Услуги()
        {
            InitializeComponent();
            FillService();
        }

        private void FillService()
        {
            string SqlText = null;
            if (p == 0)
            {
                if (s == 0)
                    SqlText = "SELECT * FROM [Service]";
                else if (s == 1)
                    SqlText = "SELECT * FROM [Service] order by service asc";
                else if (s == 2)
                    SqlText = "SELECT * FROM [Service] order by service desc";
            }
            else if (p == 1)
            {
                if (s == 0)
                    SqlText = "SELECT * FROM [Service]";
                else if (s == 1)
                    SqlText = "SELECT * FROM [Service] where price < 200 order by service asc";
                else if (s == 2)
                    SqlText = "SELECT * FROM [Service] where price < 200  order by service desc";
            }
            else if (p == 2)
            {
                if (s == 0)
                    SqlText = "SELECT * FROM [Service]";
                else if (s == 1)
                    SqlText = "SELECT * FROM [Service] where price >= 200 order by service asc";
                else if (s == 2)
                    SqlText = "SELECT * FROM [Service] where price >= 200  order by service desc";
            }
            SqlDataAdapter da = new SqlDataAdapter(SqlText, ConnStr);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Service]");
            dataGridView1.DataSource = ds.Tables["[Service]"].DefaultView;
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
            if (MyClass.dolgnost == "admin")
            {
                string SqlText = "insert into [Service] ([id],[service],[price]) VALUES (" + textBox1.Text + ", \'" + textBox2.Text + "\', " + textBox3.Text + ")";
                MyExecuteNonQuery(SqlText);
                FillService();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            else if (MyClass.dolgnost == "lab")
                MessageBox.Show("У вас недостаточно прав для редактирования таблицы.", "Внимание!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MyClass.dolgnost == "admin")
            {
                if (r == 0)
                {
                    int index, n;
                    string id, service, price;
                    n = dataGridView1.Rows.Count;
                    if (n == 1) return;
                    index = dataGridView1.CurrentRow.Index;
                    id = dataGridView1[0, index].Value.ToString();
                    service = dataGridView1[1, index].Value.ToString();
                    price = dataGridView1[2, index].Value.ToString();
                    textBox1.Text = id;
                    textBox2.Text = service;
                    textBox3.Text = price;
                    r = 1;
                }
                else if (r == 1)
                {
                    string SqlText = "update [Service] set id = " + textBox1.Text + ", service = \'" + textBox2.Text + "\', price = " + textBox3.Text + " where id = " + textBox1.Text;
                    MyExecuteNonQuery(SqlText);
                    FillService();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
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
                string SqlText = "delete from [Service] WHERE id = " + id;
                MyExecuteNonQuery(SqlText);
                FillService();
            }
            else if (MyClass.dolgnost == "lab")
                MessageBox.Show("У вас недостаточно прав для редактирования таблицы.", "Внимание!");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == "Без фильтра")
                p = 0;
            else if (comboBox2.SelectedItem == "До 200 р.")
                p = 1;
            else if (comboBox2.SelectedItem == "Более 200 р.")
                p = 2;
            FillService();
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox4.Text != "")
                {
                    string strok = textBox4.Text;
                    string SqlText ="select * from [Service] where id Like \'%" + strok + "%\' or service like \'%" + strok +
                        "%\' or price like \'%" + strok + "%\'";
                    MyExecuteNonQuery(SqlText);
                    SqlDataAdapter da = new SqlDataAdapter(SqlText, ConnStr);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "[Service]");
                    dataGridView1.DataSource = ds.Tables["[Service]"].DefaultView;
                    textBox4.Text = "";
                }
                else FillService();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Без сортировки")
                s = 0;
            else if (comboBox1.SelectedItem == "Услуга: по возрастанию")
                s = 1;
            else if (comboBox1.SelectedItem == "Услуга: по убыванию")
                s = 2;
            FillService();
        }
    }
}
