using System;
using System.Collections.Generic;

#nullable disable

namespace travelplans.Models
{
    public partial class Transpordmode
    {
        public Transpordmode()
        {
            Planprices = new HashSet<Planprice>();
        }

        public int Tid { get; set; }
        public string Tname { get; set; }
        public int Plid { get; set; }

        public virtual Plan Pl { get; set; }
        public virtual ICollection<Planprice> Planprices { get; set; }
    }
}
