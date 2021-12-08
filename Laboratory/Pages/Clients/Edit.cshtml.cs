using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Laboratory.Data;
using Laboratory.Models;

namespace Laboratory.Pages.Clients
{
    public class EditModel : PageModel
    {
        private readonly Laboratory.Data.LaboratoryContext _context;

        public EditModel(Laboratory.Data.LaboratoryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Client Client { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Client = await _context.Client.FindAsync(id);

            if (Client == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var clientToUpdate = await _context.Client.FindAsync(id);

            if (clientToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Client>(
                clientToUpdate,
                "clientToUpdate", 
                c => c.CompanyName, 
                c => c.Address, 
                c => c.ContactPerson, 
                c => c.PhoneNumber, 
                c => c.NIP, 
                c => c.Currency, 
                c => c.PaymentTerms))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool ClientExists(int id)
        {
            return _context.Client.Any(e => e.ClientID == id);
        }
    }
}
