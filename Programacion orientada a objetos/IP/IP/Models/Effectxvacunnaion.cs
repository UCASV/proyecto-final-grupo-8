using System;
using System.Collections.Generic;

#nullable disable

namespace IP
{
    public partial class Effectxvacunnaion
    {
        public int IdSide { get; set; }
        public int IdVaci { get; set; }

        public virtual SideEffect IdSideNavigation { get; set; }
        public virtual Vaccination IdVaciNavigation { get; set; }
    }
}
