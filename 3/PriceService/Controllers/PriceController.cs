using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PriceService.Models;
using PriceService.Repositories;

namespace PriceService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriceController : ControllerBase
    {

        private readonly IPriceRepository _priceRepository;
        private readonly ILogger<PriceController> _logger;
        private readonly IMapper _mapper;

        public PriceController(IPriceRepository priceRepository, ILogger<PriceController> logger, IMapper mapper)
        {
            _priceRepository = priceRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Price> GetAll()
        {
            var priceDbModels = _priceRepository.GetAll();
            return _mapper.Map<IEnumerable<Price>>(priceDbModels);
        }

        [HttpGet("{productId}")]
        public IEnumerable<Price> GetByProductId(Guid productId)
        {
            var priceDbModels = _priceRepository.GetByProductId(productId);
            return _mapper.Map<IEnumerable<Price>>(priceDbModels);
        }

        [Authorize]
        [HttpPost]
        public Task Create(Guid productId, double Retail, double Cost, double Current)
        {
            var entity = new PriceDbModel(productId, Retail, Cost, Current);
            return _priceRepository.Create(entity);
        }

        [Authorize]
        [HttpPut]
        public Task Update(Guid productId, double Current)
        {
            return _priceRepository.UpdateByProductId(productId, Current);
        }

        [Authorize]
        [HttpDelete]
        public Task Delete(Guid productId)
        {
            return _priceRepository.DeleteByProductId(productId);
        }

        

    }
}