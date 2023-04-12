using API60New.Context;
using API60New.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<MyContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("API60New")));
builder.Services.AddScoped<EmployeeRepository>();
builder.Services.AddScoped<AccountRepository>();
builder.Services.AddScoped<DepartmentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
