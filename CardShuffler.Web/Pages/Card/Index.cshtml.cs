using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardShuffler.Web.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CardShuffler.Web.Pages.Card
{
    public class IndexModel : PageModel
    {
        private ICardService _service { get; set; }
        public IndexModel(ICardService service) {
            _service = service;
        }

        [BindProperty]
        public IList<int> CardList { get; set; }

        public async Task OnGet()
        {           
            CardList = await _service.GetShuffledCards();
        }

    
        
    }
}