using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iSele.Models.Customers;
using iSele.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iSele.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IFancyGenericRepository<Customer> _CustomerRepository; 
        public CustomerController(IFancyGenericRepository<Customer> CustomerRepository)
        {
            _CustomerRepository = CustomerRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                return Ok(await _CustomerRepository.GetAllAsync());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}
