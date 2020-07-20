using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using System.Json;
using CookTime.Views;

namespace CookTime
{

    class RestClient
    {
        public async void Peticion(Label ChangedLabel)
        {
           
                try
            {
                /*
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri("http://192.168.100.2:8080/CookTime_Web_exploded/users");
                request.Method = HttpMethod.Get;
                request.Headers.Add("Accept", "application/json");
              
                 

                var client = new HttpClient();
                HttpResponseMessage response = await client.SendAsync(request);

                HttpContent contenido = response.Content;
                var json = await contenido.ReadAsStringAsync();

                ChangedLabel.Text = json;
                */
                /*
                WebRequest request = WebRequest.Create("http://192.168.100.2:8080/CookTime_Web_exploded/users");
                request.Method = "GET";
                WebResponse response = request.GetResponse();

                var reader = new StreamReader(response.GetResponseStream());
                ChangedLabel.Text = reader.ReadToEnd();
                */

                MyIp myIps = new MyIp();
                WebClient webClient = new WebClient();
                string result = webClient.DownloadString("http://" + myIps.returnIP() + ":8080/CookTime_war_exploded/users");
                ChangedLabel.Text = result;
            }
            catch (Exception e)
            {
                ChangedLabel.Text = e.Message;

            }
    }
    }
}
