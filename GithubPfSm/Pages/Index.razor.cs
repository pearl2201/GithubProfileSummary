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

namespace GithubPfSm.Pages {
    public partial class Index {

        private readonly HttpClient Http;
        public Index (HttpClient http) {
            Http = http;
        }
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

        AntDesign.Charts.LineConfig config = new AntDesign.Charts.LineConfig () {
            title = new AntDesign.Charts.Title () {
            visible = true,
            text = "曲线折线图",
            },
            description = new AntDesign.Charts.Description () {
            visible = true,
            text = "用平滑的曲线代替折线。",
            },
            padding = "auto",
            forceFit = true,
            xField = "year",
            yField = "value",
            smooth = true,
        };

        private Task<string> _oldTask;
        private List<string> _items = new List<string> ();

        private async void OnSearch (string value) {
            if (!string.IsNullOrWhiteSpace (value)) {
                if (_oldTask == null || _oldTask.IsCompleted) {
                    var key = HttpUtility.UrlEncode (value);
                    var url = $"https://suggest.taobao.com/sug?code=utf-8&q={key}";

                    _oldTask = Http.GetStringAsync (url);
                    var content = await _oldTask;

                    var result = JsonSerializer.Deserialize<ApiResult> (content);
                    _items.Clear ();
                    foreach (var item in result.result) {
                        _items.Add (item[0]);
                    }

                    StateHasChanged ();
                }
            }
        }

        private void OnChange (OneOf<string, IEnumerable<string>, AntDesign.LabeledValue, IEnumerable<AntDesign.LabeledValue>> value, OneOf<AntDesign.SelectOption, IEnumerable<AntDesign.SelectOption>> option) {
            Console.WriteLine ($"selected: ${value}");
        }

        public class ApiResult {
            public List<string[]> result { get; set; }
        }
    }
}