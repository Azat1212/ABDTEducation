using System.Threading.Tasks;
using ImageService.Models;
using Refit;

namespace ImageService.Interfaces
{
    public interface IPoligonClient
    {
        [Get("/v1/disk/resources/?path={path}")]
        public Task<Poligon> GetFileInfo(string path, [Header("Authorization")] string authorization);


        [Get("/v1/disk/resources/upload?path={path}")]
        public Task<Poligon> GetHref(string path, [Header("Authorization")] string authorization);


        [Put("/v1/disk/resources/publish")]
        public Task PublishFile(string path, [Header("Authorization")] string authorization);
    }
}
