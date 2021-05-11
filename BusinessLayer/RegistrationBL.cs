using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class RegistrationBL
    {
        public async Task<string> Register(string students)
        {
            string Baseurl = "http://localhost:53520/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var stringContent = new StringContent(students, UnicodeEncoding.UTF8, "application/json");
                HttpResponseMessage Res = await client.PostAsync("api/Registration", stringContent);

                if (Res.IsSuccessStatusCode)
                {
                    var student = Res.Content.ReadAsStringAsync().Result;
                    return student;
                }
                return null;
            }
        }
    }
}
