using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Repositories;

namespace InvoicePortal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class RootController : ControllerBase
    {
        
            private readonly RootRepository _rootRepository;


           public RootController(RootRepository rootRepository)
           {
                _rootRepository = rootRepository;
           }

       

            [HttpGet("designation/{id}")]
            public IActionResult GetDesignation(int id)
            {
                var result = _rootRepository.GetDesignation(id);
                if (result != null)
                    return Ok(result);

                return NotFound();
            }

            [HttpGet]
            [Route("GetDesignation")]
            public IActionResult GetDesignation()
            {
                
                var createdStaff = _rootRepository.GetDesignations();
                return Ok(createdStaff);
            }


            [HttpGet]
            [Route("GetCompanies")]
            public IActionResult GetCompanies()
            {

                var createdStaff = _rootRepository.GetCompany();
                return Ok(createdStaff);
            }

        [HttpGet]
            [Route("GetDivision/{code}")]
            public IActionResult GetDivision(string code)
            {

                var createdStaff = _rootRepository.GetDivisions(code);
                return Ok(createdStaff);
            }

            [HttpGet]
            [Route("GetDistrict/{code}")]
            public IActionResult GetDistrict(string code)
            {

                var createdStaff = _rootRepository.GetDistricts(code);
                return Ok(createdStaff);
            }

            [HttpGet]
            [Route("GetTehsil/{code}")]
            public IActionResult GetTehsil(string code)
            {

                var createdStaff = _rootRepository.GetTehsils(code);
                return Ok(createdStaff);
            }

            [HttpGet("healthfacility/{code}")]
            public IActionResult GetHealthFacility(string code)
            {
                var result = _rootRepository.GetHealthFacility(code);
                if (result != null)
                    return Ok(result);

                return NotFound();
            }

            [HttpGet("division/{id}")]
            public IActionResult GetDivision(int id)
            {
                var result = _rootRepository.GetDivision(id);
                if (result != null)
                    return Ok(result);

                return NotFound();
            }

            [HttpGet("district/{id}")]
            public IActionResult GetDistrict(int id)
            {
                var result = _rootRepository.GetDistrict(id);
                if (result != null)
                    return Ok(result);

                return NotFound();
            }

            [HttpGet("tehsil/{id}")]
            public IActionResult GetTehsil(int id)
            {
                var result = _rootRepository.GetTehsil(id);
                if (result != null)
                    return Ok(result);

                return NotFound();
            }

            // Define your action methods here
        
    }
}
