using Backend.Repositories;
using Core;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/todo")]
public class TodoController : ControllerBase
{
    private readonly ITodoRepository repository;

    public TodoController(ITodoRepository repository)
    {
        this.repository = repository;
    }

    // READ
    [HttpGet]
    public TodoItem[] GetAll()
    {
        return repository.GetAll();
    }

    // CREATE
    [HttpPost]
    public void AddItem(TodoItem item)
    {
        repository.AddItem(item);
    }

    // UPDATE
    [HttpPut("{id:int}")]
    public void UpdateItem(int id, TodoItem item)
    {
        item.Id = id;

        repository.UpdateItem(item);
    }

    // DELETE
    [HttpDelete("{id:int}")]
    public void DeleteItem(int id)
    {
        repository.DeleteById(id);
    }
}