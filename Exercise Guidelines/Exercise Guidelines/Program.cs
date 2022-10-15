using ExerciseGuidelines.Data;
using ExerciseGuidelines.Services;
using ExerciseGuidelines.Services.Interfaces;
using ExerciseGuidelines.Services.Services;
using ExerciseGuidelines.Services.Validations;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//configuramos la conexion a sql server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Conexionsql"),
x => x.MigrationsAssembly("ExerciseGuidelines.Data"))
    );

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssemblyContaining<ProductValidation>();
//.AddJsonOptions(x =>
//x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Add Dependency Injection services
builder.Services.AddScoped<IProductTypeService, ProductTypeService>();
builder.Services.AddScoped<IProductService, ProductService>();


var app = builder.Build();

using (var scope = app.Services.CreateScope()) 
{
    var db = scope.ServiceProvider.GetService<ApplicationDbContext>();
    try
    {
        db?.Database.Migrate();
    }
    catch (Exception)
    {
        throw;
    }
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
