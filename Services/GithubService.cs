using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GithubPfSm.Entities;
using GithubPfSm.Models.Responses;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading;
using System.Net.Http.Json;

namespace GithubPfSm.Services
{
    public class GithubService
    {


        private HttpClient httpClient;

        public GithubService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
/*             var fakeToken = "1efa9xxxfd2fee5fxxx1axxxfc6xxx3eaxxx4aa";
            var token = token.Replace("xxx", ""); */
            var token = "add your token here";
            if (string.Equals("token","add your token here"))
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"token {token}");
            }
            
        }
        public async Task<SearchUserResponse> SearchUserAsync(string key)
        {
            var url = $"https://api.github.com/search/users?q={key}";


            var content = await httpClient.GetStringAsync(url);

            var result = JsonConvert.DeserializeObject<SearchUserResponse>(content);
            return result;
        }

        public async Task<User> GetUserAsync(string username)
        {
            var url = $"https://api.github.com/users/{username}";


            var content = await httpClient.GetStringAsync(url);

            var result = JsonConvert.DeserializeObject<User>(content);
            return result;
        }

        public async Task<List<Repository>> GetUserRepos(string username)
        {
            int currentPage = 1;
            bool isLast = false;
            var repos = new List<Repository>();
            var url = $"https://api.github.com/users/{username}/repos?page={currentPage}&type=owner";
            while (!isLast)
            {

                Console.WriteLine($"Url: {url}");
                var request = new HttpRequestMessage()
                {
                    Method = new HttpMethod("Get"),
                    RequestUri = new Uri(url)
                };

                var response = await httpClient.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<List<Repository>>(content);

                repos.AddRange(result);
                PageLinks pageLinks = new PageLinks(response);
                var nextUrl = pageLinks.getNext();
                if (!string.IsNullOrEmpty(nextUrl))
                {
                    url = nextUrl;
                    isLast = false;
                }
                else
                {
                    isLast = true;
                }
            }

            return repos;
        }

        private readonly Mutex _mut = new Mutex();
        public async Task<List<Commit>> GetUserReposCommits(string username, string repo)
        {
            _mut.WaitOne();
            int currentPage = 1;
            bool isLast = false;
            var commits = new List<Commit>();

            var url = $"https://api.github.com/repos/{username}/{repo}/commits?page={currentPage}";
            while (!isLast)
            {
                Console.WriteLine($"Url: {url}");
                var request = new HttpRequestMessage()
                {
                    Method = new HttpMethod("Get"),
                    RequestUri = new Uri(url)
                };

                var response = await httpClient.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<List<Commit>>(content);

                commits.AddRange(result);
                PageLinks pageLinks = new PageLinks(response);
                var nextUrl = pageLinks.getNext();
                if (!string.IsNullOrEmpty(nextUrl))
                {
                    url = nextUrl;
                    isLast = false;
                }
                else
                {
                    isLast = true;
                }
                await Task.Delay(TimeSpan.FromSeconds(1));
            }


            _mut.ReleaseMutex();
            return commits;
        }

    }
}