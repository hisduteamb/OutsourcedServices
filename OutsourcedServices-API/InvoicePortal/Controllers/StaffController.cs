using Microsoft.AspNetCore.Mvc;
using Model;
using Repositories;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly StaffRepository _staffRepository;

        public StaffController(StaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Staff staff)
        {
            var createdStaff = _staffRepository.CreateStaff(staff);
            return Ok(createdStaff);
        }

        

        [HttpGet("{id}")]
        public IActionResult GetStaff(int id)
        {
            var staff = _staffRepository.GetStaff(id);
            if (staff == null)
            {
                return NotFound();
            }

            return Ok(staff);
        }

        [HttpGet]
        public IActionResult GetPages([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10)
        {
            var pages = _staffRepository.GetStaffMethod(pageIndex, pageSize);
            return Ok(pages);
        }

        [HttpPut]
        public IActionResult UpdateStaff(Staff staff)
        {
            var updatedStaff = _staffRepository.UpdateStaff(staff);
            return Ok(updatedStaff);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStaff(int id)
        {
            _staffRepository.DeleteStaff(id);
            return Ok();
        }
    }
}
