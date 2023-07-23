using System;
using System.Collections.Generic;

namespace Prn231_FinalProject.Models
{
    public partial class ClassSlotDate
    {
        public int ClassSlotDate1 { get; set; }
        public int? ClassId { get; set; }
        public int? SlotDateId { get; set; }

        public virtual Class Class { get; set; }
        public virtual SlotDate SlotDate { get; set; }
    }
}
