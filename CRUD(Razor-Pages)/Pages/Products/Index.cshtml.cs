using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRUD_Razor_Pages_;

namespace CRUD_Razor_Pages_.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly CRUD_Razor_Pages_.NorthwindContext _context;

        public IndexModel(CRUD_Razor_Pages_.NorthwindContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier).ToListAsync();
        }
    }
}
