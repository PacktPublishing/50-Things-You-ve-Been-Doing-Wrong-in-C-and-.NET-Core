using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace SampleWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        static int x;

        public IndexModel(ILogger<IndexModel> logger)
        {
            x++;
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
