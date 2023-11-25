using Core.Productadministration;
using System.Collections.Generic;

namespace Core.Persistence
{
    public interface IProductPersistence
    {
        bool UpdateProduct(int id, Product product);
        Product GetProduct(int id);
        Product CreateProduct(Product product);
        List<Product> GetAllProducts();
        void DeleteProduct(int id);
        void DeleteAllProducts();

    }
} 
