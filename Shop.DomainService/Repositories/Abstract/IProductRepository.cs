using MongoDB.Driver;
using Shop.Domain.Model;
using System.Collections.Generic;

namespace Shop.DomainService.Repositories.Abstract
{
    public interface IProductRepository
    {
        void AddProduct(string name, decimal price, uint quantity);
        (decimal, string, int) AddToStorage(string id, int quantity);
        (string, decimal, bool) BuyProduct(string id, int quantity);
        List<Product> GetAvaiableProductsFromDb();
        IMongoCollection<Product> GetAccessToDb();
    }
}
