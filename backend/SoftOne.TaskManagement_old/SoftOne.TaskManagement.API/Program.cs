using Microsoft.EntityFrameworkCore;
using SoftOne.TaskManagement.API.Middleware;
using SoftOne.TaskManagement.Application.Interfaces;
using SoftOne.TaskManagement.Application.Mapping;
using SoftOne.TaskManagement.Application.Services;
using SoftOne.TaskManagement.Domain.Interfaces;
using SoftOne.TaskManagement.Infrastructure.Data;
using SoftOne.TaskManagement.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,            // retry up to 5 times
                maxRetryDelay: TimeSpan.FromSeconds(10), // wait up to 10 seconds between retries
                errorNumbersToAdd: null      // null = use default transient error codes
            );
        }
    )
);

builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<TaskService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddAutoMapper(cfg =>
{
    // Add each profile explicitly
    cfg.AddProfile<TaskMappingProfile>();
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task Management API v1");
        c.RoutePrefix = "swagger"; // http://localhost:5241/swagger
    });
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<BasicAuthMiddleware>();

app.Run();
