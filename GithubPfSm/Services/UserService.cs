using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.WebSockets;
using System.Threading.Tasks;
using GithubPfSm.Entities;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace GithubPfSm.Services
{
    public class UserService
    {


        [Inject]
        private GithubService githubService { get; set; }
        private Blazored.LocalStorage.ILocalStorageService localStorage;
        public UserService(GithubService githubService, Blazored.LocalStorage.ILocalStorageService localStorage)
        {
            this.githubService = githubService;
            this.localStorage = localStorage;
        }

        public bool UserExists(string name)
        {
            return false;
        }

        public bool CanLoadUser(string name)
        {
            return false;
        }


        public async Task<UserProfile> GetUserProfile(string username)
        {

            UserProfile profile = await localStorage.GetItemAsync<UserProfile>($"profile-{username}");
           
            if (profile != null && DateTime.UtcNow.Subtract(profile.FetchedAt).TotalMinutes < 60)
            {
                return profile;
            }

            
            var user = await githubService.GetUserAsync(username);

            var repos = (await githubService.GetUserRepos(username)).Where(x => !x.Fork && x.Size != 0).OrderBy(x => x.CreatedAt).ToList();
           

            //  val repoCommits = repos.parallelStream().map { it to commitsForRepo(it).filter { it.author?.login.equals(username, ignoreCase = true) } }.toList().toMap()
            var repoCommits = await Task.WhenAll(repos.Select(async x =>
            {
                var commits = (await githubService.GetUserReposCommits(username, x.Name)).Where(x => x.Author == null ? false : x.Author.Login.Equals(user.Login, System.StringComparison.OrdinalIgnoreCase)).ToList();
                return new KeyValuePair<Repository, List<Commit>>(x, commits);
            }));

            // val langRepoGrouping = repos.groupingBy { (it.language ?: "Unknown") }
            var langRepoGrouping = repos.GroupBy(x => x.Language ?? "Unknown");

            var accountCreationDate = QuarterYear.GetQuarter(user.CreatedAt);
            var currentQuarterDate = QuarterYear.GetQuarter(DateTime.Now);
            var currentQuarterDateString = currentQuarterDate.ToString();
            List<string> quarterYears = new List<string>() { };
            var tempQuaterYear = accountCreationDate;
            while (!quarterYears.Contains(currentQuarterDateString))
            {
                quarterYears.Add(tempQuaterYear.ToString());
                tempQuaterYear = tempQuaterYear.Next();
            }



            // val quarterCommitCount = CommitCountUtil.getCommitsForQuarters(user, repoCommits)
            var tempCommits = repoCommits.SelectMany(x => x.Value).ToList();
            var tempQuarterCommitCount = tempCommits.GroupBy(x => QuarterYear.GetQuarter(x.Content.Committer.Date.UtcDateTime).ToString()).ToDictionary(x => x.Key, x => x.Count());
            var quarterCommitCount = quarterYears.ToDictionary(x => x, x => tempQuarterCommitCount.ContainsKey(x) ? tempQuarterCommitCount[x] : 0);
            // val langRepoCount = langRepoGrouping.eachCount().toList().sortedBy { (_, v) -> -v }.toMap()
            var langRepoCount = langRepoGrouping.ToDictionary(x => x.Key, x => x.Count()).OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            // val langStarCount = langRepoGrouping.fold(0) { acc, repo -> acc + repo.watchers }.toList().sortedBy { (_, v) -> -v }.toMap()
            var langStarCount = langRepoGrouping.ToDictionary(x => x.Key, x => x.Select(x => x.StargazersCount).Sum()).OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            // val langCommitCount = langRepoGrouping.fold(0) { acc, repo -> acc + repoCommits[repo]!!.size }.toList().sortedBy { (_, v) -> -v }.toMap()
            var langCommitCount = langRepoGrouping.ToDictionary(x => x.Key, x => (int)x.Select(x => x.Size).Sum()).OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            // val repoCommitCount = repoCommits.map { it.key.name to it.value.size }.toList().sortedBy { (_, v) -> -v }.take(10).toMap()
            var repoCommitCount = repoCommits.Select(x => new KeyValuePair<string, int>(x.Key.Name, x.Value.Count())).OrderByDescending(x => x.Value).Take(10).ToDictionary(x => x.Key, x => x.Value);

            // val repoStarCount = repos.filter { it.watchers > 0 }.map { it.name to it.watchers }.sortedBy { (_, v) -> -v }.take(10).toMap()
            var repoStarCount = repos.Where(x => x.WatchersCount > 0).OrderByDescending(x => x.WatchersCount).Take(10).ToDictionary(x => x.Name, x => x.WatchersCount);

            // val repoCommitCountDescriptions = repoCommitCount.map { it.key to repos.find { r -> r.name == it.key }?.description }.toMap()
            var repoCommitCountDescriptions = repoCommitCount.ToDictionary(x => x.Key, x => repos.FirstOrDefault(y => y.Name == x.Key)?.Description);

            // val repoStarCountDescriptions = repoStarCount.map { it.key to repos.find { r -> r.name == it.key }?.description }.toMap()
            var repoStarCountDescriptions = repoStarCount.ToDictionary(x => x.Key, x => repos.FirstOrDefault(y => y.Name == x.Key)?.Description);

            profile = new UserProfile()
            {
                User = user,
                LangCommitCount = langCommitCount,
                QuarterCommitCount = quarterCommitCount,
                LangRepoCount = langRepoCount,
                LangStarCount = langStarCount,
                RepoCommitCount = repoCommitCount,
                RepoStarCount = repoStarCount,
                RepoCommitCountDescriptions = repoCommitCountDescriptions,
                RepoStarCountDescriptions = repoStarCountDescriptions,
                FetchedAt = DateTime.UtcNow
            };
            await localStorage.SetItemAsync($"profile-{username}", profile);
            return profile;
        }



        public bool HasStaredRepo(string username)
        {
            return false;
        }

        public List<RepositoryCommit> CommitsForRepo(Repository repo)
        {
            return null;
        }
    }

}