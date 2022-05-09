using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web_Api_Forum_Film.Services.Class;
using Web_App_Forum_Film.Data;
using Web_App_Forum_Film.Services.Classi;

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

        public List<ForumPost> Posts { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await MyApi.GetTopic(int.Parse(id.ToString()));
            if (response.Success)
            {
                Topic = response.List[0];
            }
            else
            {
                return NotFound();
            }
            
            var response2 = await MyApi.GetAllPostsInTopic(int.Parse(id.ToString()));
            if (response.Success)
            {
                Posts = response2.List.ToList();
            }
            return Page();
        }
    }
}
