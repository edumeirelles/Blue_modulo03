﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaDeAula.Pages
{
    public class IndexModel : PageModel
    {
        public int num;
        
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            gerarAleatorio();
        }

        void gerarAleatorio()
        {
            Random rand = new ();
            num = rand.Next(0,100);
        }
    }
}
