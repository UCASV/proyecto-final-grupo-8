using System;
using System.Collections.Generic;

#nullable disable

namespace IP
{
    public partial class Disease
    {
        public Disease()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string Disease1 { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
