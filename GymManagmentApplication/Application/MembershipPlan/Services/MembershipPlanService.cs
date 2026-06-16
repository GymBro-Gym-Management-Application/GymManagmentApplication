using System.Text.Json;
using GymManagmentApplication.Application.Common;
using GymManagmentApplication.Application.MembershipPlan.Interfaces;
using GymManagmentApplication.Application.MembershipPlan.Requests;
using GymManagmentApplication.Application.MembershipPlan.Responses;
using GymManagmentApplication.Infrastructure.Repositories.MembershipPlan;

namespace GymManagmentApplication.Application.MembershipPlan.Services;

public class MembershipPlanService(IMembershipPlanRepository repository) : IMembershipPlanService
{
    public async Task<PagedResponse<MembershipPlanResponse>> GetAllAsync(MembershipPlanListRequest request)
    {
        var (items, total) = await repository.GetAllAsync(request);
        return new PagedResponse<MembershipPlanResponse>
        {
            Items = items.Select(Map),
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalRecords = total
        };
    }

    public async Task<MembershipPlanResponse> CreateAsync(CreateMembershipPlanRequest request)
    {
        var features = request.Features is not null
            ? JsonDocument.Parse(JsonSerializer.Serialize(request.Features))
            : null;
        var plan = new Domain.Entities.Membership.MembershipPlan
        {
            TenantId = request.TenantId,
            BranchId = request.BranchId,
            Name = request.Name,
            Description = request.Description,
            BillingCycle = request.BillingCycle,
            Price = request.Price,
            Currency = request.Currency,
            TrialDays = request.TrialDays,
            MaxMembers = request.MaxMembers,
            Features = features,
            IsActive = true
        };
        return Map(await repository.CreateAsync(plan));
    }

    public async Task<MembershipPlanResponse?> GetByIdAsync(ulong id)
    {
        var p = await repository.GetByIdAsync(id);
        return p is null ? null : Map(p);
    }

    public async Task<MembershipPlanResponse?> UpdateAsync(ulong id, UpdateMembershipPlanRequest request)
    {
        var p = await repository.GetByIdAsync(id);
        if (p is null) return null;
        if (request.Name is not null) p.Name = request.Name;
        if (request.Description is not null) p.Description = request.Description;
        if (request.Price.HasValue) p.Price = request.Price.Value;
        if (request.TrialDays.HasValue) p.TrialDays = request.TrialDays.Value;
        if (request.MaxMembers.HasValue) p.MaxMembers = request.MaxMembers.Value;
        if (request.IsActive.HasValue) p.IsActive = request.IsActive.Value;
        await repository.UpdateAsync(p);
        return Map(p);
    }

    public Task<bool> DeleteAsync(ulong id) => repository.SoftDeleteAsync(id);

    public async Task<List<string>> GetFeaturesAsync(ulong id)
    {
        var p = await repository.GetByIdAsync(id);
        return ExtractFeatures(p?.Features);
    }

    public async Task<MembershipPlanResponse?> UpdateFeaturesAsync(ulong id, UpdatePlanFeaturesRequest request)
    {
        var p = await repository.GetByIdAsync(id);
        if (p is null) return null;
        p.Features = JsonDocument.Parse(JsonSerializer.Serialize(request.Features));
        await repository.UpdateAsync(p);
        return Map(p);
    }

    private static MembershipPlanResponse Map(Domain.Entities.Membership.MembershipPlan p) => new()
    {
        Id = p.Id, TenantId = p.TenantId, BranchId = p.BranchId, Name = p.Name,
        Description = p.Description, BillingCycle = p.BillingCycle.ToString(),
        Price = p.Price, Currency = p.Currency, TrialDays = p.TrialDays,
        MaxMembers = p.MaxMembers, IsActive = p.IsActive,
        Features = ExtractFeatures(p.Features), CreatedAt = p.CreatedAt
    };

    private static List<string> ExtractFeatures(JsonDocument? doc) =>
        doc?.RootElement.EnumerateArray().Select(e => e.GetString() ?? "").ToList() ?? [];
}
