using System;
using System.Data;
using System.Collections.Generic;
using Model;
using Repositories;

namespace Repositories
{
    public class ServiceRepository
    {
        private readonly GenericRepository _genericRepository;

        public ServiceRepository(GenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public Service CreateService(Service service)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Operation", "Create"},
                {"@Name", service.Name},
                {"@IsActive", service.IsActive},
            };

            var result = _genericRepository.ExecuteStoredProcedure("sp_Service_CRUD", parameters);
            service.Id = Convert.ToInt32(result.Rows[0]["Id"]);

            return service;
        }

        public Service GetService(int id)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Id", id}
            };

            var result = _genericRepository.ExecuteStoredProcedure("sp_Service_Get", parameters);

            if (result.Rows.Count == 0)
            {
                return null;
            }

            var row = result.Rows[0];
            return new Service
            {
                Id = Convert.ToInt32(row["Id"]),
                Name = row["Name"] as string,
                IsActive = row["IsActive"] as bool?,
                CreatedDate = row["CreatedDate"] as DateTime?,
            };
        }


        public Service GetServiceMethod(int pageIndex, int pageSize)
        {
            

            var result = _genericRepository.ExecuteStoredProcedure("sp_Service_Get", null);

            if (result.Rows.Count == 0)
            {
                return null;
            }

            var row = result.Rows[0];
            return new Service
            {
                Id = Convert.ToInt32(row["Id"]),
                Name = row["Name"] as string,
                IsActive = row["IsActive"] as bool?,
                CreatedDate = row["CreatedDate"] as DateTime?,
            };
        }

        public Service UpdateService(Service service)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Operation", "Update"},
                {"@Id", service.Id},
                {"@Name", service.Name},
                {"@IsActive", service.IsActive},
            };

            _genericRepository.ExecuteStoredProcedure("sp_Service_CRUD", parameters);

            return service;
        }

        public void DeleteService(int id)
        {
            var parameters = new Dictionary<string, object>
            {
                {"@Operation", "Delete"},
                {"@Id", id}
            };

            _genericRepository.ExecuteStoredProcedure("sp_Service_CRUD", parameters);
        }
    }
}
