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
    public class CourseBL
    {
        public async Task<string> GetCourses()
        {
            string Baseurl = "http://localhost:53520/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/Course");

                if (Res.IsSuccessStatusCode)
                {
                    var course = Res.Content.ReadAsStringAsync().Result;
                    return course;
                }
                return null;
            }
        }
        public async Task<string> AddC(string courses)
        {
            string Baseurl = "http://localhost:53520/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var stringContent = new StringContent(courses, UnicodeEncoding.UTF8, "application/json");
                HttpResponseMessage Res = await client.PostAsync("api/Course", stringContent);

                if (Res.IsSuccessStatusCode)
                {
                    var course = Res.Content.ReadAsStringAsync().Result;
                    return course;
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
                HttpResponseMessage Res = await client.PutAsync("api/Course", stringContent);

                if (Res.IsSuccessStatusCode)
                {
                    var course = Res.Content.ReadAsStringAsync().Result;
                    return course;
                }
                return null;
            }
        }


        public async Task<string> DeleteC(int id)
        {
            string Baseurl = "http://localhost:53520";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.DeleteAsync("api/Course/" + id.ToString());

                if (Res.IsSuccessStatusCode)
                {

                    var UserResponse = Res.Content.ReadAsStringAsync().Result;
                    return UserResponse;
                }

                return null;

            }
        }
        public async Task<string> DetailsC()
        {
            string Baseurl = "http://localhost:53520/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                HttpResponseMessage Res = await client.GetAsync("api/Course");

                if (Res.IsSuccessStatusCode)
                {
                    var course = Res.Content.ReadAsStringAsync().Result;
                    return course;
                }
                return null;
            }
        }
    }
}

