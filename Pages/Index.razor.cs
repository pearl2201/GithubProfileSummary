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
    public partial class Index
    {
        [Inject]
        private HttpClient Http { get; set; }

        [Inject]
        private GithubService GithubService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private IConfiguration Configuration { get; set; }

        public Index()
        {

        }

     

        private Task<SearchUserResponse> _oldTask;
        private List<IndexSearchUser> _items = new List<IndexSearchUser>();

        private async Task OnSearch(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (_oldTask == null || _oldTask.IsCompleted)
                {
                    _oldTask = GithubService.SearchUserAsync(value);
                    var result = await _oldTask; 
                    _items.Clear();
                    foreach (var item in result.Items)
                    {
                        _items.Add(item);
                    }
                    StateHasChanged();
                }
            }
        }

        private void OnChange(OneOf<string, IEnumerable<string>, AntDesign.LabeledValue, IEnumerable<AntDesign.LabeledValue>> value, OneOf<AntDesign.SelectOption, IEnumerable<AntDesign.SelectOption>> option)
        {
            string username = value.AsT0;
            Console.WriteLine($"Select {username}");
            NavigationManager.NavigateTo($"/users/pearl2201");
        }

        public class ApiResult
        {
            public List<string[]> result { get; set; }
        }

          public void GotoUser(string username)
        {
            NavigationManager.NavigateTo(NavigationManager.ToBaseRelativePath($"/users/{username}"));
        }
    }
}