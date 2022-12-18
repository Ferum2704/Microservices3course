using SpendingApp.Persistence.DI;
using SpendingApp.Persistence.Migrations.Helpers;
using SpendingApp.Repositories.DI;
using SpendingApp.Services.DI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services
    .AddPersistence()
    .AddRepositories()
    .AddServices();

builder.Services.AddCors(options =>
{
    options.AddPolicy("", policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.ApplyMigrations();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();