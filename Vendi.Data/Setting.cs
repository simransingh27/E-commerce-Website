using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vendi.Data
{
    public class Setting
    {
        [Key]
        public int SettingId { get; set; }
        public string AddressAPI { get; set; }
        public string GoogleAPI { get; set; }
        public string PaymentAPI { get; set; }
        public string MobileApiKey { get; set; }
        public string MobileApiSecret { get; set; }
        public string MobileWebsiteName { get; set; }
        public string UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
