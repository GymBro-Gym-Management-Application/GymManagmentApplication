using System.Text.Json;
using GymManagmentApplication.Domain.Entities.Platform;

namespace GymManagmentApplication.Infrastructure.Repositories.Onboarding;

public class OnboardingRepository : IOnboardingRepository
{
    private static readonly List<OnboardingStep> _steps = [];
    private static readonly List<ClientAssessment> _assessments = [];
    private static readonly List<AssessmentTemplate> _templates = [];
    private static ulong _stepId = 1;
    private static ulong _assessId = 1;
    private static ulong _tmplId = 1;

    public Task<List<OnboardingStep>> GetStepsByMemberAsync(ulong memberId) =>
        Task.FromResult(_steps.Where(s => s.TenantId == memberId).ToList());

    public Task<List<OnboardingStep>> CreateStepsAsync(List<OnboardingStep> steps)
    {
        foreach (var s in steps) { s.Id = _stepId++; }
        _steps.AddRange(steps);
        return Task.FromResult(steps);
    }

    public Task<OnboardingStep?> GetStepAsync(ulong memberId, string stepKey) =>
        Task.FromResult(_steps.FirstOrDefault(s => s.TenantId == memberId && s.StepKey == stepKey));

    public Task<OnboardingStep> UpdateStepAsync(OnboardingStep step) => Task.FromResult(step);

    public Task<ClientAssessment> CreateAssessmentAsync(ClientAssessment assessment)
    {
        assessment.Id = _assessId++;
        assessment.AssessedAt = DateTime.UtcNow;
        _assessments.Add(assessment);
        return Task.FromResult(assessment);
    }

    public Task<List<AssessmentTemplate>> GetTemplatesAsync(ulong tenantId) =>
        Task.FromResult(_templates.Where(t => t.TenantId == tenantId).ToList());

    public Task<AssessmentTemplate> CreateTemplateAsync(AssessmentTemplate template)
    {
        template.Id = _tmplId++;
        template.CreatedAt = DateTime.UtcNow;
        _templates.Add(template);
        return Task.FromResult(template);
    }
}
