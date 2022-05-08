using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web_Api_Forum_Film.Services.Class;
using Web_App_Forum_Film.Data;

namespace Web_App_Forum_Film.Pages.Crud
{
    public class DetailsModel : PageModel
    {
        private readonly Web_App_Forum_Film.Data.MyIdentityDbContext _context;

        public DetailsModel(Web_App_Forum_Film.Data.MyIdentityDbContext context)
        {
            _context = context;
        }

        public Topic Topic { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Topic = await _context.Topic.FirstOrDefaultAsync(m => m.Id == id);

            if (Topic == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
