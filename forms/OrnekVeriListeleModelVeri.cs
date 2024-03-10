﻿using FormApp.apicom;
using FormApp.apicom.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//data grid view kullanarak örnek verileri listeleyen form
namespace FormApp.forms
{
    public partial class OrnekVeriListeleModelVeri : Form
    {
        public OrnekVeriListeleModelVeri()
        {
            InitializeComponent();
        }

        ApiCom apiCom;
        private async void OrnekVeriListeleModelVeri_Load(object sender, EventArgs e)
        {

            apiCom = new ApiCom("http://localhost:5290/api");
            update();
        }
        private async void update()
        {
            dataGridView1.DataSource = null;
            List<Student> data = await apiCom.GetStudents();
            dataGridView1.DataSource = data;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            update();
        }
    }
}
