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
    public class StudentBL
    {
        public async Task<string> GetStudents()
        {
            string Baseurl = "http://localhost:53520/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Student");
                if (Res.IsSuccessStatusCode)
                {
                    var student = Res.Content.ReadAsStringAsync().Result;
                    return student;
                }
                return null;
            }
        }
        public async Task<string> AddS(string students)
        {
            string Baseurl = "http://localhost:53520/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var stringContent = new StringContent(students, UnicodeEncoding.UTF8, "application/json");
                HttpResponseMessage Res = await client.PostAsync("api/Student", stringContent);

                if (Res.IsSuccessStatusCode)
                {
                    var student = Res.Content.ReadAsStringAsync().Result;
                    return student;
                }
                return null;
            }
        }

        public async Task<string> EditS(string students)
        {
            string Baseurl = "http://localhost:53520/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var stringContent = new StringContent(students, UnicodeEncoding.UTF8, "application/json");
                HttpResponseMessage Res = await client.PutAsync("api/Student", stringContent);

                if (Res.IsSuccessStatusCode)
                {
                    var student = Res.Content.ReadAsStringAsync().Result;
                    return student;
                }
                return null;
            }
        }
        public async Task<string> DeleteS(int id)
        {
            string Baseurl = "http://localhost:53520";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.DeleteAsync("api/Student/" + id.ToString());

                if (Res.IsSuccessStatusCode)
                {
                    var UserResponse = Res.Content.ReadAsStringAsync().Result;
                    return UserResponse;
                }
                return null;
            }
        }
    }
}
