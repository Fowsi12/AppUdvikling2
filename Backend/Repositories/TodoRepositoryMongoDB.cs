using Core;
using MongoDB.Driver;

namespace Backend.Repositories;

public class TodoRepositoryMongoDB : ITodoRepository
{
    // Reference til vores TodoItems collection i MongoDB.
    // Det er gennem denne vi læser, opretter, opdaterer og sletter data.
    private readonly IMongoCollection<TodoItem> todoCollection;

    // Constructoren bliver kaldt af dependency injection.
    // IConfiguration bruges til at hente MongoDB-indstillinger
    // fra appsettings.json.
    public TodoRepositoryMongoDB(IConfiguration configuration)
    {
        // Henter connection string til MongoDB.
        string connectionString =
            configuration["MongoDb:ConnectionString"]!;

        // Henter navnet på databasen.
        string databaseName =
            configuration["MongoDb:DatabaseName"]!;

        // Henter navnet på collectionen.
        string collectionName =
            configuration["MongoDb:TodoCollectionName"]!;

        // Opretter forbindelse til MongoDB-serveren.
        MongoClient client =
            new MongoClient(connectionString);

        // Finder databasen.
        IMongoDatabase database =
            client.GetDatabase(databaseName);

        // Finder TodoItems collectionen.
        todoCollection =
            database.GetCollection<TodoItem>(collectionName);
    }


    // Henter alle TodoItems fra MongoDB.
    public TodoItem[] GetAll()
    {
        return todoCollection
            .Find(_ => true)
            .ToList()
            .ToArray();
    }


    // Tilføjer et nyt TodoItem til MongoDB.
    public void AddItem(TodoItem item)
    {
        // Finder det TodoItem som har det højeste Id.
        TodoItem? lastItem =
            todoCollection
                .Find(_ => true)
                .SortByDescending(todo => todo.Id)
                .FirstOrDefault();

        // Hvis databasen er tom, starter vi med Id 1.
        if (lastItem == null)
        {
            item.Id = 1;
        }
        else
        {
            // Ellers bliver næste Id ét højere end det seneste.
            item.Id = lastItem.Id + 1;
        }

        // Gemmer det nye TodoItem i MongoDB.
        todoCollection.InsertOne(item);
    }


    // Opdaterer et eksisterende TodoItem.
    public void UpdateItem(TodoItem item)
    {
        // Finder TodoItem ud fra Id og erstatter det
        // med den opdaterede version.
        todoCollection.ReplaceOne(
            todo => todo.Id == item.Id,
            item
        );
    }


    // Sletter et TodoItem ud fra dets Id.
    public void DeleteById(int id)
    {
        todoCollection.DeleteOne(
            todo => todo.Id == id
        );
    }
}