using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt =>
{
    // pass connection string
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// add service support for cors 
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
// specify polices for middleware to provide
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod()
    .WithOrigins("http://localhost:4200", "https://localhost:4200"));

app.MapControllers();

app.Run();