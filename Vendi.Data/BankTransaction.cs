﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vendi.Data
{
   public class BankTransaction
    {
        [Key]
        public string TransactionId { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string OrderId { get; set; }
        public double Amount { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
    }
}
