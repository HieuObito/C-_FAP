using System;
using System.Collections.Generic;

namespace Prn231_FinalProject.Models
{
    public partial class Account
    {
        public Account()
        {
            Students = new HashSet<Student>();
        }

        public int AccountId { get; set; }
        public int? RoleId { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
