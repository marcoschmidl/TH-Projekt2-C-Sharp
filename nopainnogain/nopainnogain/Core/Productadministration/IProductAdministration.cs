using System.Collections.Generic;

namespace Core.Productadministration
{
    public interface IProductAdministration
    {
        Product CreateProduct(Product product);
        Product GetProduct(int id);
        ICollection<Product> GetAllProduct();
        bool UpdateProduct(int id, Product product);
        void DeleteProduct(int id);
    }
}
