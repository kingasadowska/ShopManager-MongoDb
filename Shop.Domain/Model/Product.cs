using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Shop.Domain.Model
{
    public class Product
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public decimal Price { get; set; }
        public string NameOfProduct { get; set; }
        public int Quantity { get; set; }
    }
}
