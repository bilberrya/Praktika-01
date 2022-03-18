using BarcodeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab
{
    public partial class Результаты : Form
    {
        int r = 0, s, p;
        string ConnStr = @"Data Source=sql;Initial Catalog='44-Практика-Иконникова А.В.-2022';Integrated Security=True"; //строка подключения
        public Результаты()
        {
            InitializeComponent();
            FillResults();
        }

        /// <summary>
        /// отображения данных из таблицы результатов
        /// </summary>
        private void FillResults()
        {
            string SqlText = null;
            if (p == 0)
            {
                if (s == 0)
                    SqlText = "SELECT * FROM [Results]";
                else if (s == 1)
                    SqlText = "SELECT * FROM [Results] order by data asc";
                else if (s == 2)
                    SqlText = "SELECT * FROM [Results] order by data desc";
            }
            else if (p == 1)
            {
                if (s == 0)
                    SqlText = "SELECT * FROM [Results] where result = \'+\'";
                else if (s == 1)
                    SqlText = "SELECT * FROM [Results] where result = \'+\' order by data asc";
                else if (s == 2)
                    SqlText = "SELECT * FROM [Results] where result = \'+\'  order by data desc";
            }
            else if (p == 2)
            {
                if (s == 0)
                    SqlText = "SELECT * FROM [Results] where result = \'-\'";
                else if (s == 1)
                    SqlText = "SELECT * FROM [Results] where result = \'-\' order by data asc";
                else if (s == 2)
                    SqlText = "SELECT * FROM [Results] where result = \'-\'  order by data desc";
            }
            SqlDataAdapter da = new SqlDataAdapter(SqlText, ConnStr);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Results]");
            dataGridView1.DataSource = ds.Tables["[Results]"].DefaultView;
        }

        /// <summary>
        /// метод выполнения запросов
        /// </summary>
        /// <param name="SqlText"></param>
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

        /// <summary>
        /// удаление записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            int index;
            string id;
            index = dataGridView1.CurrentRow.Index;
            id = Convert.ToString(dataGridView1[0, index].Value);
            string SqlText = "delete from [Results] WHERE id = " + id;
            MyExecuteNonQuery(SqlText);
            FillResults();
        }

        /// <summary>
        /// поиск
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox6.Text != "")
                {
                    string strok = textBox6.Text;
                    string SqlText = "select * from [Results] where id Like \'%" + strok + "%\' or id_user like \'%" + strok +
                        "%\' or id_lab like \'%" + strok + "%\' or id_service like \'%" + strok + "%\' or result like \'%" + strok +
                        "%\' or data like \'%" + strok + "%\'";
                    MyExecuteNonQuery(SqlText);
                    SqlDataAdapter da = new SqlDataAdapter(SqlText, ConnStr);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "[Results]");
                    dataGridView1.DataSource = ds.Tables["[Results]"].DefaultView;
                    textBox4.Text = "";
                }
                else FillResults();
            }
        }

        /// <summary>
        /// сортировка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Без сортировки")
                s = 0;
            else if (comboBox1.SelectedItem == "Дата: по возрастанию")
                s = 1;
            else if (comboBox1.SelectedItem == "Дата: по убыванию")
                s = 2;
            FillResults();
        }

        /// <summary>
        /// фильтр
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == "Без фильтра")
                p = 0;
            else if (comboBox2.SelectedItem == "Положительный результат")
                p = 1;
            else if (comboBox2.SelectedItem == "Отрицательный результат")
                p = 2;
            FillResults();
        }

        /// <summary>
        /// штрих-код
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            int index, n;
            n = dataGridView1.Rows.Count;
            if (n == 1) return;
            index = dataGridView1.CurrentRow.Index;

            Barcode code = new Barcode();
            Image img = code.Encode(TYPE.UPCA, dataGridView1[0, index].Value.ToString());
            pictureBox1.Image = img;
        }

        /// <summary>
        /// добавление данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string SqlText = "insert into [Results] ([id],[id_user],[id_lab],[id_service],[result],[data]) VALUES (\'" + textBox7.Text + "\', " + textBox1.Text + ", " + textBox2.Text + ", " + textBox3.Text + ", \'" + textBox4.Text + "\', \'" + textBox5.Text + "\')";
            MyExecuteNonQuery(SqlText);
            FillResults();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
        }

        /// <summary>
        /// редактирование данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            int index, n;
            n = dataGridView1.Rows.Count;
            if (n == 1) return;
            index = dataGridView1.CurrentRow.Index;
            string id = dataGridView1[0, index].Value.ToString();
            if (r == 0)
            {
                string id_user, id_lab, id_service, result, data;
                id_user = dataGridView1[1, index].Value.ToString();
                id_lab = dataGridView1[2, index].Value.ToString();
                id_service = dataGridView1[3, index].Value.ToString();
                result = dataGridView1[4, index].Value.ToString();
                data = dataGridView1[5, index].Value.ToString();
                textBox7.Text = id;
                textBox1.Text = id_user;
                textBox2.Text = id_lab;
                textBox3.Text = id_service;
                textBox4.Text = result;
                textBox5.Text = data;
                r = 1;
            }
            else if (r == 1)
            {
                string SqlText = "update [Results] set id = \'" + textBox7.Text + "\', id_user = " + textBox1.Text + ", id_lab = " + textBox2.Text + ", id_service = " + textBox3.Text + ", result = \'" + textBox4.Text + "\', data = \'" + textBox5.Text + "\' where id = " + id;
                MyExecuteNonQuery(SqlText);
                FillResults();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox7.Text = "";
                r = 0;
            }
        }
    }
}