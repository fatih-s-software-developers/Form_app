﻿using FormApp.apicom;
using FormApp.apicom.models;
using FormApp.apicom.models.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormApp.forms
{
    public partial class OrnekVeriEkleModelVeri : Form
    {
        public OrnekVeriEkleModelVeri()
        {
            InitializeComponent();
        }
        ApiComForStudent apiCom;
        private void OrnekVeriEkleModelVeri_Load(object sender, EventArgs e)
        {
            apiCom = new ApiComForStudent("http://localhost:5290/api");
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text.ToString();
            string surname = textBox3.Text.ToString();
            string email = textBox4.Text.ToString();
            AddStudentRequest student = new AddStudentRequest() {Name = name,Surname = surname,Email = email};
            string sonuc =  await apiCom.AddStudent(student);
            MessageBox.Show(sonuc);
        }

        
    }
}
