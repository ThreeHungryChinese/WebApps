using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaineCoon.Models {
    public class Processer {
        /// <summary>
        /// Id of every quest to data processer
        /// </summary>
        public int id { get; set; }
        public bool isTrained { get; set; }
        [Display(Name = "Training Callback URL")]
        public System.Uri trainCallbackURL { get; set; }
        [Display(Name = "Get Result URL")]
        public System.Uri getResultURL { get; set; }
        [Display(Name = "Reset Processer URL")]
        public System.Uri resetURL { get; set; }
        public int TLSversion { get; set; }
        [Display(Name = "Public Key")]
        public string publicKey { get; set; }
    }
}
