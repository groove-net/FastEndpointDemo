using MySite.Models;
using MySite.Services;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFastEndpoints();
builder.Services.Configure<DatabaseSettings>(
	builder.Configuration.GetSection("BookStoreDatabase"));
builder.Services.AddScoped<IBooksService, BooksService>();


var app = builder.Build();

app.UseHttpsRedirection();

// Configure Endpoints
app.UseFastEndpoints();


app.Run();