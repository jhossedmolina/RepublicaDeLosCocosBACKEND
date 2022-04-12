using RepublicaDeLosCocos.Core.Entities;
using RepublicaDeLosCocos.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
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


        public async Task<AssignPatient> GetPatient(int id)
        {
            AssignPatient assignPatient = new AssignPatient();
            var getSurgery = await _surgeryRepository.GetSurgery(id);
            var getSurgerys = await _surgeryRepository.GetSurgerys();
            
            if(getSurgery != null && getSurgery.IdSurgeryStatus == 1)
            {
                getSurgery.IdSurgeryStatus = 2;

                var patient = _patientRepository.FirstPatient();
                patient.IdPatientStatus = 2;

                assignPatient.IdSurgery = getSurgery.Id;
                assignPatient.IdPatient = patient.Id;
                assignPatient.IdTriage = patient.IdTriage;
                assignPatient.IdPatientStatus = 2;
                assignPatient.RegistrationDate = DateTime.Now;

                await _assignPatientRepository.InsertAssignedPatient(assignPatient);
            }
            else if (getSurgery != null && getSurgery.IdSurgeryStatus == 2)
            {
                throw new Exception($"El Consultorio {id} Esta Atendiendo A Un Paciente");
            }
            else
            {
                throw new Exception($"El Consultorio {id} No Existe");
            }

           
            return assignPatient;
        }



    }
}
