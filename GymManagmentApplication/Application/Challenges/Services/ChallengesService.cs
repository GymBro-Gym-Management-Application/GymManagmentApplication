using System.Text.Json;
using GymManagmentApplication.Application.Challenges.Interfaces;
using GymManagmentApplication.Application.Challenges.Responses;
using GymManagmentApplication.Domain.Enums;
using GymManagmentApplication.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GymManagmentApplication.Application.Challenges.Services;

public class ChallengesService(AppDbContext db) : IChallengesService
{
    public async Task<List<ActiveChallengeResponse>> GetActiveAsync(ulong userId)
    {
        var now = DateTime.UtcNow;

        var challenges = await db.Challenges
            .Where(c => c.Status == ChallengeStatus.Active && c.EndsAt >= now)
            .OrderBy(c => c.EndsAt)
            .Select(c => new
            {
                c.Id,
                c.Title,
                c.TargetValue,
                c.Prizes
            })
            .ToListAsync();

        if (challenges.Count == 0) return [];

        var challengeIds = challenges.Select(c => c.Id).ToList();

        var participantCounts = await db.ChallengeParticipants
            .Where(p => challengeIds.Contains(p.ChallengeId))
            .GroupBy(p => p.ChallengeId)
            .Select(g => new { ChallengeId = g.Key, Count = g.Count() })
            .ToDictionaryAsync(g => g.ChallengeId, g => g.Count);

        var myProgress = await db.ChallengeParticipants
            .Where(p => challengeIds.Contains(p.ChallengeId) && p.UserId == userId)
            .ToDictionaryAsync(p => p.ChallengeId, p => p.Progress);

        return challenges.Select(c =>
        {
            var isJoined = myProgress.TryGetValue(c.Id, out var progress);
            var progressPct = 0.0;
            if (isJoined)
            {
                progressPct = c.TargetValue.HasValue && c.TargetValue.Value > 0
                    ? (double)(progress / c.TargetValue.Value * 100)
                    : (double)progress;
                progressPct = Math.Clamp(progressPct, 0, 100);
            }

            return new ActiveChallengeResponse
            {
                Id = c.Id,
                Title = c.Title,
                ParticipantCount = participantCounts.TryGetValue(c.Id, out var count) ? count : 0,
                PrizeLabel = TryGetPrizeLabel(c.Prizes),
                ProgressPct = Math.Round(progressPct, 1),
                IsJoined = isJoined
            };
        }).ToList();
    }

    private static string? TryGetPrizeLabel(JsonDocument? prizes)
    {
        if (prizes is null) return null;

        try
        {
            var root = prizes.RootElement;

            if (root.ValueKind == JsonValueKind.Array && root.GetArrayLength() > 0)
            {
                root = root[0];
            }

            if (root.ValueKind != JsonValueKind.Object) return null;

            if (root.TryGetProperty("label", out var labelEl) && labelEl.ValueKind == JsonValueKind.String)
            {
                var label = labelEl.GetString();
                if (!string.IsNullOrWhiteSpace(label)) return label;
            }

            if (root.TryGetProperty("amount", out var amountEl))
            {
                if (amountEl.ValueKind == JsonValueKind.Number)
                    return amountEl.GetDecimal().ToString("0.##");
                if (amountEl.ValueKind == JsonValueKind.String && !string.IsNullOrWhiteSpace(amountEl.GetString()))
                    return amountEl.GetString();
            }
        }
        catch
        {
            return null;
        }

        return null;
    }
}
