using EmployeePos.Application;
using EmployeePos.Persistence;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using EmployeePos.Application.Position.Validator;
using EmployeePos.Application.Employees.Validators;
using Npgsql;
using System.Data;
using EmployeePos.Application.Position.Command;
using EmployeePos.Persistence.Repositories;
using EmployeePos.Domain.IRepositories;
using EmployeePos.Application.Projects.Commands;
using EmployeePos.Application.Employees.Commands;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PositionDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PositionDbContext")));
builder.Services.AddScoped<IDbConnection>(sp => new NpgsqlConnection(builder.Configuration.GetConnectionString("PositionDbContext")));
builder.Services.AddScoped<IPositionRepository, PositionRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
//builder.Services.AddScoped<IPositionService, PositionService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AddPositionCommand).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AddProjectCommand).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AddEmployeeCommand).Assembly));
builder.Services.AddValidatorsFromAssemblyContaining<AddPositionValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<AddEmployeeValidator>();

var app = builder.Build();

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
