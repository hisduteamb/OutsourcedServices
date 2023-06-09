using Model;
using Repositories;
using System.Data;

namespace Repositories
{
    public class StaffRepository
    {
        private readonly GenericRepository _genericRepository;

        public StaffRepository(GenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public Staff CreateStaff(Staff staff)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Operation", "Create"},
                {"@Profile_Id", staff.Profile_Id},
                {"@Name", staff.Name},
                {"@FatherName", staff.FatherName},
                {"@CNIC", staff.CNIC},
                {"@Mobile", staff.Mobile},
                {"@Email", staff.Email},
                {"@Company_Id",staff.Company_Id },
                {"@Designation_Id", staff.Designation_Id},
                {"@HF_Id", staff.HF_Id},
                {"@Reporting_Id", staff.Reporting_Id},
                {"@IsActive", staff.IsActive},
                {"@CreatedBy", staff.CreatedBy},
                {"@User_Id", staff.User_Id}
            };

            var result = _genericRepository.ExecuteStoredProcedure("sp_Staff_CRUD", parameters);
            staff.Id = Convert.ToInt32(result.Rows[0]["Id"]);

            return staff;
        }

        public Staff GetStaff(int id)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Id", id}
            };

            var result = _genericRepository.ExecuteStoredProcedure("sp_Staff_Get", parameters);

            if (result.Rows.Count == 0)
            {
                return null;
            }

            var row = result.Rows[0];
            return new Staff
            {
                Id = Convert.ToInt32(row["Id"]),
                Profile_Id = row["Profile_Id"] as int?,
                Name = row["Name"] as string,
                FatherName = row["FatherName"] as string,
                CNIC = row["CNIC"] as string,
                Mobile = row["Mobile"] as string,
                Email = row["Email"] as string,
                Company_Id = row["Company_Id"] as int?,
                Designation_Id = row["Designation_Id"] as int?,
                HF_Id = row["HF_Id"] as int?,
                Reporting_Id = row["Reporting_Id"] as int?,
                IsActive = row["IsActive"] as bool?,
                CreatedDate = row["CreatedDate"] as DateTime?,
                CreatedBy = row["CreatedBy"] as string,
                User_Id = row["User_Id"] as string
            };
        }

        

        public List<Staff> GetStaffMethod(int pageIndex, int pageSize)
        {
            var dataTable = _genericRepository.ExecuteStoredProcedure("sp_Staff_Get", null);
            var result = new List<Staff>();
            foreach (DataRow row in dataTable.Rows)
            {
                result.Add(new Staff
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Profile_Id = row["Profile_Id"] as int?,
                    Name = row["Name"] as string,
                    FatherName = row["FatherName"] as string,
                    CNIC = row["CNIC"] as string,
                    Mobile = row["Mobile"] as string,
                    Email = row["Email"] as string,
                    Company_Id = row["Company_Id"] as int?,
                    Designation_Id = row["Designation_Id"] as int?,
                    HF_Id = row["HF_Id"] as int?,
                    Reporting_Id = row["Reporting_Id"] as int?,
                    IsActive = row["IsActive"] as bool?,
                    CreatedDate = row["CreatedDate"] as DateTime?,
                    CreatedBy = row["CreatedBy"] as string,
                    User_Id = row["User_Id"] as string

                });
            }

            return result;

        }

        public List<Staff> GetStaffList()
        {
            var dataTable = _genericRepository.ExecuteStoredProcedure("sp_Staff_Get", null);
            var result = new List<Staff>();
            foreach (DataRow row in dataTable.Rows)
            {
                result.Add(new Staff
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Profile_Id = row["Profile_Id"] as int?,
                    Name = row["Name"] as string,
                    FatherName = row["FatherName"] as string,
                    CNIC = row["CNIC"] as string,
                    Mobile = row["Mobile"] as string,
                    Email = row["Email"] as string,
                    Company_Id = row["Company_Id"] as int?,
                    Designation_Id = row["Designation_Id"] as int?,
                    HF_Id = row["HF_Id"] as int?,
                    Reporting_Id = row["Reporting_Id"] as int?,
                    IsActive = row["IsActive"] as bool?,
                    CreatedDate = row["CreatedDate"] as DateTime?,
                    CreatedBy = row["CreatedBy"] as string,
                    User_Id = row["User_Id"] as string,
                    DesignationName = row["DesignationName"] as string,
                    healthFacilityName = row["healthFacilityName"] as string,
                    CompanyName = row["CompanyName"] as string

                });
            }

            return result;

        }

        public Staff UpdateStaff(Staff staff)
        {
            var parameters = new Dictionary<string, object>
                {
                    {"@Operation", "Update"},
                    {"@Id", staff.Id},
                    {"@Profile_Id", staff.Profile_Id},
                    {"@Name", staff.Name},
                    {"@FatherName", staff.FatherName},
                    {"@CNIC", staff.CNIC},
                    {"@Mobile", staff.Mobile},
                    {"@Email", staff.Email},
                    {"@Company_Id",staff.Company_Id },
                    {"@Designation_Id", staff.Designation_Id},
                    {"@HF_Id", staff.HF_Id},
                    {"@Reporting_Id", staff.Reporting_Id},
                    {"@IsActive", staff.IsActive},
                    {"@CreatedBy", staff.CreatedBy},
                    {"@User_Id", staff.User_Id}
                };

            _genericRepository.ExecuteStoredProcedure("sp_Staff_CRUD", parameters);

            return staff;
        }

        public void DeleteStaff(int id)
        {
            var parameters = new Dictionary<string, object>
                {
                    {"@Operation", "Delete"},
                    {"@Id", id}
                };

            _genericRepository.ExecuteStoredProcedure("sp_Staff_CRUD", parameters);
        }

    }
}
