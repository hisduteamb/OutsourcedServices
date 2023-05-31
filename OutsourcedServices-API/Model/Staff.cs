namespace Model
{
    public class Staff
    {
        public int Id { get; set; }
        public int? Profile_Id { get; set; }
        public string? Name { get; set; }
        public string? FatherName { get; set; }
        public string? CNIC { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public int? Designation_Id { get; set; }
        public int? HF_Id { get; set; }
        public int? Reporting_Id { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? User_Id { get; set; }
    }

}