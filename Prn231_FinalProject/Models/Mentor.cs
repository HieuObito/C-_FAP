using System;
using System.Collections.Generic;

namespace Prn231_FinalProject.Models
{
    public partial class Mentor
    {
        public Mentor()
        {
            Classes = new HashSet<Class>();
        }

        public int MentorId { get; set; }
        public string? MentorName { get; set; }
        public string? MentorDesc { get; set; }
        public string? Note { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
