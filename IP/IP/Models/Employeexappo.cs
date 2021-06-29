using System;
using System.Collections.Generic;

#nullable disable

namespace IP
{
    public partial class Employeexappo
    {
        public int IdEmployee { get; set; }
        public int IdAppointment { get; set; }

        public virtual Appointment IdAppointmentNavigation { get; set; }
        public virtual Employee IdEmployeeNavigation { get; set; }
    }
}
