using XgHao.Demo.DependencyInjection.Base.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddServicesFromAssembly();

var app = builder.Build();

app.MapControllers();

await app.RunAsync();
