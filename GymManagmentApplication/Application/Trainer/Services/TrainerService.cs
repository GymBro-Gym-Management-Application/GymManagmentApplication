using System.Text.Json;
using GymManagmentApplication.Application.Trainer.Interfaces;
using GymManagmentApplication.Application.Trainer.Requests;
using GymManagmentApplication.Application.Trainer.Responses;
using GymManagmentApplication.Domain.Entities.Training;
using GymManagmentApplication.Infrastructure.Repositories;

namespace GymManagmentApplication.Application.Trainer.Services;

public class TrainerService(ITrainerRepository repository) : ITrainerService
{
    private static readonly JsonSerializerOptions _opts = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

    public async Task<TrainerResponse> CreateAsync(CreateTrainerRequest request)
    {
        var trainer = new TrainerProfile
        {
            UserId = request.UserId,
            TenantId = request.TenantId,
            TrainerCode = request.TrainerCode,
            DisplayName = request.DisplayName,
            ProfileImage = request.ProfileImage,
            Bio = request.Bio,
            ExperienceYears = request.ExperienceYears,
            Gender = request.Gender,
            DateOfBirth = request.DateOfBirth,
            Phone = request.Phone,
            Email = request.Email,
            Address = request.Address,
            Notes = request.Notes,
            LanguagesKnown = ToJson(request.LanguagesKnown),
            Specializations = ToJson(request.Specializations),
            Certifications = ToJson(request.Certifications),
            Employment = ToJson(request.Employment),
            Salary = ToJson(request.Salary),
            Allowances = ToJson(request.Allowances),
            Deductions = ToJson(request.Deductions),
            PaymentDetails = ToJson(request.PaymentDetails),
            Availability = ToJson(request.Availability),
            BookingSettings = ToJson(request.BookingSettings),
            CommissionSettings = ToJson(request.CommissionSettings),
            AttendanceSettings = ToJson(request.AttendanceSettings),
            Documents = ToJson(request.Documents),
            EmergencyContact = ToJson(request.EmergencyContact),
            SocialLinks = ToJson(request.SocialLinks),
        };

        var created = await repository.CreateAsync(trainer);
        return MapToResponse(created);
    }

    public async Task<TrainerResponse?> GetByIdAsync(ulong id)
    {
        var trainer = await repository.GetByIdAsync(id);
        return trainer is null ? null : MapToResponse(trainer);
    }

    private static TrainerResponse MapToResponse(TrainerProfile t) => new()
    {
        Id = t.Id,
        UserId = t.UserId,
        TenantId = t.TenantId,
        TrainerCode = t.TrainerCode,
        DisplayName = t.DisplayName,
        ProfileImage = t.ProfileImage,
        Bio = t.Bio,
        ExperienceYears = t.ExperienceYears,
        Gender = t.Gender,
        DateOfBirth = t.DateOfBirth,
        Phone = t.Phone,
        Email = t.Email,
        Address = t.Address,
        Notes = t.Notes,
        Rating = t.Rating,
        IsAvailable = t.IsAvailable,
        CreatedAt = t.CreatedAt,
        LanguagesKnown = FromJson<List<string>>(t.LanguagesKnown),
        Specializations = FromJson<List<string>>(t.Specializations),
        Certifications = FromJson<object>(t.Certifications),
        Employment = FromJson<object>(t.Employment),
        Salary = FromJson<object>(t.Salary),
        Allowances = FromJson<object>(t.Allowances),
        Deductions = FromJson<object>(t.Deductions),
        PaymentDetails = FromJson<object>(t.PaymentDetails),
        Availability = FromJson<object>(t.Availability),
        BookingSettings = FromJson<object>(t.BookingSettings),
        CommissionSettings = FromJson<object>(t.CommissionSettings),
        AttendanceSettings = FromJson<object>(t.AttendanceSettings),
        Documents = FromJson<object>(t.Documents),
        EmergencyContact = FromJson<object>(t.EmergencyContact),
        SocialLinks = FromJson<object>(t.SocialLinks),
    };

    private static JsonDocument? ToJson<T>(T? value) =>
        value is null ? null : JsonDocument.Parse(JsonSerializer.Serialize(value, _opts));

    private static T? FromJson<T>(JsonDocument? doc) =>
        doc is null ? default : JsonSerializer.Deserialize<T>(doc.RootElement.GetRawText(), _opts);
}
