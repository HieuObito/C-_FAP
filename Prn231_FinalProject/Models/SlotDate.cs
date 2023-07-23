using System;
using System.Collections.Generic;

namespace Prn231_FinalProject.Models
{
    public partial class SlotDate
    {
        public SlotDate()
        {
            ClassSlotDates = new HashSet<ClassSlotDate>();
        }

        public int SlotDateId { get; set; }
        public int? SlotId { get; set; }
        public int? DateId { get; set; }

        public virtual WeekDay Date { get; set; }
        public virtual Slot Slot { get; set; }
        public virtual ICollection<ClassSlotDate> ClassSlotDates { get; set; }
    }
}
