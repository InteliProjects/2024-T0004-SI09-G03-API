using Parari.Dashboard.Repository;

namespace Parati.Dashboard.Services
{
    public class MedicalTreatmentServiceImpl : IMedicalTreatmentService
    {
        private readonly IMedicalTreatmentRepository _medicalTreatmentRepository;

        public MedicalTreatmentServiceImpl(IMedicalTreatmentRepository medicalTreatmentRepository)
        {
            _medicalTreatmentRepository = medicalTreatmentRepository;
        }
        public async Task<IEnumerable<MedicalTreatmentModel>> getMedicalTreatment(string unidade)
        {
            return await _medicalTreatmentRepository.getMedicalTreatment(unidade);
        }
    }
}