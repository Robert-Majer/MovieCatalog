using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCatalog.ApplicationServices.API.Domain;
using MovieCatalog.ApplicationServices.API.Validators;
using MovieCatalog.ApplicationServices.Mappings;
using MovieCatalog.DataAccess;
using MovieCatalog.DataAccess.CQRS;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvcCore()
       .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddMovieRequestValidator>());

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddTransient<IQueryExecutor, QueryExecutor>();

builder.Services.AddTransient<ICommandExecutor, CommandExecutor>();

builder.Services.AddAutoMapper(typeof(MoviesProfile).Assembly);

builder.Services.AddMediatR(typeof(ResponseBase<>));

builder.Services.AddControllers();

builder.Services.AddDbContext<MovieCatalogStorageContext>(opt => opt.UseInMemoryDatabase("MovieCatalogDb"));

builder.Services.AddControllers();
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
