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
    public partial class Form1 : Form
    {
        string ConnStr = @"Data Source=sql;Initial Catalog='44-Практика-Иконникова А.В.-2022';Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.PasswordChar = '\0';
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dolgnost, login, name, password;
            login = textBox1.Text;
            SqlCommand cmd;
            SqlConnection cn = new SqlConnection(ConnStr);
            cn.Open();
            cmd = cn.CreateCommand();
            cmd.CommandText = "select dolgnost from [Workers] where \'" + login + "\' = login";
            dolgnost = (string) cmd.ExecuteScalar();
            cmd.CommandText = "select name from [Workers] where \'" + login + "\' = login";
            name = (string)cmd.ExecuteScalar();
            cmd.CommandText = "select password from [Workers] where \'" + login + "\' = login";
            password = (string)cmd.ExecuteScalar();
            cn.Close();

            if ((dolgnost == null) || (password != textBox2.Text))
                MessageBox.Show("Неправильно введён логин или пароль, повторите ввод.", "Внимание!");
            else
            {
                Пользователь f = new Пользователь();
                f.Show();
                if (dolgnost == "lab")
                {
                    f.label4.Text = name;
                    f.label3.Text = "Лаборант";
                    f.pictureBox1.Image = Image.FromFile("X:/практика 01/lab/laborant_1.jpg");
                }
                else if (dolgnost == "admin")
                {
                    f.label4.Text = name;
                    f.label3.Text = "Администратор";
                    f.pictureBox1.Image = Image.FromFile("X:/практика 01/lab/laborant_2.png");
                }
            }
        }
    }
}
