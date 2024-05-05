using FormApp.apicom.models;
using FormApp.apicom.models.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FormApp.apicom;

public class ApiComForStudent
{
    /*
     API communication class
     */
    string mainapiUrl;

    public ApiComForStudent(string apiurl)
    {
        this.mainapiUrl = apiurl;
    }
    public async Task<String> TekilDataCekme()
    {
        //Tekil data(liste tipi şeklinde olmayan)
        /* url :http://localhost:5290/api/Values/dataone
         * gelmesini beklediğimiz veri :"Veri"
         */
        string localApiUrl = String.Concat(mainapiUrl, "/Values/dataone/");
        string responseData;
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync(localApiUrl);
        if (response.IsSuccessStatusCode)
        {

            //response başarılı
            responseData = await response.Content.ReadAsStringAsync();
        }
        else
        {
            responseData = null;
        }
        client.Dispose();
        return responseData;
    }
    public async Task<List<string>> cogulDataCekme()
    {
        //Tekil data(liste tipi şeklinde olmayan)
        /* url :http://localhost:5290/api/Values/datatwo
         * gelmesini beklediğimiz veri :
           [
          "data1",
          "data2",
          "data3"
           ]
         */
        string localApiUrl = String.Concat(mainapiUrl, "/Values/datatwo");
        HttpClient client = new HttpClient();
        List<string> returnData = new List<string>();
        HttpResponseMessage response = await client.GetAsync(localApiUrl);
        if (response.IsSuccessStatusCode)
        {
            //response başarılı
            string responseData = await response.Content.ReadAsStringAsync();
            List<string> dataList = JsonConvert.DeserializeObject<List<string>>(responseData);
            foreach (string data in dataList)
            {
                returnData.Add(data);
            }
        }
        else
        {
            //response başarısız
        }
        client.Dispose();
        return returnData;

    }
    public async Task<List<GetStudentRequest>> GetStudents()
    {
        //http://localhost:5290/api/Values/getstudents
        string localApiUrl = String.Concat(mainapiUrl, "/Values/getstudents");
        HttpClient client = new HttpClient();
        List<GetStudentRequest> dataList = new List<GetStudentRequest>();
        HttpResponseMessage response = await client.GetAsync(localApiUrl);
        if (response.IsSuccessStatusCode) {
            //response başarılı
            string responseData = await response.Content.ReadAsStringAsync();
             dataList = JsonConvert.DeserializeObject<List<GetStudentRequest>>(responseData);

        }
        else
        {
            //response başarısız
        }


        client.Dispose();
        return dataList;
    }

    public async Task<string> AddStudent(AddStudentRequest student) {
        //http://localhost:5290/api/Values/addstudent
        string localApiUrl = String.Concat(mainapiUrl, "/Values/addstudent");
        HttpClient client = new HttpClient();
        string jsonContent = JsonConvert.SerializeObject(student);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync(localApiUrl, content);
        if (response.IsSuccessStatusCode) {
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
