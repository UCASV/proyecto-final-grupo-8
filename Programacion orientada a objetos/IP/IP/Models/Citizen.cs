using System;
using System.CodeDom;
using System.Collections.Generic;

#nullable disable

namespace IP
{
    public class Citizen
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

        public WorkSector Sector { get; set; }

        public virtual WorkSector IdWorkSectorNavigation { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }


        public Citizen(int dui, string name, int? age, int? phone, string email, WorkSector sector)
        {
            Dui = dui;
            Name = name;
            Age = age;
            Phone = phone;
            Email = email;
            Sector = sector;
        }
        
    }
}
