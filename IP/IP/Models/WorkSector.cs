using System;
using System.Collections.Generic;

#nullable disable

namespace IP
{
    public partial class WorkSector
    {
        public WorkSector()
        {
            Citizens = new HashSet<Citizen>();
        }

        public int IdWorkSector { get; set; }
        public string Sector { get; set; }

        public virtual ICollection<Citizen> Citizens { get; set; }
    }
}
