using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormApp;

public class ExcelOku
{
	public string dosyaYolu { get; set; }

	public ExcelOku(string dosyaYolu)
	{
		this.dosyaYolu = dosyaYolu;
	}


	public List<ExcelVeriModel> ozelExcelOku()
	{
		/*bu kodun bir kısmını ben(mapping işlemleri)
		 * bir kısmını (veri okuma işlemlerini)aşağıdaki kaynaklardan aldım
		 * http://bilgislem.com/c-ile-excel-dosyasi-okuma/
		 * https://semihcelikol.com/c-exceldatareader-ile-excelden-veri-okuma/
		 */
		List<ExcelVeriModel> data = new List<ExcelVeriModel>();
		//List<string> data = new List<string>();
		FileStream stream = File.Open(dosyaYolu, FileMode.Open, FileAccess.Read);
		MessageBox.Show($" {dosyaYolu} adlı excel dosyası açıldı");
		System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
		IExcelDataReader excelReader;
		int counter = 0;

		//Gönderdiğim dosya xls'mi xlsx formatında mı kontrol ediliyor.
		if (Path.GetExtension(dosyaYolu).ToUpper() == ".XLS")
		{
			//Reading from a binary Excel file ('97-2003 format; *.xls)
			excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
		}
		else
		{
			//Reading from a OpenXml Excel file (2007 format; *.xlsx)
			excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
		}
		excelReader.NextResult();
		excelReader.NextResult();
		MessageBox.Show(excelReader.Name);

		while (excelReader.Read())
		{
			//boş satırları engelleme
			if (excelReader.GetValue(1) == null)
			{
				break;
			}
			if (counter > 1)
			{
				//model de olup da eklenmeyen alanlar(şuan buradaki kodlar geçiçi daha sonra veriyi düzenleyeceğiz)
				/*
				 * 					
				 * DahaOnceKatildiMi
				 * CiftMacTercihi
				 * UcretOdemesiYapildiMi
				 * UlusalLiglerdeOynadiMi
				 * LigAdi
				 */
				//alan kontrolleri
				ExcelVeriModel veri = new ExcelVeriModel();
				veri.Id = counter - 1;//geçiçi sonra silinecek
				//TEMEL BİLGİLER ALANLARI
				//adi,soyadı alanlarının doldurulması
				veri.Adi = (excelReader.GetValue(1) is not null) ? excelReader.GetValue(1).ToString() : "";
				veri.Soyadi = (excelReader.GetValue(2) is not null) ? excelReader.GetValue(2).ToString() : "";
				
				
				//ülke ve il alanın doldurulması
				string ulkeilDegeri = (excelReader.GetValue(3) is not null) ? excelReader.GetValue(3).ToString() : "";
				if (this.UlkeTurkiyeMi(ulkeilDegeri))
				{
					//ülke türkiye
					veri.Ulke = "Türkiye";
					veri.Il = ulkeilDegeri;
				}
				else
				{
					//ülke türkiye değil
					veri.Ulke = ulkeilDegeri;
					veri.Il = "";
				}
				//telefon numarası ve e posta adresi alanlarının doldurulması
				veri.TelefonNumarasi = (excelReader.GetValue(4) is not null) ? excelReader.GetValue(4).ToString() : "";
				veri.EpostaAdresi = (excelReader.GetValue(5) is not null) ? excelReader.GetValue(5).ToString() : "";

				//Cinsiyet alanın doldurulması(ERKEK,KADIN)
				string cinsiyetDegeri = (excelReader.GetValue(6) is not null) ? excelReader.GetValue(6).ToString(): "";
				if (cinsiyetDegeri == "E")
				{
					//cinsiyet erkek
					veri.Cinsiyet = "ERKEK";
				}
				else if (cinsiyetDegeri == "K")
				{
					//cinsiyet kadın
					veri.Cinsiyet = "KADIN";
				}
				else
				{
					//değer boş gelmiş
					veri.Cinsiyet = cinsiyetDegeri;
				}


				//Doğum yılı,puan ve beden ölçüsü alanlarının doldurulması
				//(1900 girilebilecek en küçük tarih)
				veri.DogumYili = (excelReader.GetValue(7) is not null) ? int.Parse(excelReader.GetValue(7).ToString()): 1900;
				veri.Puan =  (excelReader.GetValue(9) is not null) ? double.Parse(excelReader.GetValue(9).ToString()) : 0;
				veri.BedenOlcusu = (excelReader.GetValue(10) is not null) ? excelReader.GetValue(10).ToString() : "";


				//oyun seviye alanın doldurulması
				//varsayılan bir değer atandı
				veri.OyunSeviye = 1;

				
				//daha önce katıldı mı alanının doldurulması
				string katildimiDegeri = (excelReader.GetValue(11) is not null) ? excelReader.GetValue(11).ToString() : "";
				if (katildimiDegeri == "+")
				{
					veri.DahaOnceKatildiMi = true;
				}
				else
				{
					veri.DahaOnceKatildiMi = false;
				}

				//bu kısım nasıl daha efektif yazılabilir
				//MAC EŞ ALANLARI
				veri.CiftEsAdi = (excelReader.GetValue(12) is not null) ? excelReader.GetValue(12).ToString() : "";
				if (veri.CiftEsAdi == "")
				{
					veri.CiftMacTercihi = false;
				}
				else if (veri.CiftEsAdi == "HAYIR")
				{
					veri.CiftMacTercihi = false;
				}
				veri.KarisikEsAdi = (excelReader.GetValue(13) is not null) ? excelReader.GetValue(13).ToString() : "";

				if (veri.KarisikEsAdi == "")
				{
					veri.KarisikMacTercihi = false;
				}
				else if (veri.KarisikEsAdi == "HAYIR")
				{
					veri.KarisikMacTercihi = false;
				}



				//bu bölümde(ÜCRET ALANLARI) neyi alacağımızı tam kestiremedim tahmini bir şey yaptım bu daha sonra düzelt
				//ÜCRET ALANLARI
				veri.OdemeYapanKisininAdiSoyadi = (excelReader.GetValue(14) is not null) ? excelReader.GetValue(14).ToString() : "";
				string odemeDurumu = (excelReader.GetValue(15) is not null) ? excelReader.GetValue(15).ToString() : "";

				if (odemeDurumu == "+")
				{
					veri.UcretOdemesiYapildiMi = true;
				}
				else
				{
					veri.UcretOdemesiYapildiMi = false;
				}

				veri.OdemeYapilmasiPlanlananTarih = DateTime.Today;

				//Daha önce katıldığı li
				//bu kısım ,verilen tabloda yok
				//standart değer
				veri.UlusalLiglerdeOynadiMi = false;

				veri.LigAdi = "";
				



				data.Add(veri);
				/* Yeni {excelReader.GetValue(10)} Not {excelReader.GetValue(15)}*/

				//data.Add($"ad {excelReader.GetValue(1)} soyad {excelReader.GetValue(2)} İl-Ülke {excelReader.GetString(3)} Telefon {excelReader.GetValue(4)} email {excelReader.GetValue(5)} Cinsiyet {excelReader.GetValue(6)} Doğum Yılı {excelReader.GetValue(7)} Yaş Grubu {excelReader.GetValue(8)} Beden Ölçüsü {excelReader.GetValue(9)} Double Eşi {excelReader.GetValue(11)} Mix Eşi {excelReader.GetValue(12)} Havale Yapan {excelReader.GetValue(13)} Ödeme {excelReader.GetValue(14)}");
			}
			counter++;

		}
		excelReader.Dispose();
		MessageBox.Show($" {dosyaYolu} adlı excel dosyası kapatıldı");
		return data;

	}

