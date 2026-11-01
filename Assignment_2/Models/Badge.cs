using Assignment_2.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.Models
{
    public class Badge
    {
        public int BadgeId { get; set; }
        public int BadgeNumber { get; set; }
        public DateTime IssuedDate { get; set; }
        public BadgeTier Tier { get; set; }

        public int AttendeeId { get; set; }
        public Attendee Attendee { get; set; } = null!;
    }
}
