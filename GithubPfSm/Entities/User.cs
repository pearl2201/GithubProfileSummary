using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GithubPfSm.Entities
{

    public class UserProfile
    {
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

    public class User
    {
        public string Login { get; set; }

        public int Id { get; set; }
        [JsonProperty("node_id")]
        public string NodeId { get; set; }
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }
        [JsonProperty("gravatar_id")]
        public string GravatarId { get; set; }
        public string url { get; set; }

        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }

        [JsonProperty("followers_url")]
        public string FollowersUrl { get; set; }

        [JsonProperty("subscriptions_url")]
        public string SubscriptionsUrl { get; set; }

        [JsonProperty("organizations_url")]
        public string OrganizationsUrl { get; set; }

        [JsonProperty("repos_url")]
        public string ReposUrl { get; set; }

        [JsonProperty("received_events_url")]
        public string ReceivedEventsUrl { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        public float Score { get; set; }

        public string Name {get;set;}

        public string Email {get;set;}

               public string Company {get;set;}

        [JsonProperty("public_repos")]
        public int PublicRepos {get;set;}

        [JsonProperty("created_at")]
        public DateTime CreatedAt {get;set;}

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt {get;set;}


    }
}