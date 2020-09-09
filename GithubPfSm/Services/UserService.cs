using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.WebSockets;
using System.Threading.Tasks;
using GithubPfSm.Entities;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace GithubPfSm.Services {
    public class UserService {


        [Inject]
        private GithubService GithubService { get; set; }

        public UserService () {

        }

        public bool UserExists (string name) {
            return false;
        }

        public bool CanLoadUser (string name) {
            return false;
        }

        public async Task<UserProfile> GetUserProfile (string username) {
           
            UserProfile profile = new UserProfile();
            
            var user = await GithubService.GetUserAsync(username);
            
            var repos = (await GithubService.GetUserRepos(username)).Where(x => !x.Fork && x.Size != 0);
            
            var repoCommits = (await Task.WhenAll(repos.Select(x => GithubService.GetUserReposCommits(username, x.Name)))).Where(x => x.Author.Name.Equals(username, System.StringComparison.OrdinalIgnoreCase));

            var langRepoGrouping = repos.GroupBy(x => x.Language ?? "Unknown");

            var accountCreationDate = QuarterYear.GetQuarter(user.CreatedAt);
            var currentQuarterDate = QuarterYear.GetQuarter(DateTime.Now);
            List<QuarterYear> quarterYears = new List<QuarterYear>() { };
            var tempQuaterYear = accountCreationDate;
            while (tempQuaterYear != currentQuarterDate)
            {
                quarterYears.Add(tempQuaterYear);
                tempQuaterYear = tempQuaterYear.Next();
            }
            
            if (currentQuarterDate != accountCreationDate)
            {
                quarterYears.Add(currentQuarterDate);
            }
            var quarterCommitCount = repoCommits.GroupBy(x => QuarterYear.GetQuarter(x.Committer.Date.UtcDateTime).ToString()).ToDictionary(x => x.Key, x => x.Count());

            var langRepoCount = langRepoGrouping.ToDictionary(x => x.Key, x => x.Count());

            var langStarCount = langRepoGrouping.ToDictionary(x => x.Key, x => x.Select(x => x.StargazersCount).Sum());

            var langCommitCount = langRepoGrouping.ToDictionary(x => x.Key, x => x.Select(x => x.Size).Sum());

            var repoCommitCount = 0;

            var repoStarCount = 0;

            var repoCommitCountDescriptions = 0;

            var repoStarCountDescriptions = 0;

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