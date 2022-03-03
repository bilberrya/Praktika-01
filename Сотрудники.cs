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
        string ConnStr = @"Data Source=sql;Initial Catalog='44-Практика-Иконникова А.В.-2022';Integrated Security=True";
        public Сотрудники()
        {
            InitializeComponent();
            string SqlText = null;
            if (MyClass.dolgnost == "lab")
                SqlText = "SELECT id, name, dolgnost, analyzator FROM [Workers]";
            else if (MyClass.dolgnost == "admin")
                SqlText = "SELECT * FROM [Workers]";
            SqlDataAdapter da = new SqlDataAdapter(SqlText, ConnStr);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Workers]");
            dataGridView1.DataSource = ds.Tables["[Workers]"].DefaultView;
        }
    }
}
