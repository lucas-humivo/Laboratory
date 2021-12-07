using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Laboratory.Data;
using Laboratory.Models;

namespace Laboratory.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly Laboratory.Data.LaboratoryContext _context;

        public IndexModel(Laboratory.Data.LaboratoryContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync()
        {
            Order = await _context.Order
                .Include(o => o.Client).ToListAsync();
        }
    }
}
