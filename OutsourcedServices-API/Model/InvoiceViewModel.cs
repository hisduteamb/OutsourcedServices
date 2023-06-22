using System;
using System.Collections.Generic;
using System.Numerics;

namespace YourNamespace.Models
{
    public class InvoiceViewModel
    {
        public long? TrackingNumber { get; set; }
        public int? StatusId { get; set; }
        public DateTime StatusDatetime { get; set; }
        public int? Amount { get; set; }
        public string? Comments { get; set; }
        public int? CurrentOfficerId { get; set; }
        public int? CompanyId { get; set; }
        public int? OutsourceServiceId { get; set; }
        public bool? IsReceived { get; set; }
        public DateTime ReceiveDatetime { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? User_Id { get; set; }
        public List<InvoiceItemViewModel> InvoiceDetail { get; set; }
    }

    public class InvoiceItemViewModel
    {
        public int? InvoiceMaster_Id { get; set; }
        public int? StaffId { get; set; }
        public int? ItemId { get; set; }
        public int? Quantity { get; set; }
        public int? AttendanceInDays { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? User_Id { get; set; }
    }
}