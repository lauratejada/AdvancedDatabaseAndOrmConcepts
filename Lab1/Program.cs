using Lab1.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("ContextConnection");

builder.Services.AddDbContext<EFCodeFirstContext>(options =>
{
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

app.Run();
