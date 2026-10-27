using Backend.Repositories;
using Core;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/product")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository repository;

    public ProductController(IProductRepository repository)
    {
        this.repository = repository;
    }

    // READ
    [HttpGet]
    public Product[] GetAll()
    {
        return repository.GetAll();
    }

    // CREATE
    [HttpPost]
    public void AddProduct(Product product)
    {
        repository.AddProduct(product);
    }

    // UPDATE
    [HttpPut("{id:int}")]
    public void UpdateProduct(int id, Product product)
    {
        product.Id = id;

        repository.UpdateProduct(product);
    }

    // DELETE
    [HttpDelete("{id:int}")]
    public void DeleteProduct(int id)
    {
        repository.DeleteById(id);
    }
}