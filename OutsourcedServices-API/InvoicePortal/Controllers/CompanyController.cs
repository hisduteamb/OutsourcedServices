using Microsoft.AspNetCore.Mvc;
using Repositories;
using Model;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyRepository _companyRepository;

        public CompanyController(CompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpPost]
        [Route("Create")]

        public IActionResult Create([FromBody] Company company)
        {
            var createdCompany = _companyRepository.CreateCompany(company);
            return Ok(createdCompany);
        }

        [HttpGet("{id}")]
        public IActionResult GetCompany(int id)
        {
            var company = _companyRepository.GetCompany(id);
            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        [HttpGet]
        public IActionResult GetPages([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10)
        {
            var pages = _companyRepository.GetCompanies(pageIndex, pageSize);
            return Ok(pages);
        }

        [HttpPut]
        public IActionResult UpdateCompany([FromBody] Company company)
        {
            var updatedCompany = _companyRepository.UpdateCompany(company);
            return Ok(updatedCompany);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCompany(int id)
        {
            _companyRepository.DeleteCompany(id);
            return Ok();
        }
    }
}

