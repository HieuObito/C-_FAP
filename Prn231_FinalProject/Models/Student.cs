using System;
using System.Collections.Generic;

namespace Prn231_FinalProject.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentClasses = new HashSet<StudentClass>();
        }
        public int StudentId { get; set; }
        public string? StudentCode { get; set; }
        public string? StudentName { get; set; }
        public string? StudentDesc { get; set; }
        public string? StudentImg { get; set; }
        public int? AccountId { get; set; }
        public int? Status { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<StudentClass> StudentClasses { get; set; }
    }
}
