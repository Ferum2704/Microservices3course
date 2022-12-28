using IncomeService.DataAccess.DI;
using IncomeService.Persistence;
using IncomeService.Persistence.DI;
using IncomeService.Services.DI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<IncomeDbContext>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("", policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
    });
});
builder.Services
    .AddPersistence()
    .AddDataAccess()
    .AddServices();

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
app.Migrate();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
