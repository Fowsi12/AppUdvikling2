using Core;

namespace Backend.Repositories;

public class TodoRepositoryInMemory : ITodoRepository
{
    private readonly List<TodoItem> todoItems = new();

    private int nextId = 1;

    public TodoItem[] GetAll()
    {
        return todoItems.ToArray();
    }

    public void AddItem(TodoItem item)
    {
        item.Id = nextId;

        nextId++;

        todoItems.Add(item);
    }

    public void UpdateItem(TodoItem item)
    {
        TodoItem? existingItem =
            todoItems.FirstOrDefault(
                todo => todo.Id == item.Id
            );

        if (existingItem != null)
        {
            existingItem.Title = item.Title;
            existingItem.IsDone = item.IsDone;
        }
    }

    public void DeleteById(int id)
    {
        TodoItem? item =
            todoItems.FirstOrDefault(
                todo => todo.Id == id
            );

        if (item != null)
        {
            todoItems.Remove(item);
        }
    }
}