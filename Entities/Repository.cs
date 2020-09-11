using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GithubPfSm.Entities
{
    public class Repository
    {
        public Repository() { }

        public Repository(long id)
        {
            Id = id;
        }

        public Repository(string url, string htmlUrl, string cloneUrl, string gitUrl, string sshUrl, string svnUrl, string mirrorUrl, long id, string nodeId, User owner, string name, string fullName, bool isTemplate, string description, string homepage, string language, bool @private, bool fork, int forksCount, int stargazersCount, string defaultBranch, int openIssuesCount, DateTimeOffset? pushedAt, DateTimeOffset createdAt, DateTimeOffset updatedAt, Repository parent, Repository source, LicenseMetadata license, bool hasIssues, bool hasWiki, bool hasDownloads, bool hasPages, int subscribersCount, long size, bool? allowRebaseMerge, bool? allowSquashMerge, bool? allowMergeCommit, bool archived, int watchersCount)
        {
            Url = url;
            HtmlUrl = htmlUrl;
            CloneUrl = cloneUrl;
            GitUrl = gitUrl;
            SshUrl = sshUrl;
            SvnUrl = svnUrl;
            MirrorUrl = mirrorUrl;
            Id = id;
            NodeId = nodeId;
            Owner = owner;
            Name = name;
            FullName = fullName;
            IsTemplate = isTemplate;
            Description = description;
            Homepage = homepage;
            Language = language;
            Private = @private;
            Fork = fork;
            ForksCount = forksCount;
            StargazersCount = stargazersCount;
            DefaultBranch = defaultBranch;
            OpenIssuesCount = openIssuesCount;
            PushedAt = pushedAt;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Parent = parent;
            Source = source;
            License = license;
            HasIssues = hasIssues;
            HasWiki = hasWiki;
            HasDownloads = hasDownloads;
            HasPages = hasPages;
            SubscribersCount = subscribersCount;
            Size = size;
            AllowRebaseMerge = allowRebaseMerge;
            AllowSquashMerge = allowSquashMerge;
            AllowMergeCommit = allowMergeCommit;
            Archived = archived;
            WatchersCount = watchersCount;
        }

        public string Url { get;  set; }
        [JsonProperty("html_url")]
        public string HtmlUrl { get;  set; }
        [JsonProperty("clone_url")]
        public string CloneUrl { get;  set; }

        [JsonProperty("git_url")]
        public string GitUrl { get;  set; }

        [JsonProperty("ssh_url")]
        public string SshUrl { get;  set; }

        [JsonProperty("svn_url")]
        public string SvnUrl { get;  set; }

        [JsonProperty("mirror_url")]
        public string MirrorUrl { get;  set; }

        public long Id { get;  set; }

        /// <summary>
        /// GraphQL Node Id
        /// </summary>
        [JsonProperty("node_id")]
        public string NodeId { get;  set; }

        public User Owner { get;  set; }

        public string Name { get;  set; }

        [JsonProperty("full_name")]
        public string FullName { get;  set; }

        public bool IsTemplate { get;  set; }

        public string Description { get;  set; }

        public string Homepage { get;  set; }

        public string Language { get;  set; }

        public bool Private { get;  set; }

        public bool Fork { get;  set; }
        [JsonProperty("forks_count")]
        public int ForksCount { get;  set; }
        [JsonProperty("stargazers_count")]
        public int StargazersCount { get;  set; }
        [JsonProperty("watchers_count")]
        public int WatchersCount { get;  set; }
        [JsonProperty("default_branch")]
        public string DefaultBranch { get;  set; }
        [JsonProperty("open_issues_count")]
        public int OpenIssuesCount { get;  set; }

        [JsonProperty("pushed_at")]
        public DateTimeOffset? PushedAt { get;  set; }
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get;  set; }
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get;  set; }



        public Repository Parent { get;  set; }

        public Repository Source { get;  set; }

        public LicenseMetadata License { get;  set; }
        [JsonProperty("has_issues")]
        public bool HasIssues { get;  set; }
        [JsonProperty("has_wiki")]
        public bool HasWiki { get;  set; }
        [JsonProperty("has_downloads")]
        public bool HasDownloads { get;  set; }

        public bool? AllowRebaseMerge { get;  set; }

        public bool? AllowSquashMerge { get;  set; }

        public bool? AllowMergeCommit { get;  set; }
        [JsonProperty("has_pages")]
        public bool HasPages { get;  set; }

        [Obsolete("Update your code to use WatchersCount as this field will stop containing data in the future")]
        public int SubscribersCount { get;  set; }

        public long Size { get;  set; }

        public bool Archived { get;  set; }

        internal string DebuggerDisplay
        {
            get
            {
                return string.Format(CultureInfo.InvariantCulture,
                    "Repository: Id: {0} Owner: {1}, Name: {2}", Id, Owner, Name);
            }
        }
    }
}
