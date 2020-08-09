using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iSele.Models;
using iSele.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iSele.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClosureDatesController : ControllerBase
    {
        private readonly IFancyGenericRepository<ClosureDate> _ClosureDatesRepository;
        public ClosureDatesController(IFancyGenericRepository<ClosureDate> ClosureDatesRepository)
        {
            _ClosureDatesRepository = ClosureDatesRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetClosureDates()
        {
            try
            {
                return Ok(await _ClosureDatesRepository.GetAllAsync());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}
