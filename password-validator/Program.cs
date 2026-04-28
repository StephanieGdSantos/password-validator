using password_validator.Configurations;
using password_validator.Domain.Validators;
using password_validator.Domain.Validators.Interface;
using password_validator.Domain.Specifications;
using password_validator.Domain.Specifications.Interface;
using password_validator.Application.Adapters;
using password_validator.Application.Adapters.Interface;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPasswordValidationStrategy, ContainsDigitValidator>();
builder.Services.AddScoped<IPasswordValidationStrategy, ContainsLowercaseValidator>();
builder.Services.AddScoped<IPasswordValidationStrategy, ContainsUppercaseValidator>();
builder.Services.AddScoped<IPasswordValidationStrategy, ContainsSpecialCharacterValidator>();
builder.Services.AddScoped<IPasswordValidationStrategy, NoWhiteSpaceValidator>();
builder.Services.AddScoped<IPasswordValidationStrategy, NoRepetitionValidator>();
builder.Services.AddScoped<IPasswordValidationStrategy, MinimumCharactersValidator>();
builder.Services.AddScoped<IPasswordSpecification, PasswordSpecification>();
builder.Services.AddScoped<IValidateResponseAdapter, ValidateResponseAdapter>();

builder.Services.AddOptions<LengthPasswordOptions>()
    .Bind(builder.Configuration
        .GetSection("LengthPasswordValidators"))
    .ValidateDataAnnotations()
    .ValidateOnStart();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program() { }