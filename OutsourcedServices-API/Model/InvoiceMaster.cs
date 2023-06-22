using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class InvoiceMaster
    {
        public int Id { get; set; }
        public int? Company_Id { get; set; }

        public int? OutsourceService_Id { get;set; }
        public int? CurrentOfficer_Id { get;set; }
        public int? TrackingNumber { get;set; }
        public int? Status_Id { get;set; }
        public int? Amount { get;set; }
        public string? Comments { get; set; }
        public DateTime? StatusDatetime { get; set; }
        public int? InvoiceMaster_Id { get; set; }

        public int? Staff_Id { get; set; }
        public int? Quantity { get;set; }
        public int? AttendanceInDays { get;set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
