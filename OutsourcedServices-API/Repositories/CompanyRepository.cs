using System;
using System.Data;
using System.Collections.Generic;
using Model;
using Repositories;

namespace Repositories
{
    public class CompanyRepository
    {
        private readonly GenericRepository _genericRepository;

        public CompanyRepository(GenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public Company CreateCompany(Company company)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Operation", "Create"},
                {"@Name", company.Name},
                {"@IsActive", company.IsActive},
            };

            var result = _genericRepository.ExecuteStoredProcedure("sp_Company_CRUD", parameters);
            company.Id = Convert.ToInt32(result.Rows[0]["Id"]);

            return company;
        }

        public Company GetCompany(int id)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Id", id}
            };

            var result = _genericRepository.ExecuteStoredProcedure("sp_Company_Get", parameters);

            if (result.Rows.Count == 0)
            {
                return null;
            }

            var row = result.Rows[0];
            return new Company
            {
                Id = Convert.ToInt32(row["Id"]),
                Name = row["Name"] as string,
                IsActive = row["IsActive"] as bool?,
                CreatedDate = row["CreatedDate"] as DateTime?,
            };
        }

        public Company GetCompanies(int pageIndex, int pageSize)
        {
          

            var result = _genericRepository.ExecuteStoredProcedure("sp_Company_Get", null);

            if (result.Rows.Count == 0)
            {
                return null;
            }

            var row = result.Rows[0];
            return new Company
            {
                Id = Convert.ToInt32(row["Id"]),
                Name = row["Name"] as string,
                IsActive = row["IsActive"] as bool?,
                CreatedDate = row["CreatedDate"] as DateTime?,
            };
        }
        public Company UpdateCompany(Company company)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Operation", "Update"},
                {"@Id", company.Id},
                {"@Name", company.Name},
                {"@IsActive", company.IsActive},
            };

            _genericRepository.ExecuteStoredProcedure("sp_Company_CRUD", parameters);

            return company;
        }

        public void DeleteCompany(int id)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Operation", "Delete"},
                {"@Id", id}
            };

            _genericRepository.ExecuteStoredProcedure("sp_Company_CRUD", parameters);
        }
    }
}
