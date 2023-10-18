using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using pizza_byte.api.Persistence;
using pizza_byte.api.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
            options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        });
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddScoped<IPizzaService, PizzaService>();
    builder.Services.AddScoped<ICustomerService, CustomerService>();
    builder.Services.AddDbContext<PizzaDbContext>(optionsBuilder =>
        optionsBuilder.UseSqlite("Data Source=pizza.db"));
}

// Add services to the container.

var app = builder.Build();
{
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
}


