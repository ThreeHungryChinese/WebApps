using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaineCoon.Models {
    public class Processer {
        public enum TLSVersion {
            TLSv1_2,
            TLSv1_3,
        }
        /// <summary>
        /// Id of every quest to data processer
        /// </summary>
        [BindNever]
        [Key]
        public int Id { get; set; }

        ///<summary>
        ///Must only use letters.
        ///The first letter is required to be uppercase.White space, numbers, and special characters are not allowed.
        ///</summary>
        [Display(Name = "Algorithm Name")]
        [StringLength(20, MinimumLength = 3), Required, RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string friendlyName { get; set; }
        /// <summary>
        /// isTrained
        /// </summary>
        [Display(Name = "isTrained")]
        public bool isTrained { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Training Callback URL")]
        [RegularExpression(@"^https://([\w-]+\.)+[\w-]+(/[\w-./?%&=]*)?$")]
        [DataType(DataType.Url)]
        [Required]
        public System.Uri trainCallbackURL { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Get Result URL")]
        [RegularExpression(@"^https://([\w-]+\.)+[\w-]+(/[\w-./?%&=]*)?$")]
        [DataType(DataType.Url)]
        [Required]
        public System.Uri getResultURL { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = " Need wait a callback for getting result?")]
        public bool isGetResultNeedWaitCallback { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Reset Algorithm URL")]
        [RegularExpression(@"^https://([\w-]+\.)+[\w-]+(/[\w-./?%&=]*)?$")]
        [DataType(DataType.Url)]
        [Required]
        public System.Uri resetURL { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "TLS version")]
        [Required]
        public TLSVersion TLSversion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Public Key")]
        [Required]
        public string publicKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name ="User's")]
        public int belongsToUserID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Call Count")]
        public int count { get; set; }
    }
}
