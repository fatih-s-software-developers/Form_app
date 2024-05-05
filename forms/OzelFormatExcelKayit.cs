using ExcelDataReader;
using FormApp.apicom;
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
	public partial class OzelFormatExcelKayit : Form
	{
		public OzelFormatExcelKayit()
		{
			InitializeComponent();
		}

		ApicomForOyuncuKayit apicom;
		string dosyaYolu;
		private void OzelFormatExcelKayit_Load(object sender, EventArgs e)
		{
			apicom = new ApicomForOyuncuKayit("http://localhost:5290/api");
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			/*
			List<TemelKayitEkleRequest> temelKayitEkleRequests = new List<TemelKayitEkleRequest>();
			//1.kayıt
			OyuncuTemelBilgilerTemelKayitEkleRequest oyuncuTemelBilgiler = new OyuncuTemelBilgilerTemelKayitEkleRequest()
			{
				Adi = "Fatih Emre",
				Soyadi = "KILINÇ",
				BedenOlcusu = "L",
				Cinsiyet = "ERKEK",
				DahaOnceKatildiMi = false,
				DogumYili = 1994,
				Il = "ADANA",
				OyunSeviye = 1,
				EpostaAdresi = "ss@test.com",
				TelefonNumarasi = "5558459664",
				Puan = 0,
				Ulke = "Türkiye"
			};
			MacEsTemelKayitEkleRequest macEs = new MacEsTemelKayitEkleRequest()
			{
				CiftMacTercihi = false,
				CiftEsAdi = "",
				KarisikMacTercihi = false,
				KarisikEsAdi = "",
			};
			UcretTemelKayitEkleRequest ucret = new UcretTemelKayitEkleRequest()
			{
				OdemeYapanKisininAdiSoyadi = "Fatih KILINÇ",
				OdemeYapilmasiPlanlananTarih = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
				UcretOdemesiYapildiMi = true,
			};

			DahaOnceKatildigiLigUcretTemelKayitEkleRequest lig = new DahaOnceKatildigiLigUcretTemelKayitEkleRequest()
			{
				UlusalLiglerdeOynadiMi = false,
				LigAdi = "",
			};
			TemelKayitEkleRequest temelKayitEkleRequest = new TemelKayitEkleRequest()
			{
				OyuncuTemelBilgiler = oyuncuTemelBilgiler,
				DahaOnceKatildigiLig = lig,
				MacEs = macEs,
				Ucret = ucret,
			};
			temelKayitEkleRequests.Add(temelKayitEkleRequest);
			string sonuc = await apicom.TopluKayitEkle(temelKayitEkleRequests);
			
			MessageBox.Show(sonuc);
			*/
		}


		private void button2_Click(object sender, EventArgs e)
		{
			//dosya seçtirme
			OpenFileDialog fileDialog = openFileDialog1;
			fileDialog.Filter = "Excel Dosyası | *.xls; *.xlsx; *.xlsm";
			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				//dosya seçildi
				dosyaYolu = fileDialog.FileName;
				MessageBox.Show(dosyaYolu);
			}
			else
			{
				//dosya seçilmedi
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			//okuma işlemi
			if (dosyaYolu != null)
			{
				//Dosya yolu seçilmiş
				ExcelOku excelOku = new ExcelOku(dosyaYolu);
				dataGridView1.DataSource = excelOku.ozelExcelOku();
			}
			else
			{
				//dosya yolu seçilmemiş
				MessageBox.Show("Lütfen dosya Seç butonu ile dosya yolunu belirtin!!");
			}
		}

		private async void button4_Click(object sender, EventArgs e)
		{
			//okuma işlemi
			if (dosyaYolu != null)
			{
				List<TemelKayitEkleRequest> kayitlar = new List<TemelKayitEkleRequest> ();

				//Dosya yolu seçilmiş
				ExcelOku excelOku = new ExcelOku(dosyaYolu);
				MessageBox.Show($"objeler dönüştürülüyor\n(ExcelVeriModel to RequestObject)");
				foreach (ExcelVeriModel okunanVeri in excelOku.ozelExcelOku())
				{
					//object mapping
					//temel bilgiler
					OyuncuTemelBilgilerTemelKayitEkleRequest oyuncuTemelBilgiler = new OyuncuTemelBilgilerTemelKayitEkleRequest
					{
						Adi = okunanVeri.Adi,
						Soyadi = okunanVeri.Soyadi,
						Ulke = okunanVeri.Ulke,
						Il = okunanVeri.Il,
						TelefonNumarasi = okunanVeri.TelefonNumarasi,
						EpostaAdresi = okunanVeri.EpostaAdresi,
						Cinsiyet = okunanVeri.Cinsiyet,
						DogumYili = okunanVeri.DogumYili,
						Puan = okunanVeri.Puan,
						BedenOlcusu = okunanVeri.BedenOlcusu,
						OyunSeviye = okunanVeri.OyunSeviye,
						DahaOnceKatildiMi = okunanVeri.DahaOnceKatildiMi,
					};

					MacEsTemelKayitEkleRequest macEs = new MacEsTemelKayitEkleRequest()
					{
						CiftMacTercihi = okunanVeri.CiftMacTercihi,
						CiftEsAdi = okunanVeri.CiftEsAdi,
						KarisikMacTercihi = okunanVeri.KarisikMacTercihi,
						KarisikEsAdi = okunanVeri.KarisikEsAdi,
					};

					UcretTemelKayitEkleRequest ucret = new UcretTemelKayitEkleRequest()
					{
						UcretOdemesiYapildiMi = okunanVeri.UcretOdemesiYapildiMi,
						OdemeYapanKisininAdiSoyadi = okunanVeri.OdemeYapanKisininAdiSoyadi,
						OdemeYapilmasiPlanlananTarih = okunanVeri.OdemeYapilmasiPlanlananTarih,
					};

					DahaOnceKatildigiLigUcretTemelKayitEkleRequest dahaOnceKatildigiLig = new DahaOnceKatildigiLigUcretTemelKayitEkleRequest()
					{
						UlusalLiglerdeOynadiMi = okunanVeri.UlusalLiglerdeOynadiMi,
						LigAdi = okunanVeri.LigAdi
					};
					TemelKayitEkleRequest temelKayitEkle = new TemelKayitEkleRequest()
					{
						OyuncuTemelBilgiler = oyuncuTemelBilgiler,
						MacEs = macEs,
						Ucret = ucret,
						DahaOnceKatildigiLig = dahaOnceKatildigiLig,
					};

					kayitlar.Add(temelKayitEkle);

				}//foreach end
				MessageBox.Show($"objeler dönüştürüldü\n(ExcelVeriModel to RequestObject) (adet: {kayitlar.Count})");
				MessageBox.Show("api isteği başladı");
				string sonuc = await apicom.TopluKayitEkle(kayitlar);
				MessageBox.Show("api isteği durumu : "+ sonuc);


			}
			else
			{
				//dosya yolu seçilmemiş
				MessageBox.Show("Lütfen dosya Seç butonu ile dosya yolunu belirtin!!");
			}
		}
	}
}

