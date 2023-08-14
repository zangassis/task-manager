using TaskManager.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<TaskService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/tasks", (TaskService service) =>
{
    var tasks = service.FindTasks();

    return Results.Ok(tasks);
})
.WithName("FindTasks")
.WithOpenApi();

static bool ValidateTaskName(string name)
{
    var userValid = true;

    if (name.Length < 3)
        userValid = false;

    return userValid;
}
    
app.MapGet("/tasks/{name}", (TaskService service, string name) =>
    {
        name = name.ToUpper();

        if (!ValidateTaskName(name))
            return Results.BadRequest("The name must have at least 3 characters");
        var task = service.FindTaskByName(name);
        return task is null ? Results.NotFound() : Results.Ok(task);
    })
.WithName("FindTaskByName")
.WithOpenApi();

app.Run();