using System;
using InvoiceSystem.Business.Enums;

namespace InvoiceSystem.Business.Models.AuthModel
{
    public class RequestResult
    {
        public RequestStateEnum State { get; set; }
        public string Msg { get; set; }
        public Object Data { get; set; }
    }
}
