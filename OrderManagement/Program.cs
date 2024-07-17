using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Infrastructure.Service;
using System.Data;

var builder = WebApplication.CreateBuilder(args);


//ConnectionString
builder.Services.AddTransient<IDbConnection>(options => new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnectionString")));

// Add services to the container.
builder.Services.AddServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});

var app = builder.Build();

//Seed Data
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var databaseSeeder = serviceProvider.GetRequiredService<DatabaseSeeder>();
    //await databaseSeeder.SeedDatabaseAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

//app.UseCors("AllowAllOrigin");

//app.Use(async (context, next) =>
//{
//    var origin = context.Request.Headers["Origin"].ToString();
//    var allowOrigin = !string.IsNullOrWhiteSpace(origin) ? origin : "'*'";
//    context.Response.Headers.Add("Access-Control-Allow-Origin", allowOrigin);
//    await next();
//});

app.UseAuthorization();

app.MapControllers();

app.Run();
