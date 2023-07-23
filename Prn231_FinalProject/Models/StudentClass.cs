using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Prn231_FinalProject.Models
{
    public partial class StudentClass
    {
        public int? StudentClass1 { get; set; }
        public int? StudentId { get; set; }
        public int? ClassId { get; set; }
        public virtual Class? Class { get; set; }
        public virtual Student? Student { get; set; }
    }
}
