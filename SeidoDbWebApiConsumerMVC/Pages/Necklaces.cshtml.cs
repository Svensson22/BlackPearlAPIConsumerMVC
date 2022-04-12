using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NecklaceModels;
using SeidoDbWebApiConsumerMVC.Services;

namespace SeidoDbWebApiConsumerMVC.Pages
{
    public class NecklacesModel : PageModel
    {
        ISeidoDbHttpService _httpService;

        public IEnumerable<Necklace> Necklaces { get; private set; }

        public Necklace NewNecklace { get; set; }

        public async Task OnGet()
        {
            Necklaces = await _httpService.GetNecklacesAsync();
            Necklaces = Necklaces.Take(10);
        }

        public async Task<IActionResult> OnPostDelete(string id)
        {

            int.TryParse(id, out int NeckID);
            await _httpService.DeleteNecklaceAsync(NeckID);

            return RedirectToPage("/necklaces");
        }

       public NecklacesModel(ISeidoDbHttpService service)
        {
            this._httpService = service;
        }
    }
}
