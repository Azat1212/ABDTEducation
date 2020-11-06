using System.ComponentModel;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductService.Models;

namespace ProductService.Clients
{
    public interface IImageClient
    {
        [Get("/image")]
        Task<IEnumerable<Image>> GetAll();
    }
}