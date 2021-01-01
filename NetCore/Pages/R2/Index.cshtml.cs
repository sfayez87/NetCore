using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NetCore.Core;
using NetCore.Data;

namespace NetCore.Pages.R2
{
    public class IndexModel : PageModel
    {
        private readonly NetCore.Data.RestaurantsDbContext _context;

        public IndexModel(NetCore.Data.RestaurantsDbContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants.ToListAsync();
        }
    }
}
