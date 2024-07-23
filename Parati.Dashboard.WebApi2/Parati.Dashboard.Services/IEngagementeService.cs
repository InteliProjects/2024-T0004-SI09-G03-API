using Parari.Dashboard.Repository;

namespace Parati.Dashboard.Services;

public interface IEngagementeService
{
    Task<IEnumerable<EngagementModel>> GetData();
}