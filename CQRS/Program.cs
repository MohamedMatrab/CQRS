using CQRS.Data;
using CQRS.Handlers;
using CQRS.Interfaces;
using CQRS.Model;
using CQRS.Queries.CommandModel;
using CQRS.Queries.QueryModel;
using CQRS.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration; // Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => { 
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IRepository<Product>, ProductRepository>(); 
builder.Services.AddTransient<ICommandHandler<CreateProductCommand>, CreateProductCommandHandler>(); 
builder.Services.AddTransient<IQueryHandler<GetProductsQuery, IEnumerable<GetAllProductCommand>>, GetProductsQueryHandler>(); 
builder.Services.AddTransient<ICommandHandler<UpdateProductCommand>, UpdateProductCommandHandler>(); 
builder.Services.AddTransient<ICommandHandler<DeleteProductCommand>, DeleteProductCommandHandler>();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
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