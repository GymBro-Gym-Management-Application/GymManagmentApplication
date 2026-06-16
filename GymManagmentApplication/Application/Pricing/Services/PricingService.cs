using System.Text.Json;
using GymManagmentApplication.Application.Common;
using GymManagmentApplication.Application.Pricing.Interfaces;
using GymManagmentApplication.Application.Pricing.Requests;
using GymManagmentApplication.Application.Pricing.Responses;
using GymManagmentApplication.Domain.Entities.Billing;
using GymManagmentApplication.Domain.Entities.Platform;
using GymManagmentApplication.Domain.Enums;
using GymManagmentApplication.Infrastructure.Repositories.Pricing;

namespace GymManagmentApplication.Application.Pricing.Services;

public class PricingService(IPricingRepository repository) : IPricingService
{
    private static readonly List<Coupon> _coupons = [];
    private static ulong _couponId = 1;

    public async Task<PagedResponse<PricingRuleResponse>> GetRulesAsync(PricingRuleListRequest request)
    {
        var (items, total) = await repository.GetRulesAsync(request);
        return new PagedResponse<PricingRuleResponse>
        {
            Items = items.Select(MapRule),
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalRecords = total
        };
    }

    public async Task<PricingRuleResponse> CreateRuleAsync(CreatePricingRuleRequest request)
    {
        var rule = new PricingRule
        {
            TenantId = request.TenantId,
            Name = request.Name,
            AppliesTo = request.AppliesTo,
            EntityId = request.EntityId,
            RuleType = request.RuleType,
            Conditions = JsonDocument.Parse("{}"),
            PriceModifier = request.PriceModifier,
            ModifierType = request.ModifierType,
            Priority = request.Priority,
            IsActive = true,
            ValidFrom = request.ValidFrom,
            ValidUntil = request.ValidUntil
        };
        return MapRule(await repository.CreateRuleAsync(rule));
    }

    public async Task<PricingRuleResponse?> UpdateRuleAsync(ulong id, UpdatePricingRuleRequest request)
    {
        var rule = await repository.GetRuleByIdAsync(id);
        if (rule is null) return null;
        if (request.Name is not null) rule.Name = request.Name;
        if (request.PriceModifier.HasValue) rule.PriceModifier = request.PriceModifier.Value;
        if (request.IsActive.HasValue) rule.IsActive = request.IsActive.Value;
        if (request.ValidFrom.HasValue) rule.ValidFrom = request.ValidFrom;
        if (request.ValidUntil.HasValue) rule.ValidUntil = request.ValidUntil;
        await repository.UpdateRuleAsync(rule);
        return MapRule(rule);
    }

    public Task<bool> DeleteRuleAsync(ulong id) => repository.DeleteRuleAsync(id);

    public async Task<CalculatedPriceResponse> CalculateAsync(CalculatePriceRequest request)
    {
        var (rules, _) = await repository.GetRulesAsync(new PricingRuleListRequest { TenantId = request.TenantId });
        var applicable = rules
            .Where(r => r.AppliesTo == request.AppliesTo && (r.EntityId is null || r.EntityId == request.EntityId))
            .OrderByDescending(r => r.Priority)
            .FirstOrDefault();

        if (applicable is null)
            return new CalculatedPriceResponse { BasePrice = request.BasePrice, FinalPrice = request.BasePrice };

        var discount = applicable.ModifierType == PriceModifierType.Percentage
            ? request.BasePrice * applicable.PriceModifier / 100
            : applicable.PriceModifier;

        var final = Math.Max(0, request.BasePrice - discount);
        return new CalculatedPriceResponse
        {
            BasePrice = request.BasePrice,
            FinalPrice = final,
            Discount = discount,
            AppliedRule = applicable.Name
        };
    }

    public Task<List<DiscountResponse>> GetDiscountsAsync(ulong tenantId) =>
        Task.FromResult(_coupons.Where(c => c.TenantId == tenantId && c.IsActive).Select(MapCoupon).ToList());

    public Task<DiscountResponse> CreateDiscountAsync(CreateDiscountRequest request)
    {
        var coupon = new Coupon
        {
            Id = _couponId++,
            TenantId = request.TenantId,
            Code = request.Code.ToUpper(),
            Description = request.Description,
            Type = request.Type,
            Value = request.Value,
            MaxUses = request.MaxUses,
            ValidUntil = request.ValidUntil,
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        _coupons.Add(coupon);
        return Task.FromResult(MapCoupon(coupon));
    }

    public Task<DiscountValidationResponse> ValidateDiscountAsync(ValidateDiscountRequest request)
    {
        var coupon = _coupons.FirstOrDefault(c =>
            c.TenantId == request.TenantId &&
            c.Code == request.Code.ToUpper() &&
            c.IsActive &&
            (c.ValidUntil is null || c.ValidUntil > DateTime.UtcNow) &&
            (c.MaxUses is null || c.UsesCount < c.MaxUses));

        if (coupon is null)
            return Task.FromResult(new DiscountValidationResponse { IsValid = false, Message = "Invalid or expired discount code." });

        var discountAmount = coupon.Type == CouponType.Percentage
            ? request.OrderAmount * coupon.Value / 100
            : coupon.Value;
        if (coupon.MaxDiscount.HasValue) discountAmount = Math.Min(discountAmount, coupon.MaxDiscount.Value);
        var final = Math.Max(0, request.OrderAmount - discountAmount);

        return Task.FromResult(new DiscountValidationResponse
        {
            IsValid = true,
            Message = "Code applied successfully.",
            DiscountAmount = discountAmount,
            FinalAmount = final
        });
    }

    private static PricingRuleResponse MapRule(PricingRule r) => new()
    {
        Id = r.Id, TenantId = r.TenantId, Name = r.Name,
        AppliesTo = r.AppliesTo.ToString(), RuleType = r.RuleType.ToString(),
        PriceModifier = r.PriceModifier, ModifierType = r.ModifierType.ToString(),
        Priority = r.Priority, IsActive = r.IsActive,
        ValidFrom = r.ValidFrom, ValidUntil = r.ValidUntil, CreatedAt = r.CreatedAt
    };

    private static DiscountResponse MapCoupon(Coupon c) => new()
    {
        Id = c.Id, Code = c.Code, Type = c.Type.ToString(),
        Value = c.Value, MaxUses = c.MaxUses, UsesCount = c.UsesCount,
        IsActive = c.IsActive, ValidUntil = c.ValidUntil
    };
}
