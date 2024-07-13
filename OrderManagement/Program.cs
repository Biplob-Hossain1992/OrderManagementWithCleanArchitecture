using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.Interfaces.IRepositories;
using OrderManagement.Infrastructure.Repositories;
using OrderManagement.Infrastructure.Service;
using System.Data;

var builder = WebApplication.CreateBuilder(args);


//ConnectionString
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
//});
builder.Services.AddTransient<IDbConnection>(options => new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnectionString")));

// Add services to the container.
builder.Services.AddServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Order}/{action=index}/{id?}");

app.Run();
