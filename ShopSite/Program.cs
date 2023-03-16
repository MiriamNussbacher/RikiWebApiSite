using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IUsersRepository, UsersRepository>();
builder.Services.AddTransient<IUsersService, UsersService>();
builder.Services.AddTransient<IValidPasswordService, ValidPasswordService>();
builder.Services.AddDbContext<ShopDbContext>(option => option.UseSqlServer("Data Source=SRV2\\PUPILS;Integrated Security=True"));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
