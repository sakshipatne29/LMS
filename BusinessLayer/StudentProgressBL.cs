using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BusinessLayer
{
    public class StudentProgressBL
    {
        public async Task<string> GetStudent_Progresses()
        {
            string Baseurl = "http://localhost:53520/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/StudentProgress");
                if (Res.IsSuccessStatusCode)
                {
                    var studProgress = Res.Content.ReadAsStringAsync().Result;
                    return studProgress;
                }
                return null;
            }
        }
        public async Task<string> EditC(string c)
        {
            string Baseurl = "http://localhost:53520/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var stringContent = new StringContent(c, UnicodeEncoding.UTF8, "application/json");
                HttpResponseMessage Res = await client.PutAsync("api/TakeTest", stringContent);

                if (Res.IsSuccessStatusCode)
                {
                    var test = Res.Content.ReadAsStringAsync().Result;
                    return test;
                }
                return null;
            }
        }

        public async Task<string> EditCerti(string c)
        {
            string Baseurl = "http://localhost:53520/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var stringContent = new StringContent(c, UnicodeEncoding.UTF8, "application/json");
                HttpResponseMessage Res = await client.PutAsync("api/Certificate", stringContent);

                if (Res.IsSuccessStatusCode)
                {
                    var test = Res.Content.ReadAsStringAsync().Result;
                    return test;
                }
                return null;
            }
        }
        public async Task<string> EnrollNow(string c)
        {
            string Baseurl = "http://localhost:53520/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var stringContent = new StringContent(c, UnicodeEncoding.UTF8, "application/json");
                HttpResponseMessage Res = await client.PostAsync("api/StudentCourse", stringContent);

                if (Res.IsSuccessStatusCode)
                {
                    var course = Res.Content.ReadAsStringAsync().Result;
                    return course;
                }
                return null;
            }
        }
        public async Task<string> EditP(string c)
        {
            string Baseurl = "http://localhost:53520/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var stringContent = new StringContent(c, UnicodeEncoding.UTF8, "application/json");
                HttpResponseMessage Res = await client.PutAsync("api/Progress", stringContent);

                if (Res.IsSuccessStatusCode)
                {
                    var test = Res.Content.ReadAsStringAsync().Result;
                    return test;
                }
                return null;
            }
        }
    }
}
