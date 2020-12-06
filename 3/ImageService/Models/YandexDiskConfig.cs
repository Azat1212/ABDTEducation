using System.Net.Http.Headers;
using System.Security.Policy;
using Newtonsoft.Json;

namespace ImageService.Models
{
    public class YandexDiskConfig
    {
        public Url BaseUrl { get; set; }

        public string AccessToken { get; set; }

        public string AccessScheme { get; set; }

        public string BasePath { get; set; }

    }
}
