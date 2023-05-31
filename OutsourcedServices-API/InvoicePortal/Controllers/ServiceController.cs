using Microsoft.AspNetCore.Mvc;
using Model;
using Repositories;
using YourNamespace.Services;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly ServiceRepository _serviceRepository;

        public ServiceController(ServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            var createdService = _serviceRepository.CreateService(service);
            return Ok(createdService);
        }

        [HttpGet("{id}")]
        public IActionResult GetService(int id)
        {
            var service = _serviceRepository.GetService(id);
            if (service == null)
            {
                return NotFound();
            }

            return Ok(service);
        }

        [HttpGet]
        public IActionResult GetPages([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10)
        {
            var pages = _serviceRepository.GetServiceMethod(pageIndex, pageSize);
            return Ok(pages);
        }

        [HttpPut]
        public IActionResult UpdateService(Service service)
        {
            var updatedService = _serviceRepository.UpdateService(service);
            return Ok(updatedService);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteService(int id)
        {
            _serviceRepository.DeleteService(id);
            return Ok();
        }
    }
}
