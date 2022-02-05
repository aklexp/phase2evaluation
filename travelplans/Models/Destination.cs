using System;
using System.Collections.Generic;

#nullable disable

namespace travelplans.Models
{
    public partial class Destination
    {
        public Destination()
        {
            Places = new HashSet<Place>();
            Plans = new HashSet<Plan>();
        }

        public int Did { get; set; }
        public string Dname { get; set; }

        public virtual ICollection<Place> Places { get; set; }
        public virtual ICollection<Plan> Plans { get; set; }
    }
}
