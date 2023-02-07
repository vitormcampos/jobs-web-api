using Jobs.Core.Data.Config;
using Jobs.Core.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<JobsContext>(opt =>
{
    var connectionString = builder.Configuration.GetConnectionString("jobs");
    opt.UseSqlite(connectionString);
});
builder.Services.RegisterRepositories();
builder.Services.RegisterServices();
builder.Services.RegisterMappers();
builder.Services.RegisterValidators();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.RegisterMiddlewares();

app.Run();