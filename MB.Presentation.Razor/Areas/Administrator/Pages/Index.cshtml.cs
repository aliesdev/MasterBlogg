﻿using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.Razor.Areas.Administrator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}