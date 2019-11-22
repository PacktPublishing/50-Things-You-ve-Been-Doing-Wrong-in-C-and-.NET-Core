using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Validation.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        [Required]
        [MinLength(6)]
        public string UserName { get; set; }

        [BindProperty]
        [Required, MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        [BindProperty] 
        [Required/*, Compare(nameof(Password) )*/]
        public string Password2 { get; set; }
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult  OnPost()
        {
            if (ModelState.IsValid)
            //if(true)
            {
                // do something
                return RedirectToPage("Privacy");
            }
            else
            {
                return Page();
            }
        }

        public void OnGet()
        {

        }
    }
}
