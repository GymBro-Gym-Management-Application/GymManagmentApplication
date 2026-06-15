using System.Text;
using FluentValidation;
using GymManagmentApplication.Application.Auth;
using GymManagmentApplication.Application.Exercise.Interfaces;
using GymManagmentApplication.Application.Exercise.Services;
using GymManagmentApplication.Application.Exercise.Validators;
using GymManagmentApplication.Application.Workout.Interfaces;
using GymManagmentApplication.Application.Workout.Services;
using GymManagmentApplication.Application.Workout.Validators;
using GymManagmentApplication.Application.WorkoutPlan.Interfaces;
using GymManagmentApplication.Application.WorkoutPlan.Services;
using GymManagmentApplication.Application.WorkoutPlan.Validators;
using GymManagmentApplication.Application.WorkoutBuilder.Interfaces;
using GymManagmentApplication.Application.WorkoutBuilder.Services;
using GymManagmentApplication.Application.WorkoutAutomation.Interfaces;
using GymManagmentApplication.Application.WorkoutAutomation.Services;
using GymManagmentApplication.Application.WorkoutAutomation.Validators;
using GymManagmentApplication.Infrastructure.Repositories.Exercise;
using GymManagmentApplication.Infrastructure.Repositories.Workout;
using GymManagmentApplication.Infrastructure.Repositories.WorkoutPlan;
using GymManagmentApplication.Infrastructure.Repositories.WorkoutAutomation;
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
using GymManagmentApplication.Application.Trainer.Interfaces;
using GymManagmentApplication.Application.Trainer.Services;
using GymManagmentApplication.Application.Trainer.Validators;
using GymManagmentApplication.Infrastructure.Repositories;
using GymManagmentApplication.Infrastructure.Repositories.Corporate;
using GymManagmentApplication.Infrastructure.Repositories.Lead;
using GymManagmentApplication.Infrastructure.Repositories.Member;
using GymManagmentApplication.Infrastructure.Repositories.Onboarding;
using GymManagmentApplication.Infrastructure.Data;
using GymManagmentApplication.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
builder.Services.AddValidatorsFromAssemblyContaining<SsoInitValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<EnrollFaceValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateRoleValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateExerciseValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateWorkoutValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreatePlanValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateAutomationRuleValidator>();

// Application Services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITrainerService, TrainerService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<ILeadService, LeadService>();
builder.Services.AddScoped<IOnboardingService, OnboardingService>();
builder.Services.AddScoped<ICorporateService, CorporateService>();
builder.Services.AddScoped<ISsoService, SsoService>();
builder.Services.AddScoped<IBiometricService, BiometricService>();
builder.Services.AddScoped<IRolesService, RolesService>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IWorkoutService, WorkoutService>();
builder.Services.AddScoped<IWorkoutPlanService, WorkoutPlanService>();
builder.Services.AddScoped<IWorkoutBuilderService, WorkoutBuilderService>();
builder.Services.AddScoped<IWorkoutAutomationService, WorkoutAutomationService>();

// Infrastructure Repositories
builder.Services.AddScoped<ITrainerRepository, TrainerRepository>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<ILeadRepository, LeadRepository>();
builder.Services.AddScoped<IOnboardingRepository, OnboardingRepository>();
builder.Services.AddScoped<ICorporateRepository, CorporateRepository>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IWorkoutRepository, WorkoutRepository>();
builder.Services.AddScoped<IWorkoutPlanRepository, WorkoutPlanRepository>();
builder.Services.AddScoped<IWorkoutAutomationRepository, WorkoutAutomationRepository>();

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
