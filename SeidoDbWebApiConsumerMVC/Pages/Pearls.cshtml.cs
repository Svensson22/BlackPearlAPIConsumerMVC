using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NecklaceModels;
using SeidoDbWebApiConsumerMVC.Services;

namespace SeidoDbWebApiConsumerMVC.Pages
{
    public class PearlsModel : PageModel
    {
        ISeidoDbHttpService _httpService;

        public Necklace Necklace;
        public IEnumerable<Pearl> Pearls { get; private set; }

        public async Task OnGet(string id)
        {
            int.TryParse(id, out int necklaceId);
            Necklace = await _httpService.GetNecklaceAsync(necklaceId);
            Pearls = Necklace.Pearls.ToList();
        }

        public PearlsModel(ISeidoDbHttpService service)
        {
            this._httpService = service;
        }
    }
}
