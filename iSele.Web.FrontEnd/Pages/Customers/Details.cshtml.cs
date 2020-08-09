using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using iSele.Models.Customers;
using iSele.Services;

namespace iSele.Web.FrontEnd.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly iSele.Services.ApplicationDbContext _context;

        public DetailsModel(iSele.Services.ApplicationDbContext context)
        {
            _context = context;
        }

        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customers
                .Include(c => c.CustomerAccountingOptions)
                .Include(c => c.CustomerFulfilmentOptions)
                .Include(c => c.CustomerType).FirstOrDefaultAsync(m => m.CustomerID == id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
