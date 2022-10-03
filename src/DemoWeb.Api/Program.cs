// services
using DemoWeb.Api.Dbcontexts;
using DemoWeb.Api.Interfaces.Repositories;
using DemoWeb.Api.Interfaces.Services;
using DemoWeb.Api.Middlewares;
using DemoWeb.Api.Repositories;
using DemoWeb.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// database
var connectionString = builder.Configuration.GetConnectionString("Demo");
builder.Services.AddDbContext<AppDbContext>(dbOptions => {
    dbOptions.UseNpgsql(connectionString);
    dbOptions.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

//-> Respositories
builder.Services.AddScoped<IUserRepository, UserRepository>();

//-> Services
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IUserService, UserService>();


// middlewares
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware(ExceptionHandlerMiddleware);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
