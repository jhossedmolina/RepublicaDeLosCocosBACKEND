using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicaDeLosCocos.Core.Entities
{
    public class PatientTest
    {
        public int Id { get; set; }
        public int IdPatient { get; set; }
        public string Dna { get; set; }
        public string Dnarepresentation { get; set; }
        public DateTime CompletionDate { get; set; }

        public virtual Patient IdPatientNavigation { get; set; }
    }
}
