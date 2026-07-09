
using Application.Behaviors;
using FluentValidation;
using Infrastructure.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data source = app.db"));

builder.Services.AddMediatR(options =>
    options.RegisterServicesFromAssembly(typeof(Application.IAssemblyMarker).Assembly));

builder.Services.AddValidatorsFromAssembly(typeof(Application.IAssemblyMarker).Assembly);

builder.Services.AddTransient(typeof(IPipelineBehavior<,>) , typeof(ValidationsBehaviors<,>)) ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
