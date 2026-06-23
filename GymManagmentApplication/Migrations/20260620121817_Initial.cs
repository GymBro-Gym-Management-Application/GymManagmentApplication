using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManagmentApplication.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    OldValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeatureFlags",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plans = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureFlags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calories = table.Column<int>(type: "int", nullable: true),
                    ProteinG = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CarbsG = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FatG = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FiberG = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ServingG = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MuscleGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuscleGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Module = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plugins",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfigSchema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinPlan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plugins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScheduledTasks",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    TaskType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Payload = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RunAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Attempts = table.Column<byte>(type: "tinyint", nullable: false),
                    LastError = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledTasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SearchIndexCaches",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    SearchText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Embedding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchIndexCaches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plan = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaviconUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timezone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomDomain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrialEndsAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Criteria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Achievements_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnalyticsDaily",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    BranchId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    ReportDate = table.Column<DateOnly>(type: "date", nullable: false),
                    TotalCheckins = table.Column<long>(type: "bigint", nullable: false),
                    UniqueMembers = table.Column<long>(type: "bigint", nullable: false),
                    NewMembers = table.Column<int>(type: "int", nullable: false),
                    ChurnedMembers = table.Column<int>(type: "int", nullable: false),
                    Revenue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WorkoutsDone = table.Column<long>(type: "bigint", nullable: false),
                    ClassesHeld = table.Column<int>(type: "int", nullable: false),
                    AvgSessionMin = table.Column<int>(type: "int", nullable: true),
                    LeadsCreated = table.Column<int>(type: "int", nullable: false),
                    LeadsConverted = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalyticsDaily", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalyticsDaily_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApiKeys",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KeyHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KeyPrefix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Scopes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RateLimit = table.Column<long>(type: "bigint", nullable: false),
                    LastUsedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiKeys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiKeys_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentTemplates",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    CreatedBy = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fields = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentTemplates_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AutomationRules",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TriggerEvent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TriggerConditions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Actions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RunCount = table.Column<long>(type: "bigint", nullable: false),
                    LastRunAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutomationRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutomationRules_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ParentId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lat = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Lng = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timezone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: true),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Meta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_Branches_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Branches_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Audience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduledAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SentCount = table.Column<long>(type: "bigint", nullable: false),
                    OpenCount = table.Column<long>(type: "bigint", nullable: false),
                    ClickCount = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campaigns_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Challenges",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    CreatedBy = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Metric = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StartsAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndsAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsAutomated = table.Column<bool>(type: "bit", nullable: false),
                    Prizes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Challenges_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassTypes",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DurationMin = table.Column<short>(type: "smallint", nullable: true),
                    MaxCapacity = table.Column<short>(type: "smallint", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassTypes_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CorporateAccounts",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillingInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxMembers = table.Column<long>(type: "bigint", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorporateAccounts_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinOrder = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaxUses = table.Column<long>(type: "bigint", nullable: true),
                    UsesCount = table.Column<long>(type: "bigint", nullable: false),
                    PerUserLimit = table.Column<byte>(type: "tinyint", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidUntil = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApplicableTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coupons_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomFieldDefinitions",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FieldKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FieldType = table.Column<int>(type: "int", nullable: false),
                    Options = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFieldDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomFieldDefinitions_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomPages",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Layout = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    MetaTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomPages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomPages_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExportJobs",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    RequestedBy = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ReportType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Filters = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<long>(type: "bigint", nullable: true),
                    RowCount = table.Column<long>(type: "bigint", nullable: true),
                    ErrorMsg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExportJobs_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FeedbackSurveys",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Questions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TriggerEvent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackSurveys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeedbackSurveys_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MlPredictions",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ModelType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Confidence = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FeaturesUsed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PredictedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MlPredictions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MlPredictions_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NavigationMenus",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Items = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavigationMenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NavigationMenus_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NotificationTemplates",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Channel = table.Column<int>(type: "int", nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Variables = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationTemplates_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OnboardingSteps",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    StepKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    DoneAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SortOrder = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnboardingSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnboardingSteps_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentGateways",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Provider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfigEnc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentGateways", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentGateways_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PayrollPeriods",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    PeriodStart = table.Column<DateOnly>(type: "date", nullable: false),
                    PeriodEnd = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ProcessedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayrollPeriods_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PosOrders",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    BranchId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    ServedBy = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    OrderNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PosOrders_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PosProducts",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    BranchId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sku = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TaxRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PosProducts_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PricingRules",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppliesTo = table.Column<int>(type: "int", nullable: false),
                    EntityId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    RuleType = table.Column<int>(type: "int", nullable: false),
                    Conditions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceModifier = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModifierType = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<byte>(type: "tinyint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidUntil = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PricingRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PricingRules_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReferralPrograms",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferrerReward = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefereeReward = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxUses = table.Column<long>(type: "bigint", nullable: true),
                    UsesCount = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    StartsAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndsAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferralPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferralPrograms_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSystem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SsoProviders",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Provider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientSecretEnc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Metadata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SsoProviders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SsoProviders_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TenantFeatureOverrides",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    FeatureKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ValidUntil = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantFeatureOverrides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantFeatureOverrides_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TenantPlugins",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    PluginId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Config = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstalledAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantPlugins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantPlugins_Plugins_PluginId",
                        column: x => x.PluginId,
                        principalTable: "Plugins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TenantPlugins_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TenantSettings",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantSettings_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UiThemes",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PrimaryColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondaryColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FontHeading = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FontBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaviconUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomCss = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LayoutConfig = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UiThemes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UiThemes_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Webhooks",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecretHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Events = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    FailureCount = table.Column<byte>(type: "tinyint", nullable: false),
                    LastFiredAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Webhooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Webhooks_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AutomationLogs",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RuleId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExecutedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutomationLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutomationLogs_AutomationRules_RuleId",
                        column: x => x.RuleId,
                        principalTable: "AutomationRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccessDevices",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceUid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOnline = table.Column<bool>(type: "bit", nullable: false),
                    LastPing = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessDevices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessDevices_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FacilityEquipments",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    BranchId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseDate = table.Column<DateOnly>(type: "date", nullable: true),
                    WarrantyExpiry = table.Column<DateOnly>(type: "date", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    LocationTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IotDeviceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastServiced = table.Column<DateOnly>(type: "date", nullable: true),
                    NextService = table.Column<DateOnly>(type: "date", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityEquipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacilityEquipments_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FacilityEquipments_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FacilityEquipments_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lockers",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lockers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lockers_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MembershipPlans",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    BranchId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillingCycle = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrialDays = table.Column<byte>(type: "tinyint", nullable: false),
                    MaxMembers = table.Column<long>(type: "bigint", nullable: true),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MembershipPlans_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MembershipPlans_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommunicationLogs",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Channel = table.Column<int>(type: "int", nullable: false),
                    Direction = table.Column<int>(type: "int", nullable: false),
                    Recipient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ProviderRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CampaignId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveredAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommunicationLogs_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommunicationLogs_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PosOrderItems",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ProductId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LineTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosOrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PosOrderItems_PosOrders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "PosOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PosOrderItems_PosProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PosProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    RoleId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    PermissionId = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    BranchId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    RoleId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Uuid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    Dob = table.Column<DateOnly>(type: "date", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    EmailVerifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhoneVerifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastLoginAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LoginCount = table.Column<long>(type: "bigint", nullable: false),
                    FaceEncoding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BiometricHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreferredLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotificationPrefs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomFields = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Taggables",
                columns: table => new
                {
                    TagId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    TaggableId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    TaggableType = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taggables", x => new { x.TagId, x.TaggableId, x.TaggableType });
                    table.ForeignKey(
                        name: "FK_Taggables_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WebhookDeliveries",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebhookId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Payload = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseCode = table.Column<int>(type: "int", nullable: true),
                    ResponseBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Attempt = table.Column<byte>(type: "tinyint", nullable: false),
                    DeliveredAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebhookDeliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebhookDeliveries_Webhooks_WebhookId",
                        column: x => x.WebhookId,
                        principalTable: "Webhooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccessEvents",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    EventType = table.Column<int>(type: "int", nullable: false),
                    Method = table.Column<int>(type: "int", nullable: false),
                    Confidence = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessEvents_AccessDevices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "AccessDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccessEvents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AiChatSessions",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    SessionKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Context = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AiChatSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AiChatSessions_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AiChatSessions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    BranchId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    CheckInAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DurationMin = table.Column<short>(type: "smallint", nullable: true),
                    Method = table.Column<int>(type: "int", nullable: false),
                    GateDevice = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendances_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attendances_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attendances_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChallengeParticipants",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChallengeId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    JoinedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Progress = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChallengeParticipants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChallengeParticipants_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChallengeParticipants_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientAssessments",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ClientId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    AssessedBy = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Responses = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssessedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientAssessments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientAssessments_AssessmentTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "AssessmentTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientAssessments_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientGoals",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    TargetValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CurrentValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientGoals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientGoals_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientProfiles",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    HeightCm = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WeightKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BodyFatPct = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MuscleMassKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FitnessLevel = table.Column<int>(type: "int", nullable: true),
                    HealthConditions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Allergies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FitnessGoals = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DietPlans",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    CreatedBy = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ClientId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Goal = table.Column<int>(type: "int", nullable: false),
                    CaloriesTarget = table.Column<int>(type: "int", nullable: true),
                    ProteinG = table.Column<int>(type: "int", nullable: true),
                    CarbsG = table.Column<int>(type: "int", nullable: true),
                    FatG = table.Column<int>(type: "int", nullable: true),
                    IsAiGenerated = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    StartsOn = table.Column<DateOnly>(type: "date", nullable: true),
                    EndsOn = table.Column<DateOnly>(type: "date", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DietPlans_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DietPlans_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DietPlans_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentBookings",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    StartsAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndsAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentBookings_FacilityEquipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "FacilityEquipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentBookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentMaintenanceLogs",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    PerformedBy = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PerformedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextDue = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentMaintenanceLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentMaintenanceLogs_FacilityEquipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "FacilityEquipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentMaintenanceLogs_Users_PerformedBy",
                        column: x => x.PerformedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    CreatedBy = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCustom = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Meta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exercises_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FeedbackResponses",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Score = table.Column<short>(type: "smallint", nullable: true),
                    Responses = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeedbackResponses_FeedbackSurveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "FeedbackSurveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FeedbackResponses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GymMemberships",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    PlanId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    BranchId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StartsAt = table.Column<DateOnly>(type: "date", nullable: false),
                    EndsAt = table.Column<DateOnly>(type: "date", nullable: true),
                    PausedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CancelledAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AutoRenew = table.Column<bool>(type: "bit", nullable: false),
                    Source = table.Column<int>(type: "int", nullable: false),
                    CorporateId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymMemberships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GymMemberships_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GymMemberships_CorporateAccounts_CorporateId",
                        column: x => x.CorporateId,
                        principalTable: "CorporateAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GymMemberships_MembershipPlans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "MembershipPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GymMemberships_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GymMemberships_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HabitTrackers",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Frequency = table.Column<int>(type: "int", nullable: false),
                    Target = table.Column<byte>(type: "tinyint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitTrackers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HabitTrackers_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HealthMetrics",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    MetricDate = table.Column<DateOnly>(type: "date", nullable: false),
                    WeightKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BodyFatPct = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Bmi = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RestingHr = table.Column<int>(type: "int", nullable: true),
                    BloodPressureSys = table.Column<int>(type: "int", nullable: true),
                    BloodPressureDia = table.Column<int>(type: "int", nullable: true),
                    SleepHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StressLevel = table.Column<byte>(type: "tinyint", nullable: true),
                    HydrationMl = table.Column<int>(type: "int", nullable: true),
                    Steps = table.Column<long>(type: "bigint", nullable: true),
                    CaloriesBurned = table.Column<int>(type: "int", nullable: true),
                    RecoveryScore = table.Column<byte>(type: "tinyint", nullable: true),
                    Mood = table.Column<byte>(type: "tinyint", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthMetrics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthMetrics_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InjuryRecords",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ReportedBy = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    BodyPart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InjuryType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Severity = table.Column<int>(type: "int", nullable: false),
                    OccurredAt = table.Column<DateOnly>(type: "date", nullable: true),
                    RecoveredAt = table.Column<DateOnly>(type: "date", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AiDetected = table.Column<bool>(type: "bit", nullable: false),
                    Restrictions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InjuryRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InjuryRecords_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InjuryRecords_Users_ReportedBy",
                        column: x => x.ReportedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    MembershipId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDate = table.Column<DateOnly>(type: "date", nullable: true),
                    PaidAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Leads",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    BranchId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    AssignedTo = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AiScore = table.Column<byte>(type: "tinyint", nullable: true),
                    ConversionProb = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LastContactedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomFields = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leads_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Leads_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Leads_Users_AssignedTo",
                        column: x => x.AssignedTo,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LockerAssignments",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LockerId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    AssignedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReleasedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LockerAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LockerAssignments_Lockers_LockerId",
                        column: x => x.LockerId,
                        principalTable: "Lockers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LockerAssignments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MediaLibraries",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    UploadedBy = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MimeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<long>(type: "bigint", nullable: true),
                    Width = table.Column<int>(type: "int", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: true),
                    DurationSec = table.Column<long>(type: "bigint", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UploaderId = table.Column<decimal>(type: "decimal(20,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaLibraries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaLibraries_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MediaLibraries_Users_UploaderId",
                        column: x => x.UploaderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Channel = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ReadAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Meta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PayrollConfigs",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    BaseSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommissionRules = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayCycle = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollConfigs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayrollConfigs_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayrollConfigs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PayrollSlips",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeriodId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    BaseSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Commission = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Bonuses = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Deductions = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetPay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Breakdown = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PaidAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollSlips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayrollSlips_PayrollPeriods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "PayrollPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayrollSlips_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ReviewerId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Score = table.Column<byte>(type: "tinyint", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Referrals",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ReferrerId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    RefereeId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    RefereeEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ConvertedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RewardedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referrals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Referrals_ReferralPrograms_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "ReferralPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Referrals_Users_RefereeId",
                        column: x => x.RefereeId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Referrals_Users_ReferrerId",
                        column: x => x.ReferrerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SocialPosts",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Media = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostType = table.Column<int>(type: "int", nullable: false),
                    RefId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    LikesCount = table.Column<long>(type: "bigint", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialPosts_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SocialPosts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupportTickets",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    AssignedTo = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AiRouted = table.Column<bool>(type: "bit", nullable: false),
                    ResolvedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupportTickets_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportTickets_Users_AssignedTo",
                        column: x => x.AssignedTo,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportTickets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainerProfiles",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    BranchId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    TrainerCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExperienceYears = table.Column<byte>(type: "tinyint", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguagesKnown = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specializations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Certifications = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Allowances = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deductions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Availability = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingSettings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommissionSettings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttendanceSettings = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Documents = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialLinks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalSessions = table.Column<long>(type: "bigint", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainerProfiles_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainerProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransformationJournals",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    JournalDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransformationJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransformationJournals_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserAchievements",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    AchievementId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    EarnedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAchievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAchievements_Achievements_AchievementId",
                        column: x => x.AchievementId,
                        principalTable: "Achievements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAchievements_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserSessions",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    TokenHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceType = table.Column<int>(type: "int", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSessions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WearableDevices",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Provider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccessTokenEnc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenEnc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TokenExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastSyncedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WearableDevices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WearableDevices_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutTemplates",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    CreatedBy = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Goal = table.Column<int>(type: "int", nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false),
                    DurationMin = table.Column<int>(type: "int", nullable: true),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    IsAiGenerated = table.Column<bool>(type: "bit", nullable: false),
                    BranchingRules = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutTemplates_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkoutTemplates_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AiChatMessages",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tokens = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AiChatMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AiChatMessages_AiChatSessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "AiChatSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NutritionLogs",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    DietPlanId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    LogDate = table.Column<DateOnly>(type: "date", nullable: false),
                    MealType = table.Column<int>(type: "int", nullable: false),
                    FoodId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    FoodName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityG = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Calories = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NutritionLogs_DietPlans_DietPlanId",
                        column: x => x.DietPlanId,
                        principalTable: "DietPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NutritionLogs_FoodItems_FoodId",
                        column: x => x.FoodId,
                        principalTable: "FoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NutritionLogs_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseEquipments",
                columns: table => new
                {
                    ExerciseId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseEquipments", x => new { x.ExerciseId, x.EquipmentId });
                    table.ForeignKey(
                        name: "FK_ExerciseEquipments_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerciseEquipments_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseMuscles",
                columns: table => new
                {
                    ExerciseId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    MuscleId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseMuscles", x => new { x.ExerciseId, x.MuscleId });
                    table.ForeignKey(
                        name: "FK_ExerciseMuscles_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerciseMuscles_MuscleGroups_MuscleId",
                        column: x => x.MuscleId,
                        principalTable: "MuscleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HabitLogs",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HabitId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    LogDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Completed = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HabitLogs_HabitTrackers_HabitId",
                        column: x => x.HabitId,
                        principalTable: "HabitTrackers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CouponRedemptions",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouponId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    InvoiceId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    DiscountApplied = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RedeemedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponRedemptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CouponRedemptions_Coupons_CouponId",
                        column: x => x.CouponId,
                        principalTable: "Coupons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CouponRedemptions_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CouponRedemptions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    InvoiceId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    GatewayId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Method = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    GatewayRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GatewayResponse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentGateways_GatewayId",
                        column: x => x.GatewayId,
                        principalTable: "PaymentGateways",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeadActivities",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeadId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Outcome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadActivities_Leads_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupportTicketReplies",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    UserId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsInternal = table.Column<bool>(type: "bit", nullable: false),
                    Attachments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportTicketReplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupportTicketReplies_SupportTickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "SupportTickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportTicketReplies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GymClasses",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    BranchId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ClassTypeId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    TrainerId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartsAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndsAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxCapacity = table.Column<short>(type: "smallint", nullable: true),
                    EnrolledCount = table.Column<short>(type: "smallint", nullable: false),
                    WaitlistCount = table.Column<short>(type: "smallint", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RecurrenceRule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecurrenceId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GymClasses_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GymClasses_ClassTypes_ClassTypeId",
                        column: x => x.ClassTypeId,
                        principalTable: "ClassTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GymClasses_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GymClasses_TrainerProfiles_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "TrainerProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PtSessionTypes",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    TrainerId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DurationMin = table.Column<short>(type: "smallint", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PtSessionTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PtSessionTypes_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PtSessionTypes_TrainerProfiles_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "TrainerProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainerAnalyticsDaily",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainerId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ReportDate = table.Column<DateOnly>(type: "date", nullable: false),
                    SessionsDone = table.Column<int>(type: "int", nullable: false),
                    ClientsTrained = table.Column<int>(type: "int", nullable: false),
                    AvgRating = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WorkoutsCreated = table.Column<int>(type: "int", nullable: false),
                    RevenueGenerated = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerAnalyticsDaily", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainerAnalyticsDaily_TrainerProfiles_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "TrainerProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainerAvailabilitySlots",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainerId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    DayOfWeek = table.Column<byte>(type: "tinyint", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerAvailabilitySlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainerAvailabilitySlots_TrainerProfiles_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "TrainerProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainerClientAssignments",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainerId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ClientId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    BranchId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AssignedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerClientAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainerClientAssignments_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainerClientAssignments_TrainerProfiles_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "TrainerProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainerClientAssignments_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainerTimeOffs",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainerId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    StartsAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndsAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ApprovedBy = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerTimeOffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainerTimeOffs_TrainerProfiles_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "TrainerProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainerTimeOffs_Users_ApprovedBy",
                        column: x => x.ApprovedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutAssignments",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    TrainerId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    ClientId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    TemplateId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    AssignedAt = table.Column<DateOnly>(type: "date", nullable: false),
                    DueDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutAssignments_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkoutAssignments_TrainerProfiles_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "TrainerProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkoutAssignments_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkoutAssignments_WorkoutTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "WorkoutTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutProgressions",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    NextTemplate = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SortOrder = table.Column<byte>(type: "tinyint", nullable: false),
                    NextWorkoutTemplateId = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutProgressions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutProgressions_WorkoutTemplates_NextWorkoutTemplateId",
                        column: x => x.NextWorkoutTemplateId,
                        principalTable: "WorkoutTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkoutProgressions_WorkoutTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "WorkoutTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutSections",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    SortOrder = table.Column<byte>(type: "tinyint", nullable: false),
                    RestSeconds = table.Column<int>(type: "int", nullable: true),
                    Rounds = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutSections_WorkoutTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "WorkoutTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassBookings",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ClientId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    BookedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CancelledAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassBookings_GymClasses_ClassId",
                        column: x => x.ClassId,
                        principalTable: "GymClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassBookings_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PtSessions",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    BranchId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    SessionTypeId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    TrainerId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ClientId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    StartsAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndsAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainerNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<byte>(type: "tinyint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PtSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PtSessions_PtSessionTypes_SessionTypeId",
                        column: x => x.SessionTypeId,
                        principalTable: "PtSessionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PtSessions_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PtSessions_TrainerProfiles_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "TrainerProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PtSessions_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutLogs",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    ClientId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    TemplateId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    BranchId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DurationMin = table.Column<short>(type: "smallint", nullable: true),
                    Score = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Calories = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostureData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoodBefore = table.Column<byte>(type: "tinyint", nullable: true),
                    MoodAfter = table.Column<byte>(type: "tinyint", nullable: true),
                    FatigueLevel = table.Column<byte>(type: "tinyint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutLogs_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkoutLogs_WorkoutAssignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "WorkoutAssignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkoutLogs_WorkoutTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "WorkoutTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutExercises",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ExerciseId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    SortOrder = table.Column<byte>(type: "tinyint", nullable: false),
                    Sets = table.Column<byte>(type: "tinyint", nullable: true),
                    Reps = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DurationSeconds = table.Column<short>(type: "smallint", nullable: true),
                    RestSeconds = table.Column<short>(type: "smallint", nullable: true),
                    Tempo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeightSuggestion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Intensity = table.Column<byte>(type: "tinyint", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConditionRules = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AiSubstitutionOk = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutExercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutExercises_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkoutExercises_WorkoutSections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "WorkoutSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VirtualSessions",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    TrainerId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ClientId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    PtSessionId = table.Column<decimal>(type: "decimal(20,0)", nullable: true),
                    Provider = table.Column<int>(type: "int", nullable: false),
                    MeetingId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeetingUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Passcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartsAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndsAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordingUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VirtualSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VirtualSessions_PtSessions_PtSessionId",
                        column: x => x.PtSessionId,
                        principalTable: "PtSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VirtualSessions_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VirtualSessions_TrainerProfiles_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "TrainerProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VirtualSessions_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PoseLogs",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ExerciseId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    CapturedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Keypoints = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Corrections = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Score = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoseLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoseLogs_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PoseLogs_WorkoutLogs_LogId",
                        column: x => x.LogId,
                        principalTable: "WorkoutLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutLogSets",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ExerciseId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    SetNo = table.Column<byte>(type: "tinyint", nullable: false),
                    Reps = table.Column<int>(type: "int", nullable: true),
                    WeightKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DurationSec = table.Column<short>(type: "smallint", nullable: true),
                    DistanceM = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Rpe = table.Column<byte>(type: "tinyint", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutLogSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutLogSets_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkoutLogSets_WorkoutLogs_LogId",
                        column: x => x.LogId,
                        principalTable: "WorkoutLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessDevices_BranchId",
                table: "AccessDevices",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessEvents_DeviceId",
                table: "AccessEvents",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessEvents_UserId",
                table: "AccessEvents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_TenantId",
                table: "Achievements",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_AiChatMessages_SessionId",
                table: "AiChatMessages",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AiChatSessions_TenantId",
                table: "AiChatSessions",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_AiChatSessions_UserId",
                table: "AiChatSessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalyticsDaily_TenantId",
                table: "AnalyticsDaily",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiKeys_TenantId",
                table: "ApiKeys",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentTemplates_TenantId",
                table: "AssessmentTemplates",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_BranchId",
                table: "Attendances",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_TenantId",
                table: "Attendances",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_UserId",
                table: "Attendances",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AutomationLogs_RuleId",
                table: "AutomationLogs",
                column: "RuleId");

            migrationBuilder.CreateIndex(
                name: "IX_AutomationRules_TenantId",
                table: "AutomationRules",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_ParentId",
                table: "Branches",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_TenantId",
                table: "Branches",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_TenantId",
                table: "Campaigns",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeParticipants_ChallengeId",
                table: "ChallengeParticipants",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeParticipants_UserId",
                table: "ChallengeParticipants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_TenantId",
                table: "Challenges",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassBookings_ClassId",
                table: "ClassBookings",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassBookings_ClientId",
                table: "ClassBookings",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTypes_TenantId",
                table: "ClassTypes",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientAssessments_ClientId",
                table: "ClientAssessments",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientAssessments_TemplateId",
                table: "ClientAssessments",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientGoals_ClientId",
                table: "ClientGoals",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientProfiles_UserId",
                table: "ClientProfiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationLogs_CampaignId",
                table: "CommunicationLogs",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationLogs_TenantId",
                table: "CommunicationLogs",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateAccounts_TenantId",
                table: "CorporateAccounts",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponRedemptions_CouponId",
                table: "CouponRedemptions",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponRedemptions_InvoiceId",
                table: "CouponRedemptions",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponRedemptions_UserId",
                table: "CouponRedemptions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_TenantId",
                table: "Coupons",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFieldDefinitions_TenantId",
                table: "CustomFieldDefinitions",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomPages_TenantId",
                table: "CustomPages",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_DietPlans_ClientId",
                table: "DietPlans",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_DietPlans_CreatedBy",
                table: "DietPlans",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DietPlans_TenantId",
                table: "DietPlans",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentBookings_EquipmentId",
                table: "EquipmentBookings",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentBookings_UserId",
                table: "EquipmentBookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentMaintenanceLogs_EquipmentId",
                table: "EquipmentMaintenanceLogs",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentMaintenanceLogs_PerformedBy",
                table: "EquipmentMaintenanceLogs",
                column: "PerformedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseEquipments_EquipmentId",
                table: "ExerciseEquipments",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseMuscles_MuscleId",
                table: "ExerciseMuscles",
                column: "MuscleId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_CreatorId",
                table: "Exercises",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TenantId",
                table: "Exercises",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportJobs_TenantId",
                table: "ExportJobs",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityEquipments_BranchId",
                table: "FacilityEquipments",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityEquipments_EquipmentId",
                table: "FacilityEquipments",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityEquipments_TenantId",
                table: "FacilityEquipments",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackResponses_SurveyId",
                table: "FeedbackResponses",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackResponses_UserId",
                table: "FeedbackResponses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackSurveys_TenantId",
                table: "FeedbackSurveys",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_GymClasses_BranchId",
                table: "GymClasses",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_GymClasses_ClassTypeId",
                table: "GymClasses",
                column: "ClassTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GymClasses_TenantId",
                table: "GymClasses",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_GymClasses_TrainerId",
                table: "GymClasses",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_GymMemberships_BranchId",
                table: "GymMemberships",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_GymMemberships_CorporateId",
                table: "GymMemberships",
                column: "CorporateId");

            migrationBuilder.CreateIndex(
                name: "IX_GymMemberships_PlanId",
                table: "GymMemberships",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_GymMemberships_TenantId",
                table: "GymMemberships",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_GymMemberships_UserId",
                table: "GymMemberships",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HabitLogs_HabitId",
                table: "HabitLogs",
                column: "HabitId");

            migrationBuilder.CreateIndex(
                name: "IX_HabitTrackers_ClientId",
                table: "HabitTrackers",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthMetrics_ClientId",
                table: "HealthMetrics",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_InjuryRecords_ClientId",
                table: "InjuryRecords",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_InjuryRecords_ReportedBy",
                table: "InjuryRecords",
                column: "ReportedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_TenantId",
                table: "Invoices",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_UserId",
                table: "Invoices",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadActivities_LeadId",
                table: "LeadActivities",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_AssignedTo",
                table: "Leads",
                column: "AssignedTo");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_BranchId",
                table: "Leads",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_TenantId",
                table: "Leads",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_LockerAssignments_LockerId",
                table: "LockerAssignments",
                column: "LockerId");

            migrationBuilder.CreateIndex(
                name: "IX_LockerAssignments_UserId",
                table: "LockerAssignments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Lockers_BranchId",
                table: "Lockers",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaLibraries_TenantId",
                table: "MediaLibraries",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaLibraries_UploaderId",
                table: "MediaLibraries",
                column: "UploaderId");

            migrationBuilder.CreateIndex(
                name: "IX_MembershipPlans_BranchId",
                table: "MembershipPlans",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_MembershipPlans_TenantId",
                table: "MembershipPlans",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_MlPredictions_TenantId",
                table: "MlPredictions",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_NavigationMenus_TenantId",
                table: "NavigationMenus",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TenantId",
                table: "Notifications",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationTemplates_TenantId",
                table: "NotificationTemplates",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionLogs_ClientId",
                table: "NutritionLogs",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionLogs_DietPlanId",
                table: "NutritionLogs",
                column: "DietPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionLogs_FoodId",
                table: "NutritionLogs",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_OnboardingSteps_TenantId",
                table: "OnboardingSteps",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentGateways_TenantId",
                table: "PaymentGateways",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_GatewayId",
                table: "Payments",
                column: "GatewayId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_InvoiceId",
                table: "Payments",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_TenantId",
                table: "Payments",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollConfigs_TenantId",
                table: "PayrollConfigs",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollConfigs_UserId",
                table: "PayrollConfigs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollPeriods_TenantId",
                table: "PayrollPeriods",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollSlips_PeriodId",
                table: "PayrollSlips",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollSlips_UserId",
                table: "PayrollSlips",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PoseLogs_ExerciseId",
                table: "PoseLogs",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_PoseLogs_LogId",
                table: "PoseLogs",
                column: "LogId");

            migrationBuilder.CreateIndex(
                name: "IX_PosOrderItems_OrderId",
                table: "PosOrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PosOrderItems_ProductId",
                table: "PosOrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PosOrders_TenantId",
                table: "PosOrders",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_PosProducts_TenantId",
                table: "PosProducts",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_PricingRules_TenantId",
                table: "PricingRules",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_PtSessions_ClientId",
                table: "PtSessions",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_PtSessions_SessionTypeId",
                table: "PtSessions",
                column: "SessionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PtSessions_TenantId",
                table: "PtSessions",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_PtSessions_TrainerId",
                table: "PtSessions",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_PtSessionTypes_TenantId",
                table: "PtSessionTypes",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_PtSessionTypes_TrainerId",
                table: "PtSessionTypes",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ReviewerId",
                table: "Ratings",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_TenantId",
                table: "Ratings",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferralPrograms_TenantId",
                table: "ReferralPrograms",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Referrals_ProgramId",
                table: "Referrals",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Referrals_RefereeId",
                table: "Referrals",
                column: "RefereeId");

            migrationBuilder.CreateIndex(
                name: "IX_Referrals_ReferrerId",
                table: "Referrals",
                column: "ReferrerId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_TenantId",
                table: "Roles",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialPosts_TenantId",
                table: "SocialPosts",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialPosts_UserId",
                table: "SocialPosts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SsoProviders_TenantId",
                table: "SsoProviders",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportTicketReplies_TicketId",
                table: "SupportTicketReplies",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportTicketReplies_UserId",
                table: "SupportTicketReplies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportTickets_AssignedTo",
                table: "SupportTickets",
                column: "AssignedTo");

            migrationBuilder.CreateIndex(
                name: "IX_SupportTickets_TenantId",
                table: "SupportTickets",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportTickets_UserId",
                table: "SupportTickets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TenantId",
                table: "Tags",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantFeatureOverrides_TenantId",
                table: "TenantFeatureOverrides",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantPlugins_PluginId",
                table: "TenantPlugins",
                column: "PluginId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantPlugins_TenantId",
                table: "TenantPlugins",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSettings_TenantId",
                table: "TenantSettings",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerAnalyticsDaily_TrainerId",
                table: "TrainerAnalyticsDaily",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerAvailabilitySlots_TrainerId",
                table: "TrainerAvailabilitySlots",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerClientAssignments_BranchId",
                table: "TrainerClientAssignments",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerClientAssignments_ClientId",
                table: "TrainerClientAssignments",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerClientAssignments_TrainerId",
                table: "TrainerClientAssignments",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerProfiles_BranchId",
                table: "TrainerProfiles",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerProfiles_UserId",
                table: "TrainerProfiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerTimeOffs_ApprovedBy",
                table: "TrainerTimeOffs",
                column: "ApprovedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerTimeOffs_TrainerId",
                table: "TrainerTimeOffs",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_TransformationJournals_ClientId",
                table: "TransformationJournals",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_UiThemes_TenantId",
                table: "UiThemes",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAchievements_AchievementId",
                table: "UserAchievements",
                column: "AchievementId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAchievements_UserId",
                table: "UserAchievements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BranchId",
                table: "Users",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TenantId",
                table: "Users",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSessions_UserId",
                table: "UserSessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VirtualSessions_ClientId",
                table: "VirtualSessions",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_VirtualSessions_PtSessionId",
                table: "VirtualSessions",
                column: "PtSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_VirtualSessions_TenantId",
                table: "VirtualSessions",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_VirtualSessions_TrainerId",
                table: "VirtualSessions",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_WearableDevices_ClientId",
                table: "WearableDevices",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_WebhookDeliveries_WebhookId",
                table: "WebhookDeliveries",
                column: "WebhookId");

            migrationBuilder.CreateIndex(
                name: "IX_Webhooks_TenantId",
                table: "Webhooks",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutAssignments_ClientId",
                table: "WorkoutAssignments",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutAssignments_TemplateId",
                table: "WorkoutAssignments",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutAssignments_TenantId",
                table: "WorkoutAssignments",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutAssignments_TrainerId",
                table: "WorkoutAssignments",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExercises_ExerciseId",
                table: "WorkoutExercises",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExercises_SectionId",
                table: "WorkoutExercises",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutLogs_AssignmentId",
                table: "WorkoutLogs",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutLogs_ClientId",
                table: "WorkoutLogs",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutLogs_TemplateId",
                table: "WorkoutLogs",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutLogSets_ExerciseId",
                table: "WorkoutLogSets",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutLogSets_LogId",
                table: "WorkoutLogSets",
                column: "LogId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutProgressions_NextWorkoutTemplateId",
                table: "WorkoutProgressions",
                column: "NextWorkoutTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutProgressions_TemplateId",
                table: "WorkoutProgressions",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSections_TemplateId",
                table: "WorkoutSections",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutTemplates_CreatorId",
                table: "WorkoutTemplates",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutTemplates_TenantId",
                table: "WorkoutTemplates",
                column: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessEvents");

            migrationBuilder.DropTable(
                name: "AiChatMessages");

            migrationBuilder.DropTable(
                name: "AnalyticsDaily");

            migrationBuilder.DropTable(
                name: "ApiKeys");

            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "AutomationLogs");

            migrationBuilder.DropTable(
                name: "ChallengeParticipants");

            migrationBuilder.DropTable(
                name: "ClassBookings");

            migrationBuilder.DropTable(
                name: "ClientAssessments");

            migrationBuilder.DropTable(
                name: "ClientGoals");

            migrationBuilder.DropTable(
                name: "ClientProfiles");

            migrationBuilder.DropTable(
                name: "CommunicationLogs");

            migrationBuilder.DropTable(
                name: "CouponRedemptions");

            migrationBuilder.DropTable(
                name: "CustomFieldDefinitions");

            migrationBuilder.DropTable(
                name: "CustomPages");

            migrationBuilder.DropTable(
                name: "EquipmentBookings");

            migrationBuilder.DropTable(
                name: "EquipmentMaintenanceLogs");

            migrationBuilder.DropTable(
                name: "ExerciseEquipments");

            migrationBuilder.DropTable(
                name: "ExerciseMuscles");

            migrationBuilder.DropTable(
                name: "ExportJobs");

            migrationBuilder.DropTable(
                name: "FeatureFlags");

            migrationBuilder.DropTable(
                name: "FeedbackResponses");

            migrationBuilder.DropTable(
                name: "GymMemberships");

            migrationBuilder.DropTable(
                name: "HabitLogs");

            migrationBuilder.DropTable(
                name: "HealthMetrics");

            migrationBuilder.DropTable(
                name: "InjuryRecords");

            migrationBuilder.DropTable(
                name: "LeadActivities");

            migrationBuilder.DropTable(
                name: "LockerAssignments");

            migrationBuilder.DropTable(
                name: "MediaLibraries");

            migrationBuilder.DropTable(
                name: "MlPredictions");

            migrationBuilder.DropTable(
                name: "NavigationMenus");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "NotificationTemplates");

            migrationBuilder.DropTable(
                name: "NutritionLogs");

            migrationBuilder.DropTable(
                name: "OnboardingSteps");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "PayrollConfigs");

            migrationBuilder.DropTable(
                name: "PayrollSlips");

            migrationBuilder.DropTable(
                name: "PoseLogs");

            migrationBuilder.DropTable(
                name: "PosOrderItems");

            migrationBuilder.DropTable(
                name: "PricingRules");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Referrals");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "ScheduledTasks");

            migrationBuilder.DropTable(
                name: "SearchIndexCaches");

            migrationBuilder.DropTable(
                name: "SocialPosts");

            migrationBuilder.DropTable(
                name: "SsoProviders");

            migrationBuilder.DropTable(
                name: "SupportTicketReplies");

            migrationBuilder.DropTable(
                name: "Taggables");

            migrationBuilder.DropTable(
                name: "TenantFeatureOverrides");

            migrationBuilder.DropTable(
                name: "TenantPlugins");

            migrationBuilder.DropTable(
                name: "TenantSettings");

            migrationBuilder.DropTable(
                name: "TrainerAnalyticsDaily");

            migrationBuilder.DropTable(
                name: "TrainerAvailabilitySlots");

            migrationBuilder.DropTable(
                name: "TrainerClientAssignments");

            migrationBuilder.DropTable(
                name: "TrainerTimeOffs");

            migrationBuilder.DropTable(
                name: "TransformationJournals");

            migrationBuilder.DropTable(
                name: "UiThemes");

            migrationBuilder.DropTable(
                name: "UserAchievements");

            migrationBuilder.DropTable(
                name: "UserSessions");

            migrationBuilder.DropTable(
                name: "VirtualSessions");

            migrationBuilder.DropTable(
                name: "WearableDevices");

            migrationBuilder.DropTable(
                name: "WebhookDeliveries");

            migrationBuilder.DropTable(
                name: "WorkoutExercises");

            migrationBuilder.DropTable(
                name: "WorkoutLogSets");

            migrationBuilder.DropTable(
                name: "WorkoutProgressions");

            migrationBuilder.DropTable(
                name: "AccessDevices");

            migrationBuilder.DropTable(
                name: "AiChatSessions");

            migrationBuilder.DropTable(
                name: "AutomationRules");

            migrationBuilder.DropTable(
                name: "Challenges");

            migrationBuilder.DropTable(
                name: "GymClasses");

            migrationBuilder.DropTable(
                name: "AssessmentTemplates");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "FacilityEquipments");

            migrationBuilder.DropTable(
                name: "MuscleGroups");

            migrationBuilder.DropTable(
                name: "FeedbackSurveys");

            migrationBuilder.DropTable(
                name: "CorporateAccounts");

            migrationBuilder.DropTable(
                name: "MembershipPlans");

            migrationBuilder.DropTable(
                name: "HabitTrackers");

            migrationBuilder.DropTable(
                name: "Leads");

            migrationBuilder.DropTable(
                name: "Lockers");

            migrationBuilder.DropTable(
                name: "DietPlans");

            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "PaymentGateways");

            migrationBuilder.DropTable(
                name: "PayrollPeriods");

            migrationBuilder.DropTable(
                name: "PosOrders");

            migrationBuilder.DropTable(
                name: "PosProducts");

            migrationBuilder.DropTable(
                name: "ReferralPrograms");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "SupportTickets");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Plugins");

            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropTable(
                name: "PtSessions");

            migrationBuilder.DropTable(
                name: "Webhooks");

            migrationBuilder.DropTable(
                name: "WorkoutSections");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "WorkoutLogs");

            migrationBuilder.DropTable(
                name: "ClassTypes");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "PtSessionTypes");

            migrationBuilder.DropTable(
                name: "WorkoutAssignments");

            migrationBuilder.DropTable(
                name: "TrainerProfiles");

            migrationBuilder.DropTable(
                name: "WorkoutTemplates");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Tenants");
        }
    }
}
