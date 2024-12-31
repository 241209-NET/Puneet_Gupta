using Microsoft.EntityFrameworkCore;
using Project_1.api.Data; // Namespace for your DbContext
using Project_1.api.Repository;
using Project_1.api.Repository.Interface;
using Project_1.api.Services;
using Project_1.api.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext for SQL Server with the connection string
builder.Services.AddDbContext<SampleContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PROJ1")));

// Dependency Injection for Repositories and Services
builder.Services.AddScoped<IBlogPostRepository, BlogPostRepository>();
builder.Services.AddScoped<IBlogPostService, BlogPostService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();