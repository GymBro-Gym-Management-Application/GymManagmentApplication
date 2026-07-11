namespace GymManagmentApplication.Application.Health.Responses;

public class HealthRingResponse
{
    public double Current { get; set; }
    public double Goal { get; set; }
}

public class HealthRingsResponse
{
    public HealthRingResponse Move { get; set; } = default!;
    public HealthRingResponse Train { get; set; } = default!;
    public HealthRingResponse Stand { get; set; } = default!;
}

public class HealthStatsResponse
{
    public ushort? Bpm { get; set; }
    public decimal? WaterLiters { get; set; }
    public decimal? SleepHours { get; set; }
    public byte? EnergyPct { get; set; }
}

public class HealthTodayResponse
{
    public HealthRingsResponse Rings { get; set; } = default!;
    public HealthStatsResponse Stats { get; set; } = default!;
    public int StreakDays { get; set; }
}
