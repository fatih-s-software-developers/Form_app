
using System.Net.Http;
using FormApp.apicom;
using FormApp.forms;
using Newtonsoft.Json;
namespace FormApp
{
    public partial class Form1 : Form
    {
        //uygulama açýldýðýndaki ana form
        public Form1()
        {
            InitializeComponent();
        }

        private void ornekVeriListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrnekVeriListele ornekVeriListeleForm = new OrnekVeriListele();
            ornekVeriListeleForm.MdiParent = this;
            ornekVeriListeleForm.Show();
        }

        private void ornekVeriListeleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //data grid view kullanarak örnek verileri listeleyen "ornekVeriListeleModelVeri" formuna gider
            OrnekVeriListeleModelVeri ornekVeriListeleModelVeri = new OrnekVeriListeleModelVeri();
            ornekVeriListeleModelVeri.MdiParent = this;
            ornekVeriListeleModelVeri.Show();
        }

        private void ornekVeriEkleModelVeriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Student ekleme formuna gider
            OrnekVeriEkleModelVeri ornekVeriEkleModelVeri = new OrnekVeriEkleModelVeri();
            ornekVeriEkleModelVeri.MdiParent = this;
            ornekVeriEkleModelVeri.Show();

        }
    }
}
