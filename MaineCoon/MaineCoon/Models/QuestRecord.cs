using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace MaineCoon.Models {
    /// <summary>
    /// Record will be deleted after receive a vaild callback
    /// quest like: https://{processer's url}?token = {token} & isusingurl = {if using url resource: true} & <usingurlresource = {if using url resource}> & callback = {callbackurl} & <data = {student data,if not using url source}> & timestamp = {timestamp}
    /// </summary>
    public class QuestRecord {
        /// <summary>
        /// Id of every quest to data processer
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// true- URL //for bigger than 8 kb  request
        /// false - TLS
        /// </summary>
        public bool isUsingURL { get; set; }
        /// <summary>
        /// for method = URL, allow NuLL, <default = >
        /// </summary>
        public System.Uri resourceURL { get; set; }
        /// <summary>
        /// TOKEN
        /// </summary>
        public string TOKEN { get; set; }
        /// <summary>
        /// timeStamp for created a quest
        /// </summary>
        [DataType(DataType.Time)]
        public int timeStamp { get; set; }
        /// <summary>
        /// false = get, true = true
        /// </summary>
        /*
        public bool isRequestUsePost { get; set; }
        /// <summary>
        /// AES key in this quest
        /// </summary>
        public BigInteger AESkey { get; set; }
        /// <summary>
        /// 0-on encrypt: TLS provided,  <1- on constructiong>
        /// </summary>
        public int encryptionMethod { get; set; }
        */
    }
}
