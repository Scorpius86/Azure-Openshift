using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Taller.FullStack.Service.Infrastructure.Contexts;
using Taller.FullStack.Service.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BikestoresContext>(opt => { opt.UseInMemoryDatabase("BikeStores"); });
builder.Services.AddScoped<UnitOfWork>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("ALLOW_ANY", policies=>{
        policies
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("ALLOW_ANY");

app.UseAuthorization();

app.MapControllers();

SeeData(app);

app.Run();

void SeeData(IHost app)
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<BikestoresContext>();
        context.SeeData();
    }
}