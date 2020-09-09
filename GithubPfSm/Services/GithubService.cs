using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GithubPfSm.Entities;
using GithubPfSm.Models.Responses;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace GithubPfSm.Services
{
    public class GithubService
    {

        [Inject]
        private HttpClient httpClient { get; set; }
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
            var url = $"https://api.github.com/users/{username}/repos";


            var content = await httpClient.GetStringAsync(url);

            var result = JsonConvert.DeserializeObject<List<Repository>>(content);
            return result;
        }

        public async Task<Commit> GetUserReposCommits(string username, string repo)
        {
            var url = $"https://api.github.com/repos/{username}/{repo}/commits";


            var content = await httpClient.GetStringAsync(url);

            var result = JsonConvert.DeserializeObject<Commit>(content);
            return result;
        }

    }
}