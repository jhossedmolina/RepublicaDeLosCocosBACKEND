using System.Collections.Generic;

namespace RepublicaDeLosCocos.Core.Entities
{
    public partial class Surgery
    {
        public Surgery()
        {
            AssignPatient = new HashSet<AssignPatient>();
        }

        public int Id { get; set; }
        public int IdSurgeryStatus { get; set; }
        public string SurgeryName { get; set; }
        public string NameDoctor { get; set; }

        public virtual SurgeryStatus IdSurgeryStatusNavigation { get; set; }
        public virtual ICollection<AssignPatient> AssignPatient { get; set; }
    }
}
