using EmployeeManagementApi.Filters;

var builder = WebApplication.CreateBuilder(args);

// Register Custom Authorization Filter
builder.Services.AddScoped<CustomAuthFilter>();

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomExceptionFilter>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();