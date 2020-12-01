using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductService.Clients;
using ProductService.Interfaces;
using ProductService.Models;
using System.Web.Http;
using ProductService.Repository;

namespace ProductService.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductContext _productContext;
        private readonly IMapper _mapper;
        private readonly IImageClient _imageClient;
        private readonly IPriceClient _priceClient;

        public ProductService(ProductContext productContext, IMapper mapper,
            IImageClient imageClient, IPriceClient priceClient)
        {
            _productContext = productContext;
            _mapper = mapper;
            _imageClient = imageClient;
            _priceClient = priceClient;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var productsEntities = await _productContext.Product
                .Where(i => i.IsDeleted == false)
                .ToListAsync();
           
            var products = _mapper.Map<IEnumerable<Product>>(productsEntities);

            foreach (var product in products)
            {
                product.Images = await _imageClient.GetByProductId(product.Id);
                product.Prices = await _priceClient.GetByProductId(product.Id);
            }
            return products;
        }

        public async Task<Product> GetByProductId(Guid productId)
        {
            var productEntity = await _productContext.Product
                .FirstOrDefaultAsync(i => i.IsDeleted == false && i.Id == productId);

            if (productEntity == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            var product = _mapper.Map<Product>(productEntity);

            product.Images = await _imageClient.GetByProductId(product.Id);
            product.Prices = await _priceClient.GetByProductId(product.Id);

            return product;
        }

        public async Task Create(string name, string description)
        {
            var product = new ProductDbModel(name, description);

            await _productContext.Product.AddAsync(product);
            await _productContext.SaveChangesAsync();
        }

        public async Task Update(Guid productId, string name, string description)
        {
            var productEntity = await _productContext.Product
                .FirstOrDefaultAsync(i => i.IsDeleted == false && i.Id == productId);

            if (productEntity == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            productEntity.Name = name;
            productEntity.Description = description;
            productEntity.Update();

            _productContext.Product.UpdateRange(productEntity);
            await _productContext.SaveChangesAsync();
        }

        public async Task Delete(Guid productId)
        {
            var productEntity = await _productContext.Product
                .FirstOrDefaultAsync(i => i.IsDeleted == false && i.Id == productId);

            if (productEntity == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            productEntity.IsDeleted = true;
            productEntity.Update();

            _productContext.Product.UpdateRange(productEntity);
            await _productContext.SaveChangesAsync();
        }
    }
}
