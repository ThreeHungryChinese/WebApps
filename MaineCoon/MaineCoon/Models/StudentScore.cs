using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaineCoon.Models {
    public class StudentScore {
        public int id { get; set; }
        [Display(Name = "TOEFL Score"),Required]
        public double  T { get; set; }
        [Display(Name = "GRE Score"), Required]
        public double G { get; set; }
        [Display(Name = "Univrtdiy Ranking"), Required]
        public double UR { get; set; }
        [Display(Name = "Statement of Purpose"), Required]
        public double SOP { get; set; }
        [Display(Name = "Letter of Recommendation Score"), Required]
        public double LOR { get; set; }
        [Display(Name = "GPA"), Required]
        public double GPA { get; set; }
        [Display(Name = "Research Score"), Required]
        public double RES { get; set; }
        [Display(Name = "Result")]
        public double Result { get; set; }
    }
}
