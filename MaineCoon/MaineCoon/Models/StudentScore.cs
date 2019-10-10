using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaineCoon.Models {
    public class StudentScore {
        public int id { get; set; }
        [Display(Name = "TOEFL Score")]
        public double  T { get; set; }
        [Display(Name = "GRE Score")]
        public double G { get; set; }
        [Display(Name = "Univrtdiy Ranking")]
        public double UR { get; set; }
        [Display(Name = "Statement of Purpose")]
        public double SOP { get; set; }
        [Display(Name = "Letter of Recommendation Score")]
        public double LOR { get; set; }
        [Display(Name = "GPA")]
        public double GPA { get; set; }
        [Display(Name = "Research Score")]
        public double RES { get; set; }
    }
}
