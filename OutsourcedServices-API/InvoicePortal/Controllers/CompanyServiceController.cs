using Microsoft.AspNetCore.Mvc;
using Model;
using Repositories;
using YourNamespace.Services;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyServiceController : ControllerBase
    {
        private readonly CompanyServiceRepository _companyServiceRepository;

        public CompanyServiceController(CompanyServiceRepository companyServiceRepository)
        {
            _companyServiceRepository = companyServiceRepository;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] CompanyService companyService)
        {
            var createdCompanyService = _companyServiceRepository.CreateCompanyService(companyService);
            return Ok(createdCompanyService);
        }

        [HttpGet("{id}")]
        public IActionResult GetCompanyService(int id)
        {
            var companyService = _companyServiceRepository.GetCompanyService(id);
            if (companyService == null)
            {
                return NotFound();
            }

            return Ok(companyService);
        }

        [HttpGet]
        public IActionResult GetPages([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10)
        {
            var pages = _companyServiceRepository.GetCompaniesService(pageIndex, pageSize);
            return Ok(pages);
        }

        [HttpGet]
        [Route("GetCompanyService")]
        public IActionResult GetCompanyService()
        {
            var pages = _companyServiceRepository.GetCompanyService();
            return Ok(pages);
        }

        [HttpPut]
        public IActionResult UpdateCompanyService([FromBody] CompanyService companyService)
        {
            var updatedCompanyService = _companyServiceRepository.UpdateCompanyService(companyService);
            return Ok(updatedCompanyService);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCompanyService(int id)
        {
            _companyServiceRepository.DeleteCompanyService(id);
            return Ok();
        }
    }
}
