using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_Forum_Film.Services.Class;
using Web_Api_Forum_Film.Services.Class.Dtos;
using Web_App_Forum_Film.Services.Classi;

namespace Web_App_Forum_Film.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public string Cerca { get; set; }

        public List<Topic> ListaCercata { get; set; }

        public bool Success = false;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void Redirecta()
        {
            RedirectToPage("/Pages/Crud/Index");
        }

        public async Task<IActionResult> OnGet()
        {
            var response = await MyApi.GetRandomTopics();
            if(response.Success)
            {
                ListaCercata = response.List;
                Success = true;
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (String.IsNullOrEmpty(Cerca))
                return Redirect("/Index");
            var resulttopics = await MyApi.GetTopicsFromName(Cerca.ToLower().Trim());
            bool z = false;
            if (resulttopics.Success)
            {
                var listatopics = resulttopics.List;
                ListaCercata = listatopics;
                z = true;
            }

            var resultfilms = await MyApi.GetFilmsFromName(Cerca);
            if (resultfilms.Success)
            {
                var listafilms = resultfilms.List;
                var resulttopics2 = await MyApi.GetTopicsFromFilms(new RequestGetFilms() { ListaFilm = listafilms });
                if(resulttopics2.Success)
                {
                    if (z)
                    {
                        ListaCercata.AddRange(resulttopics2.List);
                    }
                    else
                        ListaCercata = resulttopics2.List;
                    Success = true;
                }
                else
                {
                    if (!z)
                        return Page();
                    Success = true;
                }
            }
            ListaCercata = ListaCercata.GroupBy(t => t.Id).Select(t=>t.First()).ToList();
            return Page();
        }

         
}
}
