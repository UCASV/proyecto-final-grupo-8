using System;
using System.Collections.Generic;

#nullable disable

namespace IP
{
    public partial class Citizen
    {
        public Citizen()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Dui { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public int? Phone { get; set; }
        public string Email { get; set; }
        public int? IdWorkSector { get; set; }
        public int? IdAppointment { get; set; }

        public virtual WorkSector IdWorkSectorNavigation { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
