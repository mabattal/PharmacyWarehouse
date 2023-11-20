using Microsoft.EntityFrameworkCore;
using Pharmacy.Core.Repositories;
using Pharmacy.Core.UnitOfWorks;
using Pharmacy.Repository.Repositories;
using Pharmacy.Repository.UnitOfWorks;
using Pharmacy.Repository;
using System.Reflection;
using Pharmacy.Core.Services;
using Pharmacy.Service.Services;
using Pharmacy.Service.Mapping;
using FluentValidation.AspNetCore;
using Pharmacy.Service.Validations;
using Pharmacy.API.Filters;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add(new ValidatorFilterAttribute())).AddFluentValidation(x =>
{
    x.RegisterValidatorsFromAssemblyContaining<MedicineDtoValidator>();
    x.RegisterValidatorsFromAssemblyContaining<SuplierDtoValidator>();
});

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>),typeof(Service<>));
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddScoped<IMedicineRepository, MedicineRepository>();
builder.Services.AddScoped<IMedicineService, MedicineService>();
builder.Services.AddScoped<ISuplierRepository, SuplierRepository>();
builder.Services.AddScoped<ISuplierService, SuplierService>();

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
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

app.UseCustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();
