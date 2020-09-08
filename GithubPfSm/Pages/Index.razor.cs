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

namespace GithubPfSm.Pages
{
    public partial class Index
    {
        [Inject]
        private HttpClient Http { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }


        public Index()
        {

        }

     

        private Task<string> _oldTask;
        private List<GithubPfSm.Entities.User> _items = new List<GithubPfSm.Entities.User>();

        private async void OnSearch(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (_oldTask == null || _oldTask.IsCompleted)
                {
                    var key = HttpUtility.UrlEncode(value);
                    var url = $"https://api.github.com/search/users?q={key}";

                    _oldTask = Http.GetStringAsync(url);
                    var content = await _oldTask;

                    var result = JsonConvert.DeserializeObject<SearchUserResponse>(content);
                    _items.Clear();
                    foreach (var item in result.Items)
                    {
                        _items.Add(item);
                    }
                    Console.WriteLine("ItemCount: " + _items.Count);
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
    }
}