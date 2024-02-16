using BankManagement.Application.IServices;
using BankManagement.Infrastructure.Data;
using BankManagement.Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<BankContext>(optionsAction: options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("connectDB")));

builder.Services.AddControllers();
builder.Services.AddScoped<IBank, BankRepository>();
builder.Services.AddScoped<IAccount, AccountRepository>();
builder.Services.AddScoped<ICustomer, CustomerRepository>();
builder.Services.AddScoped<IUPICreation, UPICreationRepository>();
builder.Services.AddScoped<IUPITransaction, UPITransactionRepository>();
builder.Services.AddScoped<ITransaction, TransactionRepository>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
