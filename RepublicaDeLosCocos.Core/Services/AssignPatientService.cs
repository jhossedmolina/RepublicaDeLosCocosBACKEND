using RepublicaDeLosCocos.Core.Entities;
using RepublicaDeLosCocos.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace RepublicaDeLosCocos.Core.Services
{
    public class AssignPatientService : IAssignPatientService
    {
        private readonly IAssignPatientRepository _assignPatientRepository;
        private readonly ISurgeryRepository _surgeryRepository;
        private readonly IPatientRepository _patientRepository;
        public AssignPatientService(IAssignPatientRepository assignPatientRepository, ISurgeryRepository surgeryRepository, IPatientRepository patientRepository)
        {
            _assignPatientRepository = assignPatientRepository;
            _surgeryRepository = surgeryRepository;
            _patientRepository = patientRepository;
        }


        public async Task<PatientForCare> GetPatient(int id)
        {
            PatientForCare patientForCare = new PatientForCare();
            var getSurgery = await _surgeryRepository.GetSurgery(id);
            
            if(getSurgery != null && getSurgery.IdSurgeryStatus == 1)
            {
                getSurgery.IdSurgeryStatus = 2;

                var patient = _patientRepository.FirstPatient();
                patient.IdPatientStatus = 2;

                patientForCare.IdPatient = patient.Id;
                patientForCare.IdentificationNumber = patient.IdentificationNumber;
                patientForCare.FullName = patient.FullName;
                patientForCare.Symptom = patient.Symptom;
                patientForCare.IdTriage = patient.IdTriage;
                patientForCare.IdSurgery = getSurgery.Id;
                patientForCare.RegistrationDate = DateTime.Now;

                await _assignPatientRepository.InsertAssignedPatient(patientForCare);


            }
            else if (getSurgery != null && getSurgery.IdSurgeryStatus == 2)
            {
                throw new Exception($"El Consultorio {id} Esta Atendiendo A Un Paciente");
            }
            else
            {
                throw new Exception($"El Consultorio {id} No Existe");
            }

           
            return patientForCare;
        }



    }
}
