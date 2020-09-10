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
                Text = "Quarter Commit Count",
            },
            Padding = "auto",
            ForceFit = true,
            XField = "Key",
            YField = "Value",
            Smooth = true,
        };

        private GithubPfSm.Entities.UserProfile userProfile;
        protected override async Task OnInitializedAsync()
        {
            userProfile = await UserService.GetUserProfile(Username);
        }
    }
}