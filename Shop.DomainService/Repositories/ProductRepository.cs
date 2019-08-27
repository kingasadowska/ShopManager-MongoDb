using MongoDB.Driver;
using Shop.Domain.Model;
using Shop.DomainService.Repositories.Abstract;
using System.Collections.Generic;

namespace Shop.DomainService.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public IMongoCollection<Product> GetAccessToDb()
        {
            var client = new MongoClient();
            var db = client.GetDatabase("shop");
            var collection = db.GetCollection<Product>("product");
            return collection;
        }

        public void AddProduct(string name, decimal price, uint quantity = 0)
        {
            var newProduct = new Product()
            {
                NameOfProduct = name,
                Price = price,
                Quantity = 0,
            };

            var collection = GetAccessToDb();

            var entity = collection
                .Find(document => document
                                      .NameOfProduct.ToLowerInvariant() == name.ToLowerInvariant())
                                        .FirstOrDefault();

            if (entity == null)
            {
               collection.InsertOne(newProduct);
            }
        }

        public (decimal, string, int) AddToStorage(string name, int quantity)
        {
            var collection = GetAccessToDb();

            var entity = collection
                .Find(document => document.NameOfProduct.ToLowerInvariant() == name.ToLowerInvariant()).FirstOrDefault();

            var sumOfQuantity = entity.Quantity + quantity;

            var update = Builders<Product>
                .Update.Set(el => el.Quantity, sumOfQuantity);

            collection.UpdateOne<Product>(document => document.NameOfProduct.ToLowerInvariant() == name.ToLowerInvariant(), update);

            return (entity.Price, entity.NameOfProduct, sumOfQuantity);
        }

        public (string, decimal, bool) BuyProduct(string name, int quantity)
        {
            var collection = GetAccessToDb();

            var entity = collection
                .Find(document => document.NameOfProduct.ToLowerInvariant() == name.ToLowerInvariant()).FirstOrDefault();

            var avaiableQuantity = entity.Quantity;

            var ableToBuyQuantity = avaiableQuantity - quantity;

            if (ableToBuyQuantity < 0)
            {
                return (entity.NameOfProduct, 0, false);
            }

            var update = Builders<Product>.Update.Set(el => el.Quantity, ableToBuyQuantity);
            collection.UpdateOne<Product>
                (document => document.NameOfProduct.ToLowerInvariant() == name.ToLowerInvariant(), update);

            var sumOfPriceFromProducts = entity.Price * quantity;

            return (entity.NameOfProduct, sumOfPriceFromProducts, true);
        }

        public List<Product> GetAvaiableProductsFromDb()
        {
            var collection = GetAccessToDb();
            var avaiableProducts = collection
                .Find(document => document.Quantity > 0).ToList();
            return (avaiableProducts);
        }

       
    }
}
