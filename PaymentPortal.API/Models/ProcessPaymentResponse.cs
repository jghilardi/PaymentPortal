﻿namespace PaymentPortal.API.Models
{
    public class ProcessPaymentResponse
    {
        public bool IsSuccessful { get; set; }
        public decimal AccountBalance { get; set; }
    }
}
