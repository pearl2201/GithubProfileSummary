using System;
using System.Threading;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;
using System.Text.Json;
using System.Web;
using AntDesign.Charts;
using OneOf;
using System.Net.Http;
using Microsoft.AspNetCore.Components;
using GithubPfSm.Entities;
using GithubPfSm.Models.Responses;
using Newtonsoft.Json;
using GithubPfSm.Services;
using Microsoft.Extensions.Configuration;
using System.Linq;


namespace GithubPfSm.Pages
{

    public partial class UserPage
    {
        [Inject]
        public UserService UserService { get; set; }

        [Inject]
        public GithubService GithubService { get; set; }
        [Parameter]
        public string Username { get; set; }

        LineConfig quaterCommitCountConfig = new LineConfig()
        {
            Title = new AntDesign.Charts.Title()
            {
                Visible = true,
                Text = "Commits Per Quater",
            },

            Padding = "auto",
            ForceFit = true,
            XField = "quarter",
            YField = "commits",
            Smooth = true,
            XAxis = new ValueCatTimeAxis()
            {
                Visible = false,
                Label = new BaseAxisLabel()
                {
                    AutoHide = true,
                },
            },
        };

        PieConfig reposPerLanguageConfig = new PieConfig()
        {
            Title = new AntDesign.Charts.Title()
            {
                Visible = true,
                Text = "Repos Per Language",
            },

            Padding = "auto",
            ForceFit = true,
            Radius = 0.8,
            AngleField = "repos",
            ColorField = "lang",
            Label = new PieLabelConfig()
            {
                Visible = false,
                Type = "inner",
            },
        };

        PieConfig starsPerLanguageConfig = new PieConfig()
        {
            Title = new AntDesign.Charts.Title()
            {
                Visible = true,
                Text = "Stars Per Language",
            },

            Padding = "auto",
            ForceFit = true,
            Radius = 0.8,
            AngleField = "stars",
            ColorField = "lang",
            Label = new PieLabelConfig()
            {
                Visible = false,
                Type = "inner",
            },
        };

        PieConfig commitsPerLanguageConfig = new PieConfig()
        {
            Title = new AntDesign.Charts.Title()
            {
                Visible = true,
                Text = "Commits Per Language",
            },

            Padding = "auto",
            ForceFit = true,

            Radius = 0.8,
            AngleField = "commits",
            ColorField = "lang",
            Label = new PieLabelConfig()
            {
                Visible = false,
                Type = "inner",
            },
        };


        PieConfig commitsPerRepoConfig = new PieConfig()
        {
            Title = new AntDesign.Charts.Title()
            {
                Visible = true,
                Text = "Commits Per Repo",
            },

            Padding = "auto",
            ForceFit = true,

            Radius = 0.8,
            AngleField = "commits",
            ColorField = "repo",
            Label = new PieLabelConfig()
            {
                Visible = false,
                Type = "inner",
            }
        };

        PieConfig starsPerRepoConfig = new PieConfig()
        {
            Title = new AntDesign.Charts.Title()
            {
                Visible = true,
                Text = "Stars Per Repo",
            },

            Padding = "auto",
            ForceFit = true,
            Radius = 0.8,
            AngleField = "stars",
            ColorField = "repo",
            Label = new PieLabelConfig()
            {
                Visible = false,
                Type = "inner",
            }
        };

        private object[] quaterCommitCountData;
       
        private object[] reposPerLanguageData;

        private object[] starsPerLanguageData;

        private object[] commitsPerLanguageData;

        private object[] commitsPerRepoData;

 
        private object[] starsPerRepoData;


        private GithubPfSm.Entities.UserProfile userProfile;
        protected override async Task OnInitializedAsync()
        {
            userProfile = await UserService.GetUserProfile(Username);
            quaterCommitCountData = userProfile.QuarterCommitCount.Select(x => new { quarter = x.Key, commits = x.Value }).ToArray();
            reposPerLanguageData = userProfile.LangRepoCount.Select(x => new { lang = x.Key, repos = x.Value }).ToArray();
            starsPerLanguageData = userProfile.LangStarCount.Select(x => new { lang = x.Key, stars = x.Value }).ToArray();
            commitsPerLanguageData = userProfile.LangCommitCount.Select(x => new { lang = x.Key, commits = x.Value }).ToArray();
            commitsPerRepoData = userProfile.RepoCommitCount.Select(x => new { repo = x.Key, commits = x.Value }).ToArray();
            starsPerRepoData = userProfile.RepoStarCount.Select(x => new { repo = x.Key, stars = x.Value }).ToArray();
        }
    }
}