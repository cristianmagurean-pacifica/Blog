using Blog.Domain.Exceptions;
using Blog.Infrastructure.Data;
using Blog.Application;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
var dbConnectionString = builder.Configuration.GetConnectionString("BlogDb") ?? throw new InvalidConfigurationException("DbConnectionString");
builder.Services.RegisterInfrastructureData(dbConnectionString);
builder.Services.RegisterApplication();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(config =>
{
    config.AddMaps(AppDomain.CurrentDomain.GetAssemblies().Where(x => !x.FullName.Contains("Microsoft.Data.SqlClient")));
    config.AllowNullCollections = true;
    config.CreateMap<string, string>().ConvertUsing(str => (str ?? "").Trim());
});

var app = builder.Build();

// Apply migrations at startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<BlogDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog API V1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
