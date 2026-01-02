Migration Command

dotnet ef migrations add InitialCreate --project SoftOne.TaskManagement.Infrastructure --startup-project SoftOne.TaskManagement.API

dotnet ef database update --project SoftOne.TaskManagement.Infrastructure --startup-project SoftOne.TaskManagement.Api