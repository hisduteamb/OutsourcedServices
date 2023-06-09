﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public  class HFListP
    {
        public int Id { get; set; }
        public string? HFMISCode { get; set; }
        public string? Name { get; set; }
        public string? FullName { get; set; }
        public int HFAC { get; set; }
        public string? ImagePath { get; set; }
        public string? urlImagePath { get; set; }
        public string? DivisionCode { get; set; }
        public string DivisionName { get; set; }
        public string? DistrictCode { get; set; }
        public string? DistrictName { get; set; }
        public string? TehsilCode { get; set; }
        public string? TehsilName { get; set; }
        public string? CategoryCode { get; set; }
        public string? HFCategoryName { get; set; }
        public string? HFTypeCode { get; set; }
        public string? HFTypeName { get; set; }
        public Nullable<int> OrderBy { get; set; }
        public Nullable<long> Entity_Lifecycle_Id { get; set; }
        public string? PhoneNo { get; set; }
        public string? FaxNo { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Status { get; set; }
        public Nullable<double> CoveredArea { get; set; }
        public Nullable<double> UnCoveredArea { get; set; }
        public Nullable<double> ResidentialArea { get; set; }
        public Nullable<double> NonResidentialArea { get; set; }
        public string? NA { get; set; }
        public string? PP { get; set; }
        public string? Mauza { get; set; }
        public string? UcName { get; set; }
        public string? UcNo { get; set; }
        public Nullable<double> Latitude { get; set; }
        public Nullable<double> Longitude { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> Created_Date { get; set; }
        public string? Created_By { get; set; }
        public string? Last_Modified_By { get; set; }
        public string? Users_Id { get; set; }
        public string? HfmisOldCode { get; set; }
    }
}
