using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class HrDesignation
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string? Name { get; set; }
        public Nullable<int> OrderBy { get; set; }
        public Nullable<int> Cadre_Id { get; set; }
        public Nullable<int> HrScale_Id { get; set; }
        public string? Remarks { get; set; }
        public string? Created_By { get; set; }
        public Nullable<System.DateTime> Creation_Date { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> HrScale_Id2 { get; set; }
        public Nullable<int> OD_Id { get; set; }
        public Nullable<int> HrPostTypeId { get; set; }
        public Nullable<int> PostTypeValues_Id { get; set; }

        public int  Cadre { get; set; }
        public int  HrScale { get; set; }
    }
}
