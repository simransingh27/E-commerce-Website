using System;
using System.Collections.Generic;
using System.Text;

namespace Vendi.Data
{
    /*Class for Service offer.
     */
   public class ServiceOffer
    {
        public int ServiceOfferId { get; set; }
        public int ServiceId { get; set; }
        public string UserId { get; set; }
        public double Price { get; set; }
        public string Hours { get; set; }
        public TimeSpan Time { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsStatus { get; set; }
    }
}
