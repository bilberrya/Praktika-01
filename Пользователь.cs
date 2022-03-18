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
    public partial class Пользователь : Form
    {
        public Пользователь()
        {
            InitializeComponent();
        }

        //переход на форму услуги
        private void button1_Click(object sender, EventArgs e)
        {
            Услуги f = new Услуги();
            f.Show();
        }

        //переход на форму сотрудники
        private void button2_Click(object sender, EventArgs e)
        {
            Сотрудники f = new Сотрудники();
            f.Show();
        }

        //переход на форму пациенты
        private void button3_Click(object sender, EventArgs e)
        {
            Пациенты f = new Пациенты();
            f.Show();
        }

        //переход на форму результаты
        private void button4_Click(object sender, EventArgs e)
        {
            Результаты f = new Результаты();
            f.Show();
        }
    }
}
