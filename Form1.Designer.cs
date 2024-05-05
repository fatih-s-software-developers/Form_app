namespace FormApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			menuStrip1 = new MenuStrip();
			formEkleToolStripMenuItem = new ToolStripMenuItem();
			ornekVeriListeleToolStripMenuItem = new ToolStripMenuItem();
			ornekVeriListeleToolStripMenuItem1 = new ToolStripMenuItem();
			ornekVeriEkleModelVeriToolStripMenuItem = new ToolStripMenuItem();
			topluİşlemToolStripMenuItem = new ToolStripMenuItem();
			topluKayıtToolStripMenuItem = new ToolStripMenuItem();
			özelFormatExcelKayıtToolStripMenuItem = new ToolStripMenuItem();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// menuStrip1
			// 
			menuStrip1.ImageScalingSize = new Size(20, 20);
			menuStrip1.Items.AddRange(new ToolStripItem[] { formEkleToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(800, 28);
			menuStrip1.TabIndex = 0;
			menuStrip1.Text = "menuStrip1";
			// 
			// formEkleToolStripMenuItem
			// 
			formEkleToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ornekVeriListeleToolStripMenuItem, ornekVeriListeleToolStripMenuItem1, ornekVeriEkleModelVeriToolStripMenuItem, topluİşlemToolStripMenuItem });
			formEkleToolStripMenuItem.Name = "formEkleToolStripMenuItem";
			formEkleToolStripMenuItem.Size = new Size(88, 24);
			formEkleToolStripMenuItem.Text = "Form Ekle";
			// 
			// ornekVeriListeleToolStripMenuItem
			// 
			ornekVeriListeleToolStripMenuItem.Name = "ornekVeriListeleToolStripMenuItem";
			ornekVeriListeleToolStripMenuItem.Size = new Size(287, 26);
			ornekVeriListeleToolStripMenuItem.Text = "Ornek Veri Listele";
			ornekVeriListeleToolStripMenuItem.Click += ornekVeriListeleToolStripMenuItem_Click;
			// 
			// ornekVeriListeleToolStripMenuItem1
			// 
			ornekVeriListeleToolStripMenuItem1.Name = "ornekVeriListeleToolStripMenuItem1";
			ornekVeriListeleToolStripMenuItem1.Size = new Size(287, 26);
			ornekVeriListeleToolStripMenuItem1.Text = "Ornek Veri Listele(model veri)";
			ornekVeriListeleToolStripMenuItem1.Click += ornekVeriListeleToolStripMenuItem1_Click;
			// 
			// ornekVeriEkleModelVeriToolStripMenuItem
			// 
			ornekVeriEkleModelVeriToolStripMenuItem.Name = "ornekVeriEkleModelVeriToolStripMenuItem";
			ornekVeriEkleModelVeriToolStripMenuItem.Size = new Size(287, 26);
			ornekVeriEkleModelVeriToolStripMenuItem.Text = "Ornek Veri Ekle (Model veri)";
			ornekVeriEkleModelVeriToolStripMenuItem.Click += ornekVeriEkleModelVeriToolStripMenuItem_Click;
			// 
			// topluİşlemToolStripMenuItem
			// 
			topluİşlemToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { topluKayıtToolStripMenuItem });
			topluİşlemToolStripMenuItem.Name = "topluİşlemToolStripMenuItem";
			topluİşlemToolStripMenuItem.Size = new Size(287, 26);
			topluİşlemToolStripMenuItem.Text = "Toplu İşlem";
			// 
			// topluKayıtToolStripMenuItem
			// 
			topluKayıtToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { özelFormatExcelKayıtToolStripMenuItem });
			topluKayıtToolStripMenuItem.Name = "topluKayıtToolStripMenuItem";
			topluKayıtToolStripMenuItem.Size = new Size(224, 26);
			topluKayıtToolStripMenuItem.Text = "Toplu Kayıt";
			// 
			// özelFormatExcelKayıtToolStripMenuItem
			// 
			özelFormatExcelKayıtToolStripMenuItem.Name = "özelFormatExcelKayıtToolStripMenuItem";
			özelFormatExcelKayıtToolStripMenuItem.Size = new Size(248, 26);
			özelFormatExcelKayıtToolStripMenuItem.Text = "Özel Format Excel Kayıt";
			özelFormatExcelKayıtToolStripMenuItem.Click += özelFormatExcelKayıtToolStripMenuItem_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(menuStrip1);
			IsMdiContainer = true;
			MainMenuStrip = menuStrip1;
			Name = "Form1";
			Text = "Form1";
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private MenuStrip menuStrip1;
        private ToolStripMenuItem formEkleToolStripMenuItem;
        private ToolStripMenuItem ornekVeriListeleToolStripMenuItem;
        private ToolStripMenuItem ornekVeriListeleToolStripMenuItem1;
        private ToolStripMenuItem ornekVeriEkleModelVeriToolStripMenuItem;
		private ToolStripMenuItem topluİşlemToolStripMenuItem;
		private ToolStripMenuItem topluKayıtToolStripMenuItem;
		private ToolStripMenuItem özelFormatExcelKayıtToolStripMenuItem;
	}
}
