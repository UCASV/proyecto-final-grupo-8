using System;
using System.Collections.Generic;

#nullable disable

namespace IP
{
    public partial class Employee
    {
        public Employee()
        {
            Employeexappos = new HashSet<Employeexappo>();
            Employeexcabins = new HashSet<Employeexcabin>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? IdTypeEmployee { get; set; }

        public virtual TypeEmployee IdTypeEmployeeNavigation { get; set; }
        public virtual ICollection<Employeexappo> Employeexappos { get; set; }
        public virtual ICollection<Employeexcabin> Employeexcabins { get; set; }
    }
}
