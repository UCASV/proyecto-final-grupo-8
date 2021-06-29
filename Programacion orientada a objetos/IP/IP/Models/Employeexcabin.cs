using System;
using System.Collections.Generic;

#nullable disable

namespace IP
{
    public partial class Employeexcabin
    {
        public int IdEmployee { get; set; }
        public int IdCabin { get; set; }
        public DateTime? Fecha { get; set; }
        public TimeSpan? Hora { get; set; }

        public virtual Cabin IdCabinNavigation { get; set; }
        public virtual Employee IdEmployeeNavigation { get; set; }
    }
}
