using Server.Models;
using Server.Service;

namespace Server.Repositories
{
    public interface IProductsRepository
    {
        IReadOnlyCollection<Product> GetAll();
        Product BuyProduct(string product);
    }
    public class ProductsRepository : IProductsRepository
    {
        private List<Product> _products;

        public ProductsRepository()
        {
            _products = FileService.Load();

        }

        public IReadOnlyCollection<Product> GetAll()
        {
            return _products;
        }


        public Product BuyProduct(string name)
        {
            
            Product product = _products.FirstOrDefault(x => x.Name == name);
            Product prod = new Product()
            {
                Name = product.Name,
                Quantity = product.Quantity,
                PriceClient = product.PriceClient,
                PriceShop = product.PriceShop
            };
            if (product.Quantity > 0)
            {
                product.Quantity--;
            }
            FileService.Save(_products);
            return prod;
            
        }
        
    }
}
