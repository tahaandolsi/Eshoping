using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data
{
    public class TypeContextSeed
    {
        public static void SeedData(IMongoCollection<ProductType> typeCollection)
        {
            bool checkTypes = typeCollection.Find(b => true).Any();
            string path = Path.Combine("Data", "SeedData", "types.json");
            //string baseDirectory = "C:\\Users\\TAHA\\Desktop\\Eshoping\\Services\\Catalog\\Eshoping\\Catalog.Infrastructure\\";
            //string absolutePath = Path.GetFullPath(baseDirectory + path);
            if (!checkTypes)
            {
                var typesData = File.ReadAllText(path);
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                if (types != null)
                {
                    foreach (var item in types)
                    {
                        typeCollection.InsertOneAsync(item);
                    }
                }
            }
        }
    }
}
