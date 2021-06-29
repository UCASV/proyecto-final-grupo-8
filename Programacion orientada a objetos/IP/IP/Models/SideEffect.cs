using System;
using System.Collections.Generic;

#nullable disable

namespace IP
{
    public partial class SideEffect
    {
        public SideEffect()
        {
            Effectxvacunnaions = new HashSet<Effectxvacunnaion>();
        }

        public int Id { get; set; }
        public string Disease { get; set; }

        public virtual ICollection<Effectxvacunnaion> Effectxvacunnaions { get; set; }
    }
}
