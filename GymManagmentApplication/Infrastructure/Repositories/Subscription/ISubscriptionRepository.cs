using GymManagmentApplication.Application.Subscription.Requests;
using GymManagmentApplication.Domain.Entities.Membership;

namespace GymManagmentApplication.Infrastructure.Repositories.Subscription;

public interface ISubscriptionRepository
{
    Task<(List<GymMembership> Items, int Total)> GetAllAsync(SubscriptionListRequest request);
    Task<GymMembership> CreateAsync(GymMembership membership);
    Task<GymMembership?> GetByIdAsync(ulong id);
    Task<GymMembership?> UpdateAsync(GymMembership membership);
}