	public bool UlkeTurkiyeMi(string karsilastirmaDegeri)
	{
		//küçük harfle yazılmış iller listesi
		/*
		List<string> illerKucukHarf = new List<string>()
		{
			"istanbul",
			"ankara",
			"izmir",
			"adana",
			"adıyaman",
			"afyonkarahisar",
			"ağrı",
			"amasya",
			"antalya",
			"artvin",
			"aydın",
			"balıkesir",
			"bilecik",
			"bingöl",
			"bitlis",
			"bolu",
			"burdur",
			"bursa",
			"çanakkale",
			"çankırı",
			"çorum",
			"denizli",
			"diyarbakır",
			"edirne",
			"elazığ",
			"erzincan",
			"erzurum",
			"eskişehir",
			"gaziantep",
			"giresun",
			"gümüşhane",
			"hakkari",
			"hatay",
			"ısparta",
			"mersin(içel)",
			"kars",
			"kastamonu",
			"kayseri",
			"kırklareli",
			"kırşehir",
			"kocaeli",
			"konya",
			"kütahya",
			"malatya",
			"manisa",
			"kahramanmaraş",
			"mardin",
			"muğla",
			"muş",
			"nevşehir",
			"niğde",
			"ordu",
			"rize",
			"sakarya",
			"samsun",
			"siirt",
			"sinop",
			"sivas",
			"tekirdağ",
			"tokat",
			"trabzon",
			"tunceli",
			"şanlıurfa",
			"uşak",
			"van",
			"yozgat",
			"zonguldak",
			"aksaray",
			"bayburt",
			"karaman",
			"kırıkkale",
			"batman",
			"şırnak",
			"bartın",
			"ardahan",
			"iğdir",
			"yalova",
			"karabük",
			"kilis",
			"osmaniye",
			"düzce",
		};
		*/
		//büyük harfle yazılmış iller listesi
		List<string> iller = new List<string>()
		{
			// "Seçiniz",
			"İSTANBUL",
			"ANKARA",
			"İZMİR",
			"ADANA",
			"ADIYAMAN",
			"AFYONKARAHİSAR",
			"AĞRI",
			"AMASYA",
			"ANTALYA",
			"ARTVİN",
			"AYDIN",
			"BALIKESİR",
			"BİLECİK",
			"BİNGÖL",
			"BİTLİS",
			"BOLU",
			"BURDUR",
			"BURSA",
			"ÇANAKKALE",
			"ÇANKIRI",
			"ÇORUM",
			"DENİZLİ",
			"DİYARBAKIR",
			"EDİRNE",
			"ELAZIĞ",
			"ERZİNCAN",
			"ERZURUM",
			"ESKİŞEHİR",
			"GAZİANTEP",
			"GİRESUN",
			"GÜMÜŞHANE",
			"HAKKARİ",
			"HATAY",
			"ISPARTA",
			"MERSİN",
			"KARS",
			"KASTAMONU",
			"KAYSERİ",
			"KIRKLARELİ",
			"KIRŞEHİR",
			"KOCAELİ",
			"KONYA",
			"KÜTAHYA",
			"MALATYA",
			"MANİSA",
			"KAHRAMANMARAŞ",
			"MARDİN",
			"MUĞLA",
			"MUŞ",
			"NEVŞEHİR",
			"NİĞDE",
			"ORDU",
			"RİZE",
			"SAKARYA",
			"SAMSUN",
			"SİİRT",
			"SİNOP",
			"SİVAS",
			"TEKİRDAĞ",
			"TOKAT",
			"TRABZON",
			"TUNCELİ",
			"ŞANLIURFA",
			"UŞAK",
			"VAN",
			"YOZGAT",
			"ZONGULDAK",
			"AKSARAY",
			"BAYBURT",
			"KARAMAN",
			"KIRIKKALE",
			"BATMAN",
			"ŞIRNAK",
			"BARTIN",
			"ARDAHAN",
			"IĞDIR",
			"YALOVA",
			"KARABÜK",
			"KİLİS",
			"OSMANİYE",
			"DÜZCE",
		};
		//linq ya çevirilebilir
		foreach (string il in iller)
		{
			if (il == karsilastirmaDegeri)
			{
				return true;
			}
		}
		return false;
	}

}

public class ExcelVeriModel
{
	//test verisi 
	public int Id { get; set; }
	//temel bilgiler
	public string Adi { get; set; }

	public string Soyadi { get; set; }

	public string Ulke { get; set; }

	public string Il { get; set; }


	public string TelefonNumarasi { get; set; }

	public string EpostaAdresi { get; set; }

	public string Cinsiyet { get; set; }

	public int DogumYili { get; set; }

	public double Puan { get; set; }

	public string BedenOlcusu { get; set; }

	public int OyunSeviye { get; set; }


	public bool DahaOnceKatildiMi { get; set; }

	//Maç eş (MacEsTemelKayitEkleRequest)
	public bool CiftMacTercihi { get; set; }

	public string CiftEsAdi { get; set; }

	public bool KarisikMacTercihi { get; set; }

	public string KarisikEsAdi { get; set; }
	//ücret UcretTemelKayitEkleRequest
	public bool UcretOdemesiYapildiMi { get; set; }

	public string OdemeYapanKisininAdiSoyadi { get; set; }


	public DateTime OdemeYapilmasiPlanlananTarih { get; set; }

	//katılıdığı lig
	public bool UlusalLiglerdeOynadiMi { get; set; }

	public string LigAdi { get; set; }
}
