using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PaymentPortal.Data;
using PaymentPortal.Data.Interfaces;
using PaymentPortal.Data.Repositories;
using PaymentPortal.Domain.Interfaces;
using PaymentPortal.Domain.Processors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContextFactory<PaymentsDbContext>(options => options.UseSqlServer("name=ConnectionStrings:PaymentsDb"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Define the security scheme
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
});

builder.Services.AddAuthentication().AddBearerToken();

// dependency injection
builder.Services.AddScoped<ICustomerProcessor, CustomerProcessor>();
builder.Services.AddScoped<IPaymentProcessor, PaymentProcessor>();

builder.Services.AddScoped<IAccountBalanceRepository, AccountBalanceRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
