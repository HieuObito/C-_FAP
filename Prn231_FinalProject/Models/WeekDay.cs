using System;
using System.Collections.Generic;

namespace Prn231_FinalProject.Models
{
    public partial class WeekDay
    {
        public WeekDay()
        {
            SlotDates = new HashSet<SlotDate>();
        }

        public int DateId { get; set; }
        public string DateName { get; set; }

        public virtual ICollection<SlotDate> SlotDates { get; set; }
    }
}
