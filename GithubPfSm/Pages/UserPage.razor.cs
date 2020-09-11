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

        object[] data = new object[] {
        new { year = "1991", value = 3 },
        new { year = "1992", value = 4 },
        new { year = "1993", value = 3.5 },
        new { year = "1994", value = 5 },
        new { year = "1995", value = 4.9 },
        new { year = "1996", value = 6 },
        new { year = "1997", value = 7 },
        new { year = "1998", value = 9 },
        new { year = "1999", value = 13 },
        };

        LineConfig config = new LineConfig()
        {
            Title = new AntDesign.Charts.Title()
            {
                Visible = true,
                Text = "曲线折线图",
            },
            Description = new AntDesign.Charts.Description()
            {
                Visible = true,
                Text = "用平滑的曲线代替折线。",
            },
            Padding = "auto",
            ForceFit = true,
            XField = "year",
            YField = "value",
            Smooth = true,
        };

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
                Text = "Stars Per Language",
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
                Text = "Stars Per Language",
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
                Text = "Stars Per Language",
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

        public class QuaterCommitCount
        {
            public string Quarter { get; set; }

            public int Commits { get; set; }
        }
        private object[] reposPerLanguageData;

        public class ReposPerLanguage
        {
            public string Lang { get; set; }
            public int Repos { get; set; }
        }
        private object[] starsPerLanguageData;

        public class StarsPerLanguage
        {
            public string Lang { get; set; }
            public int Stars { get; set; }
        }

        private object[] commitsPerLanguageData;

        public class CommitsPerLanguage
        {
            public string Lang { get; set; }
            public int Commits { get; set; }
        }

        private object[] commitsPerRepoData;

        public class CommitsPerRepo
        {
            public string Repo { get; set; }
            public int Commits { get; set; }
        }

        private object[] starsPerRepoData;

        public class StarsPerRepo
        {
            public string Repo { get; set; }
            public int Stars { get; set; }
        }


        private GithubPfSm.Entities.UserProfile userProfile;
        protected override async Task OnInitializedAsync()
        {
            userProfile = await UserService.GetUserProfile(Username);
            quaterCommitCountData = userProfile.QuarterCommitCount.Select(x => new { quarter = x.Key, commits = x.Value }).ToArray();
            reposPerLanguageData = userProfile.LangRepoCount.Select(x => new { lang = x.Key, repos = x.Value }).ToArray();
            starsPerLanguageData = userProfile.LangStarCount.Select(x => new { lang = x.Key, stars = x.Value }).ToArray();
            commitsPerLanguageData = userProfile.LangStarCount.Select(x => new { lang = x.Key, commits = x.Value }).ToArray();
            commitsPerRepoData = userProfile.LangStarCount.Select(x => new { repo = x.Key, commits = x.Value }).ToArray();
            starsPerRepoData = userProfile.LangStarCount.Select(x => new { repo = x.Key, stars = x.Value }).ToArray();
        }
    }
}