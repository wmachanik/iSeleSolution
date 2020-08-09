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
    public class IndexModel : PageModel
    {
        private readonly iSele.Services.ApplicationDbContext _context;

        public IndexModel(iSele.Services.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customers
                .Include(c => c.CustomerAccountingOptions)
                .Include(c => c.CustomerFulfilmentOptions)
                .Include(c => c.CustomerType).ToListAsync();
        }
    }
}
