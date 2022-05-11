using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web_Api_Forum_Film.Services.Class;
using Web_Api_Forum_Film.Services.Class.Dtos;
using Web_App_Forum_Film.Data;
using Web_App_Forum_Film.Services.Classi;

namespace Web_App_Forum_Film.Pages.Crud
{
    public class CreateModel : PageModel
    {
        private readonly Web_App_Forum_Film.Data.MyIdentityDbContext _context;

        public List<Film> ListaFilm { get; set; }

        [BindProperty]
        public string Cerca { get; set; }

        public CreateModel(Web_App_Forum_Film.Data.MyIdentityDbContext context)
        {
            _context = context;
        }



        public async Task<IActionResult> OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Topic Topic { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostCrea()
        {
            var response = await MyApi.PostTopic(new RequestTopic
            {
                IdFilm = int.Parse(Topic.Film.Titolo_Originale.Split('-')[0].Trim()),
                Titolo = Topic.Titolo
            });
            if(response.Success)
                return RedirectToPage("/Index");
            else
            {
                if(response.Errors[0] == "Parole non appropriate inserite")
                    return Redirect("/Crud/ParoleNonAppropriate");
                return RedirectToPage("/Error");
            }
                
        }
        public async Task<IActionResult> OnPostCerca()
        {
            if (String.IsNullOrEmpty(Cerca))
                return Page();
            var response = await MyApi.GetFilmsFromName(Cerca.Trim().ToLower());
            if (response.Success)
                ListaFilm = response.List;
            return Page();
        }
    }
}
