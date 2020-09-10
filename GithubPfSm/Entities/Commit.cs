using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GithubPfSm.Entities
{
    public class Commit : GitReference
    {
        public Commit() { }


        [JsonProperty("commit")]
        public CommitContent Content { get; set; }




        public IndexUser Author { get; set; }

        public IndexUser Committer { get; set; }
        public List<GitReference> Parents { get; set; }
    }
}
