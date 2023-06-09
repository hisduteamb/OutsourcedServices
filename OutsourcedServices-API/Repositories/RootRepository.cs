using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RootRepository
    {
        private readonly GenericRepository _genericRepository;

        public RootRepository(GenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public HrDesignation? GetDesignation(int id)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Id", id}
            };

            var result = _genericRepository.ExecuteStoredProcedure("sp_Designation_Get", parameters);

            if (result.Rows.Count == 0)
            {
                return null;
            }

            var row = result.Rows[0];
            return new HrDesignation
            {
                Id = Convert.ToInt32(row["Id"]),
                Name = row["Name"] as string
            };

        }
        public List<HrDesignation> GetDesignations()
        {
            var dataTable = _genericRepository.ExecuteStoredProcedure("sp_Designation_Get", null);
            var result = new List<HrDesignation>();
            foreach (DataRow row in dataTable.Rows)
            {
                result.Add(new HrDesignation
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"] as string
                });
            }

            return result;
        }

        public List<Company> GetCompany()
        {
            var dataTable = _genericRepository.ExecuteStoredProcedure("sp_Company_Get", null);
            var result = new List<Company>();
            foreach (DataRow row in dataTable.Rows)
            {
                result.Add(new Company
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"] as string,
                    IsActive = row["IsActive"] as bool?,
                    CreatedDate = row["CreatedDate"] as DateTime?,

                });
            }

            return result;
        }

        public List<Division> GetDivisions(string code)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Code", code}
            };
            var dataTable = _genericRepository.ExecuteStoredProcedure("sp_Division_Get", parameters);
            var result = new List<Division>();
            foreach (DataRow row in dataTable.Rows)
            {
                result.Add(new Division
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"] as string,
                    Code=row["Code"] as string
                });
            }

            return result;
        }

        public List<District> GetDistricts(string code)
        {
            var parameters = new Dictionary<string, object>
            {
                 {"@Code", code}
            };
            var dataTable = _genericRepository.ExecuteStoredProcedure("sp_District_Get", parameters);
            var result = new List<District>();
            foreach (DataRow row in dataTable.Rows)
            {
                result.Add(new District
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"] as string,
                    Code = row["Code"] as string
                });
            }

            return result;
        }

        public List<Tehsil> GetTehsils(string code)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@Code" , code }
            };
            var dataTable = _genericRepository.ExecuteStoredProcedure("sp_Tehsil_Get", parameters);
            var result = new List<Tehsil>();
            foreach (DataRow row in dataTable.Rows)
            {
                result.Add(new Tehsil
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"] as string,
                    Code = row["Code"] as string
                });
            }

            return result;
        }

        public List<HFListP> GetHealthFacility(string code)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Code", code}
            };

            var dataTable = _genericRepository.ExecuteStoredProcedure("sp_HealthFacility_Get", parameters);
            var result = new List<HFListP>();
            foreach (DataRow row in dataTable.Rows)
            {
                result.Add(new HFListP
                {
                    Id = Convert.ToInt32(row["Id"]),
                    FullName = row["FullName"] as string,
                    HFMISCode = row["HFMISCode"] as string
                });
            }

            return result;
          
            
        }

        public Division? GetDivision(int id)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Id", id}
            };

            var result = _genericRepository.ExecuteStoredProcedure("sp_Division_Get", parameters);

            if (result.Rows.Count == 0)
            {
                return null;
            }

            var row = result.Rows[0];
            return new Division
            {
                Id = Convert.ToInt32(row["Id"]),
                Name = row["Name"] as string
            };
        }

        public District? GetDistrict(int id)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Id", id}
            };

            var result = _genericRepository.ExecuteStoredProcedure("sp_District_Get", parameters);

            if (result.Rows.Count == 0)
            {
                return null;
            }

            var row = result.Rows[0];
            return new District
            {
                Id = Convert.ToInt32(row["Id"]),
                Name = row["Name"] as string
            };
        }
        public Tehsil? GetTehsil(int id)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Id", id}
            };

            var result = _genericRepository.ExecuteStoredProcedure("sp_Tehsil_Get", parameters);

            if (result.Rows.Count == 0)
            {
                return null;
            }

            var row = result.Rows[0];
            return new Tehsil
            {
                Id = Convert.ToInt32(row["Id"]),
                Name = row["Name"] as string
            };
        }
    }
}
