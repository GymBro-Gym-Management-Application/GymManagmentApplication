using System.Text;
using FluentValidation;
using GymManagmentApplication.Application.Auth;
using GymManagmentApplication.Application.Auth.Interfaces;
using GymManagmentApplication.Application.Auth.Services;
using GymManagmentApplication.Application.Auth.Validators;
using GymManagmentApplication.Application.Biometric.Interfaces;
using GymManagmentApplication.Application.Biometric.Services;
using GymManagmentApplication.Application.Biometric.Validators;
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
using GymManagmentApplication.Application.Roles.Interfaces;
using GymManagmentApplication.Application.Roles.Services;
using GymManagmentApplication.Application.Roles.Validators;
using GymManagmentApplication.Application.SSO.Interfaces;
using GymManagmentApplication.Application.SSO.Services;
using GymManagmentApplication.Application.SSO.Validators;
using GymManagmentApplication.Application.Branch.Interfaces;
using GymManagmentApplication.Application.Branch.Services;
using GymManagmentApplication.Application.Branch.Validators;
using GymManagmentApplication.Application.Tenant.Interfaces;
using GymManagmentApplication.Application.Tenant.Services;
using GymManagmentApplication.Application.Tenant.Validators;
using GymManagmentApplication.Application.Trainer.Interfaces;
using GymManagmentApplication.Application.Trainer.Services;
using GymManagmentApplication.Application.Trainer.Validators;
using GymManagmentApplication.Infrastructure.Repositories.Branch;
using GymManagmentApplication.Infrastructure.Repositories.Tenant;
using GymManagmentApplication.Infrastructure;
using GymManagmentApplication.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
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

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Swagger with Bearer auth support
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Gym Management API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "JWT Authorization header. Enter: Bearer {token}",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            []
        }
    });
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrgin",
        policy =>
        {
            policy.WithOrigins("AllowAllOrgin") // frontend URL
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
// Validators
builder.Services.AddValidatorsFromAssemblyContaining<LoginValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateTenantValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateBranchValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateTrainerValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateMemberValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateLeadValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<StartOnboardingValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateCorporateAccountValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<SsoInitValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<EnrollFaceValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateRoleValidator>();

// Application Services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITenantService, TenantService>();
builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<ITrainerService, TrainerService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<ILeadService, LeadService>();
builder.Services.AddScoped<IOnboardingService, OnboardingService>();
builder.Services.AddScoped<ICorporateService, CorporateService>();
builder.Services.AddScoped<ISsoService, SsoService>();
builder.Services.AddScoped<IBiometricService, BiometricService>();
builder.Services.AddScoped<IRolesService, RolesService>();

// Infrastructure Repositories
builder.Services.AddScoped<ITenantRepository, TenantRepository>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
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

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseCors("AllowAllOrgin");
app.UseAuthorization();
app.MapControllers();

app.Run();
