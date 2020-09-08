using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GithubPfSm.Entities;
using Newtonsoft.Json;
using Octokit;

namespace GithubPfSm.Services {
    public class UserService {

        
        public UserService () {

        }

        public bool UserExists (string name) {
            return false;
        }

        public bool CanLoadUser (string name) {
            return false;
        }

        public async Task<UserProfile> GetUserProfile (string username) {
            var url = $"https://api.github.com/users/{username}";
            var httpClient  = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization","token 4ea53f0dfa99d5915a9575a919b36ea4e0387c9a");
            var content = await httpClient.GetStringAsync (url);

            var user = JsonConvert.DeserializeObject<Entities.User> (content);
            UserProfile profile = new UserProfile();
            profile.User = user;

            return profile;
        }

        public bool HasStaredRepo (string username) {
            return false;
        }

        public List<RepositoryCommit> CommitsForRepo (Repository repo) {
            return null;
        }
    }

}