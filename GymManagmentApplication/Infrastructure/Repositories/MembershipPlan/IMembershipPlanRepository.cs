using GymManagmentApplication.Application.MembershipPlan.Requests;
using GymManagmentApplication.Domain.Entities.Membership;

namespace GymManagmentApplication.Infrastructure.Repositories.MembershipPlan;

public interface IMembershipPlanRepository
{
    Task<(List<Domain.Entities.Membership.MembershipPlan> Items, int Total)> GetAllAsync(MembershipPlanListRequest request);
    Task<Domain.Entities.Membership.MembershipPlan> CreateAsync(Domain.Entities.Membership.MembershipPlan plan);
    Task<Domain.Entities.Membership.MembershipPlan?> GetByIdAsync(ulong id);
    Task<Domain.Entities.Membership.MembershipPlan?> UpdateAsync(Domain.Entities.Membership.MembershipPlan plan);
    Task<bool> SoftDeleteAsync(ulong id);
}
