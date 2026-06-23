using GymManagmentApplication.Domain.Entities.AI;
using GymManagmentApplication.Domain.Entities.Analytics;
using GymManagmentApplication.Domain.Entities.Automation;
using GymManagmentApplication.Domain.Entities.Billing;
using GymManagmentApplication.Domain.Entities.Communication;
using GymManagmentApplication.Domain.Entities.Core;
using GymManagmentApplication.Domain.Entities.CRM;
using GymManagmentApplication.Domain.Entities.Facility;
using GymManagmentApplication.Domain.Entities.Gamification;
using GymManagmentApplication.Domain.Entities.Health;
using GymManagmentApplication.Domain.Entities.HR;
using GymManagmentApplication.Domain.Entities.Identity;
using GymManagmentApplication.Domain.Entities.Membership;
using GymManagmentApplication.Domain.Entities.Nutrition;
using GymManagmentApplication.Domain.Entities.CRM;
using GymManagmentApplication.Domain.Entities.Platform;
using GymManagmentApplication.Domain.Entities.POS;
using GymManagmentApplication.Domain.Entities.Scheduling;
using GymManagmentApplication.Domain.Entities.Training;
using Microsoft.EntityFrameworkCore;

namespace GymManagmentApplication.Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    // Core
    public DbSet<Tenant> Tenants => Set<Tenant>();
    public DbSet<Branch> Branches => Set<Branch>();
    public DbSet<TenantSetting> TenantSettings => Set<TenantSetting>();

    // Identity
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
    public DbSet<UserSession> UserSessions => Set<UserSession>();
    public DbSet<SsoProvider> SsoProviders => Set<SsoProvider>();

    // Membership
    public DbSet<MembershipPlan> MembershipPlans => Set<MembershipPlan>();
    public DbSet<GymMembership> GymMemberships => Set<GymMembership>();
    public DbSet<CorporateAccount> CorporateAccounts => Set<CorporateAccount>();

    // Training
    public DbSet<TrainerProfile> TrainerProfiles => Set<TrainerProfile>();
    public DbSet<TrainerClientAssignment> TrainerClientAssignments => Set<TrainerClientAssignment>();
    public DbSet<TrainerAvailabilitySlot> TrainerAvailabilitySlots => Set<TrainerAvailabilitySlot>();
    public DbSet<TrainerTimeOff> TrainerTimeOffs => Set<TrainerTimeOff>();
    public DbSet<Exercise> Exercises => Set<Exercise>();
    public DbSet<MuscleGroup> MuscleGroups => Set<MuscleGroup>();
    public DbSet<ExerciseMuscle> ExerciseMuscles => Set<ExerciseMuscle>();
    public DbSet<Equipment> Equipments => Set<Equipment>();
    public DbSet<ExerciseEquipment> ExerciseEquipments => Set<ExerciseEquipment>();
    public DbSet<WorkoutTemplate> WorkoutTemplates => Set<WorkoutTemplate>();
    public DbSet<WorkoutSection> WorkoutSections => Set<WorkoutSection>();
    public DbSet<WorkoutExercise> WorkoutExercises => Set<WorkoutExercise>();
    public DbSet<WorkoutAssignment> WorkoutAssignments => Set<WorkoutAssignment>();
    public DbSet<WorkoutLog> WorkoutLogs => Set<WorkoutLog>();
    public DbSet<WorkoutLogSet> WorkoutLogSets => Set<WorkoutLogSet>();
    public DbSet<WorkoutProgression> WorkoutProgressions => Set<WorkoutProgression>();
    public DbSet<PtSessionType> PtSessionTypes => Set<PtSessionType>();
    public DbSet<PtSession> PtSessions => Set<PtSession>();

    // Scheduling
    public DbSet<ClassType> ClassTypes => Set<ClassType>();
    public DbSet<GymClass> GymClasses => Set<GymClass>();
    public DbSet<ClassBooking> ClassBookings => Set<ClassBooking>();
    public DbSet<Attendance> Attendances => Set<Attendance>();

    // Billing
    public DbSet<Invoice> Invoices => Set<Invoice>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<PaymentGateway> PaymentGateways => Set<PaymentGateway>();
    public DbSet<Coupon> Coupons => Set<Coupon>();
    public DbSet<CouponRedemption> CouponRedemptions => Set<CouponRedemption>();

    // CRM
    public DbSet<Lead> Leads => Set<Lead>();
    public DbSet<LeadActivity> LeadActivities => Set<LeadActivity>();
    public DbSet<Referral> Referrals => Set<Referral>();
    public DbSet<ReferralProgram> ReferralPrograms => Set<ReferralProgram>();

    // Health
    public DbSet<ClientProfile> ClientProfiles => Set<ClientProfile>();
    public DbSet<ClientGoal> ClientGoals => Set<ClientGoal>();
    public DbSet<HealthMetric> HealthMetrics => Set<HealthMetric>();
    public DbSet<HabitTracker> HabitTrackers => Set<HabitTracker>();
    public DbSet<HabitLog> HabitLogs => Set<HabitLog>();
    public DbSet<InjuryRecord> InjuryRecords => Set<InjuryRecord>();
    public DbSet<TransformationJournal> TransformationJournals => Set<TransformationJournal>();
    public DbSet<WearableDevice> WearableDevices => Set<WearableDevice>();

    // Nutrition
    public DbSet<DietPlan> DietPlans => Set<DietPlan>();
    public DbSet<FoodItem> FoodItems => Set<FoodItem>();
    public DbSet<NutritionLog> NutritionLogs => Set<NutritionLog>();

    // Facility
    public DbSet<FacilityEquipment> FacilityEquipments => Set<FacilityEquipment>();
    public DbSet<EquipmentMaintenanceLog> EquipmentMaintenanceLogs => Set<EquipmentMaintenanceLog>();
    public DbSet<EquipmentBooking> EquipmentBookings => Set<EquipmentBooking>();
    public DbSet<Locker> Lockers => Set<Locker>();
    public DbSet<LockerAssignment> LockerAssignments => Set<LockerAssignment>();
    public DbSet<AccessDevice> AccessDevices => Set<AccessDevice>();
    public DbSet<AccessEvent> AccessEvents => Set<AccessEvent>();

    // POS
    public DbSet<PosProduct> PosProducts => Set<PosProduct>();
    public DbSet<PosOrder> PosOrders => Set<PosOrder>();
    public DbSet<PosOrderItem> PosOrderItems => Set<PosOrderItem>();

    // HR
    public DbSet<PayrollConfig> PayrollConfigs => Set<PayrollConfig>();
    public DbSet<PayrollPeriod> PayrollPeriods => Set<PayrollPeriod>();
    public DbSet<PayrollSlip> PayrollSlips => Set<PayrollSlip>();

    // Gamification
    public DbSet<Achievement> Achievements => Set<Achievement>();
    public DbSet<UserAchievement> UserAchievements => Set<UserAchievement>();
    public DbSet<Challenge> Challenges => Set<Challenge>();
    public DbSet<ChallengeParticipant> ChallengeParticipants => Set<ChallengeParticipant>();

    // Communication
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<NotificationTemplate> NotificationTemplates => Set<NotificationTemplate>();
    public DbSet<Campaign> Campaigns => Set<Campaign>();
    public DbSet<CommunicationLog> CommunicationLogs => Set<CommunicationLog>();
    public DbSet<FeedbackSurvey> FeedbackSurveys => Set<FeedbackSurvey>();
    public DbSet<FeedbackResponse> FeedbackResponses => Set<FeedbackResponse>();
    public DbSet<Webhook> Webhooks => Set<Webhook>();
    public DbSet<WebhookDelivery> WebhookDeliveries => Set<WebhookDelivery>();

    // Analytics
    public DbSet<AnalyticsDaily> AnalyticsDaily => Set<AnalyticsDaily>();
    public DbSet<TrainerAnalyticsDaily> TrainerAnalyticsDaily => Set<TrainerAnalyticsDaily>();

    // Automation
    public DbSet<AutomationRule> AutomationRules => Set<AutomationRule>();
    public DbSet<AutomationLog> AutomationLogs => Set<AutomationLog>();
    public DbSet<ScheduledTask> ScheduledTasks => Set<ScheduledTask>();

    // AI
    public DbSet<AiChatSession> AiChatSessions => Set<AiChatSession>();
    public DbSet<AiChatMessage> AiChatMessages => Set<AiChatMessage>();
    public DbSet<MlPrediction> MlPredictions => Set<MlPrediction>();
    public DbSet<PoseLog> PoseLogs => Set<PoseLog>();

    // Platform
    public DbSet<OnboardingStep> OnboardingSteps => Set<OnboardingStep>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
    public DbSet<ApiKey> ApiKeys => Set<ApiKey>();
    public DbSet<FeatureFlag> FeatureFlags => Set<FeatureFlag>();
    public DbSet<Plugin> Plugins => Set<Plugin>();
    public DbSet<TenantPlugin> TenantPlugins => Set<TenantPlugin>();
    public DbSet<TenantFeatureOverride> TenantFeatureOverrides => Set<TenantFeatureOverride>();
    public DbSet<SupportTicket> SupportTickets => Set<SupportTicket>();
    public DbSet<SupportTicketReply> SupportTicketReplies => Set<SupportTicketReply>();
    public DbSet<MediaLibrary> MediaLibraries => Set<MediaLibrary>();
    public DbSet<UiTheme> UiThemes => Set<UiTheme>();
    public DbSet<NavigationMenu> NavigationMenus => Set<NavigationMenu>();
    public DbSet<CustomPage> CustomPages => Set<CustomPage>();
    public DbSet<CustomFieldDefinition> CustomFieldDefinitions => Set<CustomFieldDefinition>();
    public DbSet<AssessmentTemplate> AssessmentTemplates => Set<AssessmentTemplate>();
    public DbSet<ClientAssessment> ClientAssessments => Set<ClientAssessment>();
    public DbSet<Rating> Ratings => Set<Rating>();
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<Taggable> Taggables => Set<Taggable>();
    public DbSet<SocialPost> SocialPosts => Set<SocialPost>();
    public DbSet<VirtualSession> VirtualSessions => Set<VirtualSession>();
    public DbSet<ExportJob> ExportJobs => Set<ExportJob>();
    public DbSet<SearchIndexCache> SearchIndexCaches => Set<SearchIndexCache>();
    public DbSet<PricingRule> PricingRules => Set<PricingRule>();

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<System.Text.Json.JsonDocument>()
            .HaveConversion<JsonDocumentConverter>()
            .HaveColumnType("nvarchar(max)");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Composite keys
        modelBuilder.Entity<RolePermission>().HasKey(rp => new { rp.RoleId, rp.PermissionId });
        modelBuilder.Entity<ExerciseMuscle>().HasKey(em => new { em.ExerciseId, em.MuscleId });
        modelBuilder.Entity<ExerciseEquipment>().HasKey(ee => new { ee.ExerciseId, ee.EquipmentId });
        modelBuilder.Entity<Taggable>().HasKey(t => new { t.TagId, t.TaggableId, t.TaggableType });

        // Explicit FKs for entities with multiple User navigations
        modelBuilder.Entity<SupportTicket>(e =>
        {
            e.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            e.HasOne(x => x.AssignedUser).WithMany().HasForeignKey(x => x.AssignedTo).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<InjuryRecord>(e =>
        {
            e.HasOne(x => x.Client).WithMany().HasForeignKey(x => x.ClientId).OnDelete(DeleteBehavior.Restrict);
            e.HasOne(x => x.Reporter).WithMany().HasForeignKey(x => x.ReportedBy).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<DietPlan>(e =>
        {
            e.HasOne(x => x.Creator).WithMany().HasForeignKey(x => x.CreatedBy).OnDelete(DeleteBehavior.Restrict);
            e.HasOne(x => x.Client).WithMany().HasForeignKey(x => x.ClientId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<TrainerTimeOff>(e =>
        {
            e.HasOne(x => x.Trainer).WithMany(t => t.TimeOffs).HasForeignKey(x => x.TrainerId).OnDelete(DeleteBehavior.Restrict);
            e.HasOne(x => x.Approver).WithMany().HasForeignKey(x => x.ApprovedBy).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<EquipmentMaintenanceLog>(e =>
        {
            e.HasOne(x => x.Equipment).WithMany(eq => eq.MaintenanceLogs).HasForeignKey(x => x.EquipmentId).OnDelete(DeleteBehavior.Restrict);
            e.HasOne(x => x.Performer).WithMany().HasForeignKey(x => x.PerformedBy).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Lead>(e =>
        {
            e.HasOne(x => x.AssignedUser).WithMany().HasForeignKey(x => x.AssignedTo).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Referral>(e =>
        {
            e.HasOne(x => x.Referrer).WithMany().HasForeignKey(x => x.ReferrerId).OnDelete(DeleteBehavior.Restrict);
            e.HasOne(x => x.Referee).WithMany().HasForeignKey(x => x.RefereeId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<NutritionLog>(e =>
        {
            e.HasOne(x => x.Client).WithMany().HasForeignKey(x => x.ClientId).OnDelete(DeleteBehavior.Restrict);
            e.HasOne(x => x.DietPlan).WithMany(d => d.NutritionLogs).HasForeignKey(x => x.DietPlanId).OnDelete(DeleteBehavior.Restrict);
        });

        foreach (var entity in modelBuilder.Model.GetEntityTypes())
            foreach (var prop in entity.GetProperties())
                if (prop.ClrType == typeof(ulong) || prop.ClrType == typeof(ulong?))
                    prop.SetColumnType("decimal(20,0)");

        // Disable cascade delete globally to prevent multiple cascade path errors in SQL Server
        foreach (var relationship in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys()))
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
    }
}

public class JsonDocumentConverter : Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<System.Text.Json.JsonDocument, string>
{
    public JsonDocumentConverter() : base(
        v => v.RootElement.GetRawText(),
        v => System.Text.Json.JsonDocument.Parse(v, default)) { }
}
