using GithubPfSm.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubPfSm.Models.Responses
{
    public class SearchUserResponse
    {
        [JsonProperty("total_count")]
        public int TotalCount { get; set; }
        [JsonProperty("incomplete_results")]
        public bool IncompleteResults { get; set; }
        [JsonProperty("items")]
        public List<IndexSearchUser> Items { get; set; }

        public SearchUserResponse()
        {
            Items = new List<IndexSearchUser>();
        }
    }
}
