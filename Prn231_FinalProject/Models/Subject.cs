using System;
using System.Collections.Generic;

namespace Prn231_FinalProject.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Classes = new HashSet<Class>();
        }

        public int SubjectId { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
