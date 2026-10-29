using Backend.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<ITodoRepository, TodoRepositoryMongoDB>();
// Singleton betyder, at Backend opretter ét TodoRepositoryInMemory-objekt og bruger det samme objekt hele tiden.

builder.Services.AddSingleton<IProductRepository, ProductRepositoryInMemory>();

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("policy");

app.UseAuthorization();

app.MapControllers();

app.Run();