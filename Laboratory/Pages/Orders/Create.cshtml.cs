using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Laboratory.Data;
using Laboratory.Models;

namespace Laboratory.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly Laboratory.Data.LaboratoryContext _context;

        public CreateModel(Laboratory.Data.LaboratoryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClientID"] = new SelectList(_context.Client, "ClientID", "CompanyName");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyClient = new Client();

            if (await TryUpdateModelAsync<Client>(emptyClient, "Client", s => s.CompanyName))

            {
                _context.Client.Add(emptyClient);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();

            /*
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Order.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");*/
        }
    }
}
