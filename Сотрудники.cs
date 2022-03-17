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
    public partial class Сотрудники : Form
    {
        int r = 0, s, p;
        string ConnStr = @"Data Source=sql;Initial Catalog='44-Практика-Иконникова А.В.-2022';Integrated Security=True";
        public Сотрудники()
        {
            InitializeComponent();
            FillWorkers();
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

        private void FillWorkers()
        {
            string SqlText = null;
            if (MyClass.dolgnost == "lab")
            {
                if (p == 0)
                {
                    if (s == 0)
                        SqlText = "SELECT id, name, dolgnost, analyzator FROM [Workers]";
                    else if (s == 1)
                        SqlText = "SELECT id, name, dolgnost, analyzator FROM [Workers] order by name asc";
                    else if (s == 2)
                        SqlText = "SELECT id, name, dolgnost, analyzator FROM [Workers] order by name desc";
                }
                else if (p == 1)
                {
                    if (s == 0)
                        SqlText = "SELECT id, name, dolgnost, analyzator FROM [Workers] where dolgnost = \'lab\'";
                    else if (s == 1)
                        SqlText = "SELECT id, name, dolgnost, analyzator FROM [Workers] where dolgnost = \'lab\' order by name asc";
                    else if (s == 2)
                        SqlText = "SELECT id, name, dolgnost, analyzator FROM [Workers] where dolgnost = \'lab\' order by name desc";
                }
                else if (p == 2)
                {
                    if (s == 0)
                        SqlText = "SELECT id, name, dolgnost, analyzator FROM [Workers] where dolgnost = \'admin\'";
                    else if (s == 1)
                        SqlText = "SELECT id, name, dolgnost, analyzator FROM [Workers] where dolgnost = \'admin\' order by name asc";
                    else if (s == 2)
                        SqlText = "SELECT id, name, dolgnost, analyzator FROM [Workers] where dolgnost = \'admin\' order by name desc";
                }
            }
            else if (MyClass.dolgnost == "admin")
            {
                if (p == 0)
                {
                    if (s == 0)
                        SqlText = "SELECT * FROM [Workers]";
                    else if (s == 1)
                        SqlText = "SELECT * FROM [Workers] order by name asc";
                    else if (s == 2)
                        SqlText = "SELECT * FROM [Workers] order by name desc";
                }
                else if (p == 1)
                {
                    if (s == 0)
                        SqlText = "SELECT * FROM [Workers] where dolgnost = \'lab\'";
                    else if (s == 1)
                        SqlText = "SELECT * FROM [Workers] where dolgnost = \'lab\' order by name asc";
                    else if (s == 2)
                        SqlText = "SELECT * FROM [Workers] where dolgnost = \'lab\' order by name desc";
                }
                else if (p == 2)
                {
                    if (s == 0)
                        SqlText = "SELECT * FROM [Workers] where dolgnost = \'admin\'";
                    else if (s == 1)
                        SqlText = "SELECT * FROM [Workers] where dolgnost = \'admin\' order by name asc";
                    else if (s == 2)
                        SqlText = "SELECT * FROM [Workers] where dolgnost = \'admin\' order by name desc";
                }
            }
            SqlDataAdapter da = new SqlDataAdapter(SqlText, ConnStr);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Workers]");
            dataGridView1.DataSource = ds.Tables["[Workers]"].DefaultView;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MyClass.dolgnost == "admin")
            {
                int index, n;
                string id;
                index = dataGridView1.CurrentRow.Index;
                id = Convert.ToString(dataGridView1[0, index].Value);
                string SqlText = "delete from [Workers] WHERE id = " + id;
                MyExecuteNonQuery(SqlText);
                FillWorkers();
            }
            else if (MyClass.dolgnost == "lab")
                MessageBox.Show("У вас недостаточно прав для редактирования таблицы.", "Внимание!");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Без сортировки")
                s = 0;
            else if (comboBox1.SelectedItem == "Имя: по возрастанию")
                s = 1;
            else if (comboBox1.SelectedItem == "Имя: по убыванию")
                s = 2;
            FillWorkers();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == "Без фильтра")
                p = 0;
            else if (comboBox2.SelectedItem == "Лаборанты")
                p = 1;
            else if (comboBox2.SelectedItem == "Администратор")
                p = 2;
            FillWorkers();
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
                        SqlText = "select * from [Workers]";
                    else SqlText = "select id, name, dolgnost, analyzator from [Workers]";
                    SqlText = SqlText + "where id Like \'%" + strok + "%\' or name like \'%" + strok +
                        "%\' or login like \'%" + strok + "%\' or password like \'%" + strok + "%\' or ip like \'%" + strok +
                        "%\' or lastenter like \'%" + strok + "%\' or dolgnost like \'%" + strok + "%\' or analyzator like \'%" + strok + "%\'";
                    MyExecuteNonQuery(SqlText);
                    SqlDataAdapter da = new SqlDataAdapter(SqlText, ConnStr);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "[Workers]");
                    dataGridView1.DataSource = ds.Tables["[Workers]"].DefaultView;
                    textBox6.Text = "";
                }
                else FillWorkers();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") || (textBox2.Text != "") || (textBox3.Text != "") || (textBox4.Text != "") || (textBox5.Text != "") || (textBox8.Text != ""))
            {
                if (MyClass.dolgnost == "admin")
                {
                    string SqlText = "insert into [Workers] ([name],[login],[password],[ip],[lastenter], [dolgnost], [analyzator]) VALUES (\'" + textBox1.Text + "\', \'" + textBox2.Text + "\', \'" + textBox3.Text + "\', \'" + textBox4.Text + "\', \'" + textBox5.Text + "\', \'" + textBox8.Text + "\', \'" + textBox7.Text + "\')";
                    MyExecuteNonQuery(SqlText);
                    FillWorkers();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
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
                    string name, login, password, ip, lastenter, dolgnost, analyzator;
                    name = dataGridView1[1, index].Value.ToString();
                    login = dataGridView1[2, index].Value.ToString();
                    password = dataGridView1[3, index].Value.ToString();
                    ip = dataGridView1[4, index].Value.ToString();
                    lastenter = dataGridView1[5, index].Value.ToString();
                    dolgnost = dataGridView1[6, index].Value.ToString();
                    analyzator = dataGridView1[7, index].Value.ToString();
                    textBox1.Text = name;
                    textBox2.Text = login;
                    textBox3.Text = password;
                    textBox4.Text = ip;
                    textBox5.Text = lastenter;
                    textBox8.Text = dolgnost;
                    textBox7.Text = analyzator;
                    r = 1;
                }
                else if (r == 1)
                {
                    string SqlText = "update [Workers] set name = \'" + textBox1.Text + "\', login = \'" + textBox2.Text + "\', password = \'" + textBox3.Text + "\', ip = \'" + textBox4.Text + "\', lastenter = \'" + textBox5.Text + "\', dolgnost = \'" + textBox8.Text + "\', analyzator = \'" + textBox7.Text + "\' where id = " + id;
                    MyExecuteNonQuery(SqlText);
                    FillWorkers();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox8.Text = "";
                    textBox7.Text = "";
                    r = 0;
                }
            }
            else if (MyClass.dolgnost == "lab")
                MessageBox.Show("У вас недостаточно прав для редактирования таблицы.", "Внимание!");
        }
    }
}
