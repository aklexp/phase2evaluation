using System;
using System.Collections.Generic;

#nullable disable

namespace travelplans.Models
{
    public partial class Place
    {
        public int Pid { get; set; }
        public string Pname { get; set; }
        public int Did { get; set; }

        public virtual Destination DidNavigation { get; set; }
    }
}
