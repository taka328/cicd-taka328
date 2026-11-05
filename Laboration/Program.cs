using Laboration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<TaskService>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/api/tasks", (TaskService service) =>
{
    return Results.Ok(service.GetAll());
});

app.MapGet("/api/tasks/{id:int}", (int id, TaskService service) =>
{
    var task = service.GetById(id);

    return task is null
        ? Results.NotFound()
        : Results.Ok(task);
});

app.MapPost("/api/tasks", (CreateTaskRequest request, TaskService service) =>
{
    var task = service.Create(request.Title);

    return Results.Created($"/api/tasks/{task.Id}", task);
});

app.MapPost("/api/tasks/{id:int}/complete", (int id, TaskService service) =>
{
    if (!service.Complete(id))
    {
        return Results.NotFound();
    }

    var task = service.GetById(id);
    return Results.Ok(task);
});

app.Run();


