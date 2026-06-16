using GymManagmentApplication.Application.Common;
using GymManagmentApplication.Application.MembershipPlan.Requests;
using GymManagmentApplication.Application.MembershipPlan.Responses;

namespace GymManagmentApplication.Application.MembershipPlan.Interfaces;

public interface IMembershipPlanService
{
    Task<PagedResponse<MembershipPlanResponse>> GetAllAsync(MembershipPlanListRequest request);
    Task<MembershipPlanResponse> CreateAsync(CreateMembershipPlanRequest request);
    Task<MembershipPlanResponse?> GetByIdAsync(ulong id);
    Task<MembershipPlanResponse?> UpdateAsync(ulong id, UpdateMembershipPlanRequest request);
    Task<bool> DeleteAsync(ulong id);
    Task<List<string>> GetFeaturesAsync(ulong id);
    Task<MembershipPlanResponse?> UpdateFeaturesAsync(ulong id, UpdatePlanFeaturesRequest request);
}
