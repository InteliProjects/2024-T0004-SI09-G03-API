namespace Parari.Dashboard.Repository;

public interface IEngagementRepository
{
    Task<IEnumerable<EngagementModel>> GetEngagiment();
}