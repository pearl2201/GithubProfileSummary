using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubPfSm.Entities
{
    public class Commit
    {
        public Commit() { }



        public string Message { get; protected set; }

        public Committer Author { get; protected set; }

        public Committer Committer { get; protected set; }

        public GitReference Tree { get; protected set; }

        public IReadOnlyList<GitReference> Parents { get; protected set; }

        public int CommentCount { get; protected set; }

        public Verification Verification { get; protected set; }
    }
}
