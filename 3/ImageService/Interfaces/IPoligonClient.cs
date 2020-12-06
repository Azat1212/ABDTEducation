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


        //[Get("/v1/disk/resources/files?media_type=image")]
        //Task<ImageModel> GetAllImagesFromYandexDisk([Header("Authorization")] string authorization);

        ///// <summary>
        ///// Получить изображение с яндекс диска по указанному полному пути.
        ///// </summary>
        ///// <param name="fullPath"></param>
        ///// <param name="authorization"></param>
        ///// <returns></returns>
        //[Get("/v1/disk/resources?path={fullPath}")]
        //Task<ImageModel> GetImageFromYandexDisk(string fullPath, [Header("Authorization")] string authorization);

        ///// <summary>
        ///// Загрузить файл в Диск по URL.
        ///// </summary>
        ///// <returns></returns>
        //[Post("/v1/disk/resources/upload?path={fullPath}&url={imageUrl}&fields=href")]
        //Task<string> UploadImageToYandexDisk(string imageUrl, string fullPath, [Header("Authorization")] string authorization);
    }
}
