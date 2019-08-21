using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EasyFrench
{
    public class Videos
    {
        public HttpClient client = new HttpClient();

        public string Data = "";

        public List<string> VidIDs = new List<string>();
        public List<string> Thumbs = new List<string>();
        public List<string> Titles = new List<string>();

        public async Task GrabVidsAndSetData(string search)
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                VidIDs.Clear();
                Thumbs.Clear();
                Titles.Clear();

                // grab 20 vids
                HttpResponseMessage response = await client.GetAsync("https://www.googleapis.com/youtube/v3/search?key=AIzaSyAvhsM6S8SHqTokQ-O9N5jBBdyE7vzD_qw&part=snippet&maxResults=20&type=video&q=" + search);
                if (response.IsSuccessStatusCode)
                {
                    Data = await response.Content.ReadAsStringAsync();
                    var results = JsonConvert.DeserializeObject<dynamic>(Data);
                    var items = results.items;

                    foreach (var item in items)
                    {
                        var id = item["id"];
                        var videoID = id.videoId;
                        VidIDs.Add($"https://www.youtube.com/embed/{videoID}?rel=0&amp;controls=1&amp;showinfo=0&autoplay=0");

                        var snippet = item["snippet"];
                        string title = snippet.title;
                        Titles.Add(title);

                        string thumb = snippet.thumbnails.medium.url;
                        if (thumb.Length < 11)
                        {
                            thumb = "images/default.jpg";
                        }
                        Thumbs.Add(thumb);
                    }
                }
            }            
           /* else
            {
                Data = null;
            }*/
        }//GrabVidsAndSetData
    }
}
