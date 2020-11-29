using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace ImageService
{
    public class YandexDiskConfig
    {
        public Url BaseUrl { get; set; }

        public string AccessToken { get; set; }

        public string AccessScheme { get; set; }

        public string BasePath { get; set; }
    }
}
