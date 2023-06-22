using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using YourNamespace.Models;
using Model;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceRepository _invoiceRepository;

        public InvoiceController(InvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] InvoiceViewModel invoice)
        {
             _invoiceRepository.SaveInvoice(invoice);
            return Ok(true);
        }

        
    }
}