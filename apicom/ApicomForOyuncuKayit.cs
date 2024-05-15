using FormApp.apicom.models;
using FormApp.apicom.models.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.apicom;

public class ApicomForOyuncuKayit
{
	/*
     API communication class
     */
	string mainapiUrl;

    public ApicomForOyuncuKayit(string apiurl)
    {
		this.mainapiUrl = apiurl;
	}

	public async Task<string> TopluKayitEkle(List<TemelKayitEkleRequest> kayitlar)
	{
		// http://localhost:5290/api/OyuncuKayit/TopluKayitEkle
		string localApiUrl = string.Concat(mainapiUrl, "/OyuncuKayit/TopluKayitEkle");
		HttpClient client = new HttpClient();
		//timeout(geçici sonra sil)
		client.Timeout = TimeSpan.FromSeconds(1000000);
		string jsonContent = JsonConvert.SerializeObject(kayitlar);
		var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
		HttpResponseMessage response = await client.PostAsync(localApiUrl, content);
		if (response.IsSuccessStatusCode)
		{
			//response başarılı
			client.Dispose();
			return "başarılı";
		}
		else
		{
			//response başarısız
			client.Dispose();
			return "başarısız";
		}
	}

}
