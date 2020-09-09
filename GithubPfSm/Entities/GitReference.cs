using Microsoft.AspNetCore.Components;
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

        /// <summary>
        /// GraphQL Node Id
        /// </summary>
        public string NodeId { get; protected set; }

        /// <summary>
        /// The URL associated with this reference.
        /// </summary>
        public string Url { get; protected set; }

   
        /// <summary>
        /// The sha value of the reference.
        /// </summary>
        public string Sha { get; protected set; }



        internal string DebuggerDisplay
        {
            get
            {
                return string.Format(CultureInfo.InvariantCulture, "Sha: {0}", Sha);
            }
        }
    }
}
