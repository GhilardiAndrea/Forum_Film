using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web_Api_Forum_Film.Services.Class;
using Web_Api_Forum_Film.Services.Class.Dtos;
using Web_App_Forum_Film.Areas.Identity;
using Web_App_Forum_Film.Data;
using Web_App_Forum_Film.Services.Classi;

namespace Web_App_Forum_Film.Pages.Crud
{
    public class CreaPostModel : PageModel
    {

        public CreaPostModel(MyIdentityDbContext context, UserManager<MyUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private readonly UserManager<MyUser> _userManager;
        private readonly MyIdentityDbContext _context;

        [BindProperty]
        public Topic Topic { get; set; }

        public ForumPost Post { get; set; }

        [BindProperty]
        public string Messaggio { get; set; }

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
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var utente = await _userManager.GetUserAsync(User);
            var response = await MyApi.PostPost(new RequestPost()
            {
                IdTopic = Topic.Id,
                EmailUser = utente.Email,
                Message = Messaggio

            });

            if (response.Success)
                return Redirect($"/Crud/Details?id={Topic.Id}");
            else
                return Redirect("/Error");
        }

    }
}
