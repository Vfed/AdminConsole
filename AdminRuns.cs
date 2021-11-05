using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

using AdminConsole.Models;
using System.Linq;

namespace AdminConsole
{
    class AdminRuns
    {
        private static string _token ="";
        private static string _username = "";

        private static readonly HttpClient client = new HttpClient();

        
        static async Task<Responce> Login(AdminUserDto dto)
        {
            Responce responceResult = null;
            HttpResponseMessage response = await client.PostAsJsonAsync("token", dto);
            if (response.IsSuccessStatusCode)
            {
                responceResult = await response.Content.ReadAsAsync<Responce>();
                }
            return responceResult;
        }

        static async Task<string> GetRole()
        {
            string userRole = "";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",  _token);
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress + $"getuserrole");

            if (response.IsSuccessStatusCode)
            {
                var Role = await response.Content.ReadAsAsync<string>();
            }
            return userRole;
        }

        public static async Task RunAsync()
        {

            client.BaseAddress = new Uri("https://localhost:5001/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("*");

            try
            {
                Responce resp = await Login(new AdminUserDto { Login = "admin@gmail.com", Password = "12345" });
                if (resp != null)
                {
                    _token = resp.access_token;
                    _username = resp.username;
                    string role = await GetRole();
                    Console.WriteLine(role);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}


//static async Task<List<ChatUser>> GetAllUsersAsync()
        //{
        //    List<ChatUser> chatUsers = null;

        //    HttpResponseMessage response = await client.GetAsync(client.BaseAddress + $"api/admin/");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        chatUsers = await response.Content.ReadAsAsync<List<ChatUser>>();
        //    }
        //    return chatUsers;
        //}
        //static async Task<IEnumerable<string>> LoginCookies(AdminUserDto dto)
        //{
        //    HttpResponseMessage response = await client.PostAsJsonAsync("api/admin/login", dto);
        //    response.EnsureSuccessStatusCode();

        //    IEnumerable<string> cookies = response.Headers.SingleOrDefault(header => header.Key == "Set-Cookie").Value;
        //    return cookies;
        //}
        //static async Task<Uri> Login(AdminUserDto dto)
        //{
        //    HttpResponseMessage response = await client.PostAsJsonAsync("api/admin/login", dto);
        //    response.EnsureSuccessStatusCode();
        //    IEnumerable<string> cookies = response.Headers.SingleOrDefault(header => header.Key == "Set-Cookie").Value;
        //    return response.Headers.Location;
        //}