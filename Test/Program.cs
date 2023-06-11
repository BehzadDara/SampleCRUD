using Microsoft.EntityFrameworkCore;
using Test;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<TestDBContext>(options =>
    options.UseSqlServer("Data Source = (localdb)\\mssqllocaldb; Initial Catalog = TestDB"));

builder.Services.AddScoped<UnitOfWork>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddPolicy("allowall", policy =>
    {
        policy
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("allowall");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
