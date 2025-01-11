using Forward_Solutions_Test_BE.Application.Services;
using Forward_Solutions_Test_BE.Domain.Interfaces;
using Forward_Solutions_Test_BE.Infra.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICalculationRepository, CalculationRepository>();
builder.Services.AddScoped<CalculationService>();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Map("/", context =>
{
    context.Response.Redirect("/swagger/index.html");
    return Task.CompletedTask;
});

app.UseHttpsRedirection();
app.MapControllers();

app.Run();