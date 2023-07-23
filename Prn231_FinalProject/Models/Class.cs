using System;
using System.Collections.Generic;

namespace Prn231_FinalProject.Models
{
    public partial class Class
    {
        public Class()
        {
            ClassSlotDates = new HashSet<ClassSlotDate>();
            StudentClasses = new HashSet<StudentClass>();
        }

        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int? MentorId { get; set; }
        public int? SubjectId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? Number { get; set; }
        public int? Status { get; set; }

        public virtual Mentor Mentor { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<ClassSlotDate> ClassSlotDates { get; set; }
        public virtual ICollection<StudentClass> StudentClasses { get; set; }
    }
}
