﻿using System;
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
        string ConnStr = @"Data Source=sql;Initial Catalog='44-Практика-Иконникова А.В.-2022';Integrated Security=True";
        public Услуги()
        {
            InitializeComponent();
            string SqlText = "SELECT * FROM [Service]";
            SqlDataAdapter da = new SqlDataAdapter(SqlText, ConnStr);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Service]");
            dataGridView1.DataSource = ds.Tables["[Service]"].DefaultView;
        }
    }
}
