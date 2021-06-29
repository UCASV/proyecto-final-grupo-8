using System;
using System.Collections.Generic;

#nullable disable

namespace IP
{
    public partial class Appointment
    {
        public Appointment()
        {
            Employeexappos = new HashSet<Employeexappo>();
            Vaccinations = new HashSet<Vaccination>();
        }

        public int Id { get; set; }
        public int? DuiCitizen { get; set; }
        public string IdSideEffect { get; set; }
        public int? TypeDose { get; set; }

        public virtual Citizen DuiCitizenNavigation { get; set; }
        public virtual ICollection<Employeexappo> Employeexappos { get; set; }
        public virtual ICollection<Vaccination> Vaccinations { get; set; }
    }
}
