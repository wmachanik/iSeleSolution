using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using iSele.Models.Customers;
using iSele.Services;

namespace iSele.Web.FrontEnd.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly iSele.Services.ApplicationDbContext _context;

        public CreateModel(iSele.Services.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CustomerID"] = new SelectList(_context.CustomerAccountingOptions, "CustomerAccountingOptionsID", "VATTaxNum");
        ViewData["CustomerID"] = new SelectList(_context.CustomerFulfilmentOptions, "CustomerFulfilmentOptionsID", "CustomerFulfilmentOptionsID");
        ViewData["CustomerTypeID"] = new SelectList(_context.CustomerTypes, "CustomerTypeID", "CustomerTypeName");
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
