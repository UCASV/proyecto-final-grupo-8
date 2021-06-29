using System;
using System.Collections.Generic;

#nullable disable

namespace IP
{
    public partial class Cabin
    {
        public Cabin()
        {
            Employeexcabins = new HashSet<Employeexcabin>();
        }

        public int IdCabin { get; set; }
        public int? Phone { get; set; }
        public string Email { get; set; }
        public int? IdEmployee { get; set; }

        public virtual ICollection<Employeexcabin> Employeexcabins { get; set; }
    }
}
