using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaineCoon.Models {
    public class UniversityProgram {
        [BindNever]
        [Display(Name ="ProgramId")]
        [Key]
        public int Id { get; set;  }

        [Display(Name = "Program Name")]
        [Required]
        public string ProgramName { get; set; }

        [Display(Name ="UserId")]
        public int BelongsToUserId { get; set; }


        [Display(Name = "CV Text Processer Id")]
        public int CVTextProcesserId { get; set; }


        [Display(Name = "RL Text Processer Id")]
        public int RLTextProcesserId { get; set; }

        [Display(Name = "SOP Text Processer Id")]
        public int SOPTextProcesserId { get; set; }

        [Display(Name = "Score Processer Id")]
        [Required]
        public int ProcesserId { get; set; }

        [BindNever]
        [Display(Name ="Applied Count")]
        public int Count { get; set; }

        [BindNever]
        [Display(Name = "Need Train?")]
        public bool IsTrainNeeded { get; set; }
        [BindNever]
        [Display(Name = "IsEnabled")]
        public bool IsEnabled { get; set; }
    }
}
