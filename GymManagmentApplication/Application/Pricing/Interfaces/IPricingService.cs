using GymManagmentApplication.Application.Common;
using GymManagmentApplication.Application.Pricing.Requests;
using GymManagmentApplication.Application.Pricing.Responses;

namespace GymManagmentApplication.Application.Pricing.Interfaces;

public interface IPricingService
{
    Task<PagedResponse<PricingRuleResponse>> GetRulesAsync(PricingRuleListRequest request);
    Task<PricingRuleResponse> CreateRuleAsync(CreatePricingRuleRequest request);
    Task<PricingRuleResponse?> UpdateRuleAsync(ulong id, UpdatePricingRuleRequest request);
    Task<bool> DeleteRuleAsync(ulong id);
    Task<CalculatedPriceResponse> CalculateAsync(CalculatePriceRequest request);
    Task<List<DiscountResponse>> GetDiscountsAsync(ulong tenantId);
    Task<DiscountResponse> CreateDiscountAsync(CreateDiscountRequest request);
    Task<DiscountValidationResponse> ValidateDiscountAsync(ValidateDiscountRequest request);
}
