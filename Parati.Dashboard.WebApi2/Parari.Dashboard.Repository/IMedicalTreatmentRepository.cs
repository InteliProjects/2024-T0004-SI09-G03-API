namespace Parari.Dashboard.Repository;

public interface IMedicalTreatmentRepository
{
    Task<IEnumerable<MedicalTreatmentModel>> getMedicalTreatment(string unidade);
}