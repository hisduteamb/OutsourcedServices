using System;
using System.Data;
using System.Collections.Generic;
using Model;
using Repositories;

namespace YourNamespace.Services
{
    public class CompanyServiceRepository
    {
        private readonly GenericRepository _genericRepository;

        public CompanyServiceRepository(GenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public CompanyService CreateCompanyService(CompanyService companyService)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Operation", "Create"},
                {"@Service_Id", companyService.Service_Id},
                {"@Company_Id", companyService.Company_Id},
            };

            var result = _genericRepository.ExecuteStoredProcedure("sp_CompanyService_CRUD", parameters);
            companyService.Id = Convert.ToInt32(result.Rows[0]["Id"]);

            return companyService;
        }

        public CompanyService GetCompanyService(int id)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Id", id}
            };

            var result = _genericRepository.ExecuteStoredProcedure("sp_CompanyService_Get", parameters);

            if (result.Rows.Count == 0)
            {
                return null;
            }

            var row = result.Rows[0];
            return new CompanyService
            {
                Id = Convert.ToInt32(row["Id"]),
                Service_Id = row["Service_Id"] as int?,
                Company_Id = row["Company_Id"] as int?,
            };
        }

        public CompanyService GetCompaniesService(int pageIndex, int pageSize)
        {
            

            var result = _genericRepository.ExecuteStoredProcedure("sp_CompanyService_Get", null);

            if (result.Rows.Count == 0)
            {
                return null;
            }

            var row = result.Rows[0];
            return new CompanyService
            {
                Id = Convert.ToInt32(row["Id"]),
                Service_Id = row["Service_Id"] as int?,
                Company_Id = row["Company_Id"] as int?,
            };
        }
        public CompanyService UpdateCompanyService(CompanyService companyService)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Operation", "Update"},
                {"@Id", companyService.Id},
                {"@Service_Id", companyService.Service_Id},
                {"@Company_Id", companyService.Company_Id},
            };

            _genericRepository.ExecuteStoredProcedure("sp_CompanyService_CRUD", parameters);

            return companyService;
        }

        public void DeleteCompanyService(int id)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Operation", "Delete"},
                {"@Id", id}
            };

            _genericRepository.ExecuteStoredProcedure("sp_CompanyService_CRUD", parameters);
        }
    }
}
