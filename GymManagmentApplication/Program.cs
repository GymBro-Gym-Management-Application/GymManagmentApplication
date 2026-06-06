using System.Text;
using FluentValidation;
using GymManagmentApplication.Application.Auth;
using GymManagmentApplication.Application.Auth.Interfaces;
using GymManagmentApplication.Application.Auth.Services;
using GymManagmentApplication.Application.Auth.Validators;
using GymManagmentApplication.Application.Corporate.Interfaces;
using GymManagmentApplication.Application.Corporate.Services;
using GymManagmentApplication.Application.Corporate.Validators;
using GymManagmentApplication.Application.Lead.Interfaces;
using GymManagmentApplication.Application.Lead.Services;
using GymManagmentApplication.Application.Lead.Validators;
using GymManagmentApplication.Application.Member.Interfaces;
using GymManagmentApplication.Application.Member.Services;
using GymManagmentApplication.Application.Member.Validators;
using GymManagmentApplication.Application.Onboarding.Interfaces;
using GymManagmentApplication.Application.Onboarding.Services;
using GymManagmentApplication.Application.Onboarding.Validators;
using GymManagmentApplication.Application.Trainer.Interfaces;
using GymManagmentApplication.Application.Trainer.Services;
using GymManagmentApplication.Application.Trainer.Validators;
using GymManagmentApplication.Infrastructure.Repositories;
using GymManagmentApplication.Infrastructure.Repositories.Corporate;
using GymManagmentApplication.Infrastructure.Repositories.Lead;
using GymManagmentApplication.Infrastructure.Repositories.Member;
using GymManagmentApplication.Infrastructure.Repositories.Onboarding;
using GymManagmentApplication.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// JWT Settings
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>()!;

// Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
            ValidateIssuer = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidateAudience = true,
            ValidAudience = jwtSettings.Audience,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Swagger with Bearer auth support
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo { Title = "Gym Management API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.OpenApiSecurityScheme
    {
        Description = "JWT Authorization header. Enter: Bearer {token}",
        Name = "Authorization",
        In = Microsoft.OpenApi.ParameterLocation.Header,
        Type = Microsoft.OpenApi.SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(_ => new Microsoft.OpenApi.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.OpenApiSecuritySchemeReference("Bearer"),
            []
        }
    });
});

// Validators
builder.Services.AddValidatorsFromAssemblyContaining<LoginValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateTrainerValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateMemberValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateLeadValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<StartOnboardingValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateCorporateAccountValidator>();

// Application Services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITrainerService, TrainerService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<ILeadService, LeadService>();
builder.Services.AddScoped<IOnboardingService, OnboardingService>();
builder.Services.AddScoped<ICorporateService, CorporateService>();

// Infrastructure Repositories
builder.Services.AddScoped<ITrainerRepository, TrainerRepository>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<ILeadRepository, LeadRepository>();
builder.Services.AddScoped<IOnboardingRepository, OnboardingRepository>();
builder.Services.AddScoped<ICorporateRepository, CorporateRepository>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<JwtMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
