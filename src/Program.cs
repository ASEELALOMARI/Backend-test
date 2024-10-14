using backendTest.src.Database;
using backendTest.src.Mapper;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using test.src.Abstraction;
using test.src.MVC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add controllers
builder.Services.AddControllers();

// add database service
var dataSourceBuilder = new NpgsqlDataSourceBuilder(builder.Configuration.GetConnectionString("Local"));

var dataSource = dataSourceBuilder.Build();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options
    .UseNpgsql(dataSource);
}
);

builder.Services.AddScoped<IReviewServices, ReviewServices>();

builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

// Add a simple endpoint that returns "Hello"
app.MapGet("/", () => "Hello");

// Run the application
app.Run();

