using System.Collections.Generic;
using GithubPfSm.Entities;
using Octokit;

namespace GithubPfSm.Services {
    public class UserService {

        public bool UserExists (string name) {
            return false;
        }

        public bool CanLoadUser (string name) {
            return false;
        }

        public UserProfile GetUserProfile (string username) {
            return null;
        }

        public bool HasStaredRepo (string username) {
            return false;
        }

        public List<RepositoryCommit> CommitsForRepo (Repository repo) {
            return null;
        }
    }

}