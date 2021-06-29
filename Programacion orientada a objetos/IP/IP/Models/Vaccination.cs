using System;
using System.Collections.Generic;

#nullable disable

namespace IP
{
    public partial class Vaccination
    {
        public Vaccination()
        {
            Effectxvacunnaions = new HashSet<Effectxvacunnaion>();
        }

        public int Id { get; set; }
        public int? DuiCitizen { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdAppointment { get; set; }

        public virtual Appointment IdAppointmentNavigation { get; set; }
        public virtual ICollection<Effectxvacunnaion> Effectxvacunnaions { get; set; }
    }
}
