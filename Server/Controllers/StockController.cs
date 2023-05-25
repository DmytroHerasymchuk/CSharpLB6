using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Repositories;
using Server.Models;

namespace Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private IProductsRepository _productsRepository;

        public StockController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        [HttpGet]
        public IReadOnlyCollection<Product> GetAll()
        {
            return _productsRepository.GetAll();
        }
        [HttpGet("{name}")]
        public Product Get(string name)
        {
            Product product = _productsRepository.BuyProduct(name);
        
            return product;
        }
    }
}
