using KnightChall.Domain.DBModels;
using KnightChall.Domain.Interfaces;
using KnightChall.Infra.Context;
using KnightChall.Infra.Repository;
using KnightChall.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IKnightService, KnightService>();
builder.Services.AddScoped<IBaseRepository, KnightDbRepository>();
builder.Services.AddScoped<IKnightDbContext, KnightDbContext>();
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*").
                          AllowAnyHeader().
                          AllowAnyMethod();
                      });
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
