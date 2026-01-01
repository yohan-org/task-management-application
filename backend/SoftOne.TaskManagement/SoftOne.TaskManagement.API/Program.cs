using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SoftOne.TaskManagement.API.Middleware;
using SoftOne.TaskManagement.Application.Interfaces;
using SoftOne.TaskManagement.Application.Mapping;
using SoftOne.TaskManagement.Application.Services;
using SoftOne.TaskManagement.Domain.Interfaces;
using SoftOne.TaskManagement.Infrastructure.Data;
using SoftOne.TaskManagement.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<TaskService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddAutoMapper(cfg =>
{
    // Add each profile explicitly
    cfg.AddProfile<TaskMappingProfile>();
});


builder.Services.AddControllers();

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

app.UseMiddleware<BasicAuthMiddleware>();

app.Run();
