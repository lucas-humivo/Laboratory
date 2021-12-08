using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Laboratory.Data;
using Laboratory.Models;

namespace Laboratory.Pages.Clients
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
            return Page();
        }

        [BindProperty]
        public Client Client { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyClient = new Client();

            if (await TryUpdateModelAsync<Client>(
                emptyClient,
                "student",   // Prefix for form value.
                s => s.CompanyName, s => s.Address, s => s.ContactPerson, s => s.PhoneNumber, s => s.NIP, s => s.Currency, s => s.PaymentTerms))
            {
                _context.Client.Add(emptyClient);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
