using System;
using System.Collections.Generic;

#nullable disable

namespace travelplans.Models
{
    public partial class Plan
    {
        public Plan()
        {
            Planperiods = new HashSet<Planperiod>();
            Planprices = new HashSet<Planprice>();
            Transpordmodes = new HashSet<Transpordmode>();
        }

        public int Plid { get; set; }
        public string Plname { get; set; }
        public int? Did { get; set; }

        public virtual Destination DidNavigation { get; set; }
        public virtual ICollection<Planperiod> Planperiods { get; set; }
        public virtual ICollection<Planprice> Planprices { get; set; }
        public virtual ICollection<Transpordmode> Transpordmodes { get; set; }
    }
}
