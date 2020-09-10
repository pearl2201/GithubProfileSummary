using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GithubPfSm.Entities
{
    public class CommitContent 
    {
        public CommitContent() { }



        public string Message { get;  set; }

        public Committer Author { get;  set; }

        public Committer Committer { get;  set; }

        public GitReference Tree { get;  set; }

        public List<GitReference> Parents { get;  set; }
        [JsonProperty("comment_count")]
        public int CommentCount { get;  set; }

        public Verification Verification { get;  set; }

       
    }
}
