using System;
using System.Collections.Generic;

#nullable disable

namespace travelplans.Models
{
    public partial class Planprice
    {
        public int Ppid { get; set; }
        public int Amount { get; set; }
        public int PeriodId { get; set; }
        public int Tid { get; set; }
        public int Plid { get; set; }

        public virtual Planperiod P { get; set; }
        public virtual Plan Pl { get; set; }
        public virtual Transpordmode Transpordmode { get; set; }
    }
}
