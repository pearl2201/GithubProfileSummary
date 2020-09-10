using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace GithubPfSm.Entities
{
    public class GitReference
    {
        public GitReference() { }

        public GitReference(string nodeId, string url, string sha)
        {
            NodeId = nodeId;
            Url = url;
            Sha = sha;
        }

        [JsonProperty("node_id")]
        /// <summary>
        /// GraphQL Node Id
        /// </summary>
        public string NodeId { get;  set; }

        /// <summary>
        /// The URL associated with this reference.
        /// </summary>
        public string Url { get;  set; }
        
        [JsonProperty("html_url")]
        /// <summary>
        /// The URL associated with this reference.
        /// </summary>
        public string HtmlUrl { get;  set; }


   
        /// <summary>
        /// The sha value of the reference.
        /// </summary>
        public string Sha { get;  set; }



        internal string DebuggerDisplay
        {
            get
            {
                return string.Format(CultureInfo.InvariantCulture, "Sha: {0}", Sha);
            }
        }
    }
}
