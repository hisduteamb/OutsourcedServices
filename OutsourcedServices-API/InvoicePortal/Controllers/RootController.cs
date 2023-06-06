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
            [Route("GetDivision")]
            public IActionResult GetDivision()
            {

                var createdStaff = _rootRepository.GetDivisions();
                return Ok(createdStaff);
            }


        [HttpGet("healthfacility/{id}")]
            public IActionResult GetHealthFacility(int id)
            {
                var result = _rootRepository.GetHealthFacility(id);
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
