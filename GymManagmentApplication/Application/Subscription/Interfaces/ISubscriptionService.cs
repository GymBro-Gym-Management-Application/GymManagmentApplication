using GymManagmentApplication.Application.Common;
using GymManagmentApplication.Application.Subscription.Requests;
using GymManagmentApplication.Application.Subscription.Responses;

namespace GymManagmentApplication.Application.Subscription.Interfaces;

public interface ISubscriptionService
{
    Task<PagedResponse<SubscriptionResponse>> GetAllAsync(SubscriptionListRequest request);
    Task<SubscriptionResponse> CreateAsync(CreateSubscriptionRequest request);
    Task<SubscriptionResponse?> GetByIdAsync(ulong id);
    Task<SubscriptionResponse?> RenewAsync(ulong id, RenewSubscriptionRequest request);
    Task<SubscriptionResponse?> UpgradeAsync(ulong id, UpgradeSubscriptionRequest request);
    Task<SubscriptionResponse?> DowngradeAsync(ulong id, DowngradeSubscriptionRequest request);
    Task<SubscriptionResponse?> FreezeAsync(ulong id, FreezeSubscriptionRequest request);
    Task<SubscriptionResponse?> UnfreezeAsync(ulong id);
    Task<bool> CancelAsync(ulong id);
    Task<SubscriptionUsageResponse?> GetUsageAsync(ulong id);
}
