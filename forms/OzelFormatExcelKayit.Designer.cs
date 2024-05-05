namespace FormApp.forms
{
	partial class OzelFormatExcelKayit
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			button1 = new Button();
			openFileDialog1 = new OpenFileDialog();
			button2 = new Button();
			button3 = new Button();
			dataGridView1 = new DataGridView();
			button4 = new Button();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			// 
			// button1
			// 
			button1.Location = new Point(1102, 543);
			button1.Name = "button1";
			button1.Size = new Size(132, 61);
			button1.TabIndex = 0;
			button1.Text = "İstek Denemesi";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// openFileDialog1
			// 
			openFileDialog1.FileName = "openFileDialog1";
			// 
			// button2
			// 
			button2.Location = new Point(196, 535);
			button2.Name = "button2";
			button2.Size = new Size(152, 61);
			button2.TabIndex = 2;
			button2.Text = "Dosya Seç";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// button3
			// 
			button3.Location = new Point(12, 535);
			button3.Name = "button3";
			button3.Size = new Size(117, 69);
			button3.TabIndex = 3;
			button3.Text = "Okumayı başlat";
			button3.UseVisualStyleBackColor = true;
			button3.Click += button3_Click;
			// 
			// dataGridView1
			// 
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Dock = DockStyle.Top;
			dataGridView1.Location = new Point(0, 0);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.RowHeadersWidth = 51;
			dataGridView1.Size = new Size(1264, 493);
			dataGridView1.TabIndex = 4;
			// 
			// button4
			// 
			button4.Location = new Point(886, 543);
			button4.Name = "button4";
			button4.Size = new Size(158, 61);
			button4.TabIndex = 5;
			button4.Text = "Toplu İstek Gönder";
			button4.UseVisualStyleBackColor = true;
			button4.Click += button4_Click;
			// 
			// OzelFormatExcelKayit
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1264, 626);
			Controls.Add(button4);
			Controls.Add(dataGridView1);
			Controls.Add(button3);
			Controls.Add(button2);
			Controls.Add(button1);
			Name = "OzelFormatExcelKayit";
			Text = "OzelFormatExcelKayit";
			Load += OzelFormatExcelKayit_Load;
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Button button1;
		private OpenFileDialog openFileDialog1;
		private Button button2;
		private Button button3;
		private DataGridView dataGridView1;
		private Button button4;
	}
}