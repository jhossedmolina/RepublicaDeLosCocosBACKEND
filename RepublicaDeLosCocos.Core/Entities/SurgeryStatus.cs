using System.Collections.Generic;

namespace RepublicaDeLosCocos.Core.Entities
{
    public partial class SurgeryStatus
    {
        public SurgeryStatus()
        {
            Surgery = new HashSet<Surgery>();
        }

        public int Id { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<Surgery> Surgery { get; set; }
    }
}
