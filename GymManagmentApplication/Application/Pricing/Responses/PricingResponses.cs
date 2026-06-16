namespace GymManagmentApplication.Application.Pricing.Responses;

public class PricingRuleResponse
{
    public ulong Id { get; set; }
    public ulong TenantId { get; set; }
    public string Name { get; set; } = default!;
    public string AppliesTo { get; set; } = default!;
    public string RuleType { get; set; } = default!;
    public decimal PriceModifier { get; set; }
    public string ModifierType { get; set; } = default!;
    public byte Priority { get; set; }
    public bool IsActive { get; set; }
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidUntil { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class CalculatedPriceResponse
{
    public decimal BasePrice { get; set; }
    public decimal FinalPrice { get; set; }
    public decimal Discount { get; set; }
    public string? AppliedRule { get; set; }
}

public class DiscountResponse
{
    public ulong Id { get; set; }
    public string Code { get; set; } = default!;
    public string Type { get; set; } = default!;
    public decimal Value { get; set; }
    public uint? MaxUses { get; set; }
    public uint UsesCount { get; set; }
    public bool IsActive { get; set; }
    public DateTime? ValidUntil { get; set; }
}

public class DiscountValidationResponse
{
    public bool IsValid { get; set; }
    public string? Message { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal FinalAmount { get; set; }
}
