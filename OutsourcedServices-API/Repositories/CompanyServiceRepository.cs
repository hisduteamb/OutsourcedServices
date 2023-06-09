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
        private readonly ServiceRepository _serviceRepository;

        public CompanyServiceRepository(GenericRepository genericRepository, ServiceRepository serviceRepository)
        {
            _genericRepository = genericRepository;
            _serviceRepository = serviceRepository;
        }

        public CompanyService CreateCompanyService(CompanyService companyService)
        {
            Service service = new Service() { Name = companyService.ServiceName };
            service = _serviceRepository.CreateService(service);

            var parameters = new Dictionary<string, object>
            {
                {"@Operation", "Create"},
                {"@Service_Id", service.Id},
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
        public List<CompanyService> GetCompanyService()
        {
            var dataTable = _genericRepository.ExecuteStoredProcedure("sp_CompanyService_Get", null);
            var result = new List<CompanyService>();
            foreach (DataRow row in dataTable.Rows)
            {
                result.Add(new CompanyService
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Service_Id = row["Service_Id"] as int?,
                    Company_Id = row["Company_Id"] as int?,
                    ServiceName = row["ServiceName"] as string,
                    companyName = row["companyName"] as string,
                    serviceStatus = row["serviceStatus"] as bool?,
                    companyStatus = row["companyStatus"] as bool?

                });
            }

            return result;

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
