using GymManagmentApplication.Application.Challenges.Responses;

namespace GymManagmentApplication.Application.Challenges.Interfaces;

public interface IChallengesService
{
    Task<List<ActiveChallengeResponse>> GetActiveAsync(ulong userId);
}
