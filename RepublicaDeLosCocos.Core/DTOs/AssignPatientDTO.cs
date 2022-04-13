using System;

namespace RepublicaDeLosCocos.Core.DTOs
{
    public class AssignPatientDTO
    {
        public int IdSurgery { get; set; }
        public int IdPatient { get; set; }
        public int IdTriage { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
