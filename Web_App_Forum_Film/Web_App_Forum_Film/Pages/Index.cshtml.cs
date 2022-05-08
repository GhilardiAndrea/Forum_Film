using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_Forum_Film.Services.Class;
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
                return Page();
            var result = await MyApi.GetTopicsFromName(Cerca);
            if (result.Success)
            {
                ListaCercata = result.List;
                Success = true;
            }
            return Page();
        }

         
}
}
