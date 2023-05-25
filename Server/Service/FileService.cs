using System.IO;
using Newtonsoft.Json;
using Server.Models;

namespace Server.Service
{
    public class FileService
    {
        private const string _filePath = "D:\\VS Studio\\Repositories\\CSharpLB6\\Server\\bin\\Debug\\net6.0\\data.json";

        public static List<Product> Load()
        {
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(_filePath));
            return products;
        }

        public static void Save(List<Product> products)
        {
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(products));
        }
    }
}
