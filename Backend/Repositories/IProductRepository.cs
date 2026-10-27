using Core;

namespace Backend.Repositories;

public interface IProductRepository
{
    Product[] GetAll();

    void AddProduct(Product product);

    void UpdateProduct(Product product);

    void DeleteById(int id);
}