﻿namespace PaymentPortal.Domain.Models
{
    public class BaseResponse
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
    }
}
