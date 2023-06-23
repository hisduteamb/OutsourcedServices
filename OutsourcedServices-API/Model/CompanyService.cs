using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CompanyService
    {
        public int Id { get; set; }
        public int? Service_Id { get; set; }
        public int? Company_Id { get; set; }
        public string? ServiceName { get; set; }
        public string? companyName { get; set; }
        public bool? serviceStatus { get; set; }
        public bool? companyStatus { get; set; }
    }

}
