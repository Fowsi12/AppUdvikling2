using Core;

namespace Backend.Repositories;

public class ProductRepositoryInMemory : IProductRepository
{
    private readonly List<Product> products = new();

    private int nextId = 1;

    public Product[] GetAll()
    {
        return products.ToArray();
    }

    public void AddProduct(Product product)
    {
        product.Id = nextId;

        nextId++;

        products.Add(product);
    }

    public void UpdateProduct(Product product)
    {
        Product? existingProduct =
            products.FirstOrDefault(
                p => p.Id == product.Id
            );

        if (existingProduct != null)
        {
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;
            existingProduct.PublishedDate = product.PublishedDate;
            existingProduct.IsPublished = product.IsPublished;
            existingProduct.Stock = product.Stock;
            existingProduct.Category = product.Category;
        }
    }

    public void DeleteById(int id)
    {
        Product? product =
            products.FirstOrDefault(
                p => p.Id == id
            );

        if (product != null)
        {
            products.Remove(product);
        }
    }
}
