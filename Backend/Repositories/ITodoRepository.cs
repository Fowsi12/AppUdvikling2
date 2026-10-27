using Core;

namespace Backend.Repositories;

public interface ITodoRepository
{
    TodoItem[] GetAll();

    void AddItem(TodoItem item);

    void UpdateItem(TodoItem item);

    void DeleteById(int id);
}