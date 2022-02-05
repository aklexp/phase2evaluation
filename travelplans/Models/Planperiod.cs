using System;
using System.Collections.Generic;

#nullable disable

namespace travelplans.Models
{
    public partial class Planperiod
    {
        public Planperiod()
        {
            Planprices = new HashSet<Planprice>();
        }

        public int PeriodId { get; set; }
        public byte Noofdays { get; set; }
        public int Plid { get; set; }

        public virtual Plan Pl { get; set; }
        public virtual ICollection<Planprice> Planprices { get; set; }
    }
}
