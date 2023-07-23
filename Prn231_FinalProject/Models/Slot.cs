using System;
using System.Collections.Generic;

namespace Prn231_FinalProject.Models
{
    public partial class Slot
    {
        public Slot()
        {
            SlotDates = new HashSet<SlotDate>();
        }

        public int SlotId { get; set; }
        public string SlotName { get; set; }
        public TimeSpan? TimeFrom { get; set; }
        public TimeSpan? TimeTo { get; set; }

        public virtual ICollection<SlotDate> SlotDates { get; set; }
    }
}
