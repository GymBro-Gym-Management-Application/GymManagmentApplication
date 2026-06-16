using GymManagmentApplication.Domain.Enums;

namespace GymManagmentApplication.Application.Pricing.Requests;

public class CreatePricingRuleRequest
{
    public ulong TenantId { get; set; }
    public string Name { get; set; } = default!;
    public PricingAppliesTo AppliesTo { get; set; }
    public ulong? EntityId { get; set; }
    public PricingRuleType RuleType { get; set; }
    public decimal PriceModifier { get; set; }
    public PriceModifierType ModifierType { get; set; }
    public byte Priority { get; set; }
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidUntil { get; set; }
}

public class UpdatePricingRuleRequest
{
    public string? Name { get; set; }
    public decimal? PriceModifier { get; set; }
    public bool? IsActive { get; set; }
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidUntil { get; set; }
}

public class CalculatePriceRequest
{
    public ulong TenantId { get; set; }
    public PricingAppliesTo AppliesTo { get; set; }
    public ulong EntityId { get; set; }
    public decimal BasePrice { get; set; }
}

public class CreateDiscountRequest
{
    public ulong TenantId { get; set; }
    public string Code { get; set; } = default!;
    public string? Description { get; set; }
    public CouponType Type { get; set; }
    public decimal Value { get; set; }
    public uint? MaxUses { get; set; }
    public DateTime? ValidUntil { get; set; }
}

public class ValidateDiscountRequest
{
    public string Code { get; set; } = default!;
    public ulong TenantId { get; set; }
    public decimal OrderAmount { get; set; }
}

public class PricingRuleListRequest
{
    public ulong? TenantId { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}
