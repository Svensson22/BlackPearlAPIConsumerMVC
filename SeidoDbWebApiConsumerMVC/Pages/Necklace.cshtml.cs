using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NecklaceModels;
using SeidoDbWebApiConsumerMVC.Services;

namespace SeidoDbWebApiConsumerMVC.Pages
{
    public class NecklaceModel : PageModel
    {
        ISeidoDbHttpService _httpService;

        public IEnumerable<Necklace> Necklaces { get; set; }

        [BindProperty]
        public Necklace NewNecklaces { get; set; }

        public async Task OnGet() //public void OnGet() // Den gammla tomma utan async
        {
            Necklaces = await _httpService.GetNecklaces();
            Necklaces = Necklaces.OrderBy(c => c.NecklaceID).Take(10);
        }

        public NecklaceModel(ISeidoDbHttpService service)
        {
            this._httpService = service;
        }
    }
}
