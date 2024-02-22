using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using WebAPI_Fluent_Validation.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Usuario>());

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

app.MapPost("/Usuarios", (Usuario usuario, IValidator<Usuario> validator, HttpContext httpContext) =>
{
    ValidationResult validationResult = validator.Validate(usuario);

    if (!validationResult.IsValid)
        return Results.BadRequest(validationResult.Errors.Select(errors => errors.ErrorMessage));

    return Results.Ok(usuario);

}).WithName("PostUsuario")
.WithOpenApi();

app.Run();