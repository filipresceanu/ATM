using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClassLibrary1
{
    public class Convertor
    {
        Root val = new Root();
        public class Root
        {
            
            public Rate rates { get; set; }
            public long timestamp { get; set; }

            public string license { get; set; }

        }
        public  async Task GetValue()
        {
            val = await GetData<Root>("https://openexchangerates.org/api/latest.json?app_id=f76211175062462e85198e738eb7f97e");

        }
        public class Rate
        {
          
            public float EUR { get; set; }
         
            public float RON { get; set; }

        }
        public static async Task<Root> GetData<T>(string url)
        {
            var myRoot = new Root();
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(1);
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var ResponceString = await response.Content.ReadAsStringAsync();
                        var ResponceObject = JsonConvert.DeserializeObject<Root>(ResponceString);

                       
                        return ResponceObject;

                    }
                    return myRoot;
                }
            }
            catch 
            {
                return myRoot;
            }
        }
        public async Task<float> Euro_RonAsync(float number)
        {
            await GetValue();
            float num = (val.rates.EUR * number) / val.rates.RON;
            return num;
                
        }
        public async Task<float> ron_euro(float number)
        {
             await GetValue();
            float num = (val.rates.RON * number) / val.rates.EUR;
            return num;
        }
    }
}
