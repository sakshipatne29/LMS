using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
namespace BusinessLayer
{
    public class LoginBL
    {
        public async Task<string> Login(string userInfo)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53520/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                UserLoginBL userLogin = JsonConvert.DeserializeObject<UserLoginBL>(userInfo);
                KeyValuePair<string, string> UserName = new KeyValuePair<string, string>("username", userLogin.UserName);
                KeyValuePair<string, string> UserPassword = new KeyValuePair<string, string>("password", userLogin.UserPassword);
                KeyValuePair<string, string> Granttype = new KeyValuePair<string, string>("grant_type", "password");
                List<KeyValuePair<string, string>> mykey = new List<KeyValuePair<string, string>>();
                mykey.Add(UserName);
                mykey.Add(UserPassword);
                mykey.Add(Granttype);
                var formContent = new FormUrlEncodedContent(mykey);
                HttpResponseMessage Res = await client.PostAsync("token", formContent);
                //If success received   
                if (Res.IsSuccessStatusCode)
                {
                    var tokenResponse = Res.Content.ReadAsStringAsync().Result;
                    return tokenResponse;
                }
            }
            return null;
        }
    }
}
