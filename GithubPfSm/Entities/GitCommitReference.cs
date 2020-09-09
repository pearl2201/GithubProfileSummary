using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubPfSm.Entities
{
    public class GitCommitReference : GitReference
    {
        public Commit Commit { get; set; }
    }
}
