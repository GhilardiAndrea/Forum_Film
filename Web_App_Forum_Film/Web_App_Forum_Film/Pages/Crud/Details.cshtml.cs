using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web_Api_Forum_Film.Services.Class;
using Web_Api_Forum_Film.Services.Class.Dtos;
using Web_App_Forum_Film.Areas.Identity;
using Web_App_Forum_Film.Data;
using Web_App_Forum_Film.Services.Classi;

namespace Web_App_Forum_Film.Pages.Crud
{
    public class DetailsModel : PageModel
    {
        private readonly MyIdentityDbContext _context;
        private readonly UserManager<MyUser> _userManager;

        public DetailsModel(MyIdentityDbContext context, UserManager<MyUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [BindProperty]
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
            if (response2.Success)
            {
                Posts = response2.List.ToList();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(string messaggio, int id)
        {
            if (String.IsNullOrEmpty(messaggio))
            {
                return Redirect($"/Crud/Details?id={Topic.Id}");
            }
                
            var utente = await _userManager.GetUserAsync(User);

            var response = await MyApi.PostMessaggio(new RequestMessaggio()
            {
                IdPost = id,
                EmailUser = utente.Email,
                Messaggio = messaggio
            });

            if (response.Success)
                return Redirect($"/Crud/Details?id={Topic.Id}");
            else
            {
                if (response.Errors[0] == "Parole non appropriate inserite")
                    return Redirect("/Crud/ParoleNonAppropriate");
                return Redirect("/Error");
            }
                
        }
    }
}
