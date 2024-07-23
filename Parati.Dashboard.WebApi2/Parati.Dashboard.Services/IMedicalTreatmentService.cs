using Parari.Dashboard.Repository;

namespace Parati.Dashboard.Services;

public interface IMedicalTreatmentService
{
    Task<IEnumerable<MedicalTreatmentModel>> getMedicalTreatment(string unidade);
}