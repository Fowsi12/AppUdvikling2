using Backend.Repositories;

var builder = WebApplication.CreateBuilder(args);


// Tilføjer Controllers til Backend.
builder.Services.AddControllers();


// Tilføjer Swagger, så vi kan dokumentere og teste vores API.
builder.Services.AddSwaggerGen();


// TodoRepository bruger nu MongoDB.
// Singleton betyder, at Backend genbruger det samme repository-objekt.
builder.Services.AddSingleton<ITodoRepository, TodoRepositoryMongoDB>();


// Product bruger stadig vores InMemory repository.
// Denne ændrer vi senere til MongoDB.
builder.Services.AddSingleton<IProductRepository, ProductRepositoryInMemory>();


// CORS gør det muligt for vores Blazor frontend
// at sende requests til Backend.
builder.Services.AddCors(options =>
{
    options.AddPolicy("policy",
        policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});


// Bygger applikationen.
// Alle builder.Services skal være registreret INDEN denne linje.
var app = builder.Build();


// Swagger bruges kun under development.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Aktiverer vores CORS-policy.
app.UseCors("policy");


// Authorization middleware.
app.UseAuthorization();


// Finder vores Controllers og deres API-routes.
app.MapControllers();


// Starter Backend.
app.Run();