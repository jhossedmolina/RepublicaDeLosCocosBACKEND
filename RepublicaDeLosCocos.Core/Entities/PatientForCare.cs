using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaDeLosCocos.Core.Entities
{
    public class PatientForCare : AssignPatient
    {
        public int IdentificationNumber { get; set; }
        public string FullName { get; set; }
        public string Symptom { get; set; }
    }
}
