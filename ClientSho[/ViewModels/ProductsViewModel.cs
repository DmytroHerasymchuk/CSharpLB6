using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Server.Models;
using Newtonsoft.Json;

namespace ClientShop.ViewModels
{
    public class ProductsViewModel
    {
        public ObservableCollection<Product> Products;
        public ProductsViewModel()
        {
            Products = new ObservableCollection<Product>()
            {
                new Product() { Name = "Banana", Quantity = 2, PriceClient = 10, PriceShop = 8 },
                new Product() { Name = "Apple", Quantity = 5, PriceClient = 7, PriceShop = 5 },
                new Product() { Name = "Orange", Quantity = 3, PriceClient = 12, PriceShop = 11 },
                new Product() { Name = "Pear", Quantity = 1, PriceClient = 4, PriceShop = 3 }
            };
        }

        public async Task<ObservableCollection<Product>> GetAllProducts()
        {
            using (HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5161/stock");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    var list = await response.Content.ReadAsStringAsync();
                    var json = JsonConvert.DeserializeObject<ObservableCollection<Product>>(list);
                    return json;
                }
                return null;
            }
        }

        public async void BuyProduct(Product product)
        {
            
            using (HttpClient client = new HttpClient())
            {               
                string name = product.Name;
                var request = new HttpRequestMessage(HttpMethod.Get, $"http://localhost:5161/stock/{name}");               
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var productFromServer = JsonConvert.DeserializeObject<Product>(json);                
                    if (CheckInList(productFromServer))
                    {
                        if (productFromServer.Quantity > 0)
                        {
                            Products.FirstOrDefault(x => x.Name == name).Quantity++;
                        }                       
                    }
                    else
                    {
                        productFromServer.Quantity = 1;
                        Products.Add(productFromServer);
                    }
                    
                }
            }
        }

        public bool CheckInList(Product product)
        {
            if(Products.Any(x => x.Name == product.Name))
            {
                return true;
            }
            return false;
        }
    }
}
