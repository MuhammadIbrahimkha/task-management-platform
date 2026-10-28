
var builder = WebApplication.CreateBuilder(args);

// Register MVC controllers.
builder.Services.AddControllers();

// OpenAPI document generation.
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// Expose the entry point to integration tests.
public partial class Program;
