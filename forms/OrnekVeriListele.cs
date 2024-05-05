using FormApp.apicom;
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
    public partial class OrnekVeriListele : Form
    {
        public OrnekVeriListele()
        {
            InitializeComponent();
        }
        ApiComForStudent apiCom;

        private void OrnekVeriListele_Load(object sender, EventArgs e)
        {
            apiCom = new ApiComForStudent("http://localhost:5290/api");
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = (await apiCom.TekilDataCekme()).ToString();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = String.Join(" ", (await apiCom.cogulDataCekme()));
        }
    }
}
