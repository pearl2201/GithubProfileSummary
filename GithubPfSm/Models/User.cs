using System;
using System.Collections.Generic;
using Octokit;

namespace GithubPfSm.Entities {

    public class UserProfile {
        public User User { get; set; }

        public Dictionary<string, int> QuarterCommitCount { get; set; }

        public Dictionary<string, int> LangRepoCount { get; set; }

        public Dictionary<string, int> LangStarCount { get; set; }

        public Dictionary<string, int> LangCommitCount { get; set; }

        public Dictionary<string, int> RepoCommitCount { get; set; }

        public Dictionary<string, int> RepoStarCount { get; set; }

        public Dictionary<string, string> RepoCommitCountDescriptions { get; set; }

        public Dictionary<string, string> RepoStarCountDescriptions { get; set; }

        public DateTime FetchedAt { get; set; }

    }
}