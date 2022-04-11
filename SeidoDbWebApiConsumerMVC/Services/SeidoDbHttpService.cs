using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using NecklaceModels;

namespace SeidoDbWebApiConsumerMVC.Services
{
    public class SeidoDbHttpService : BaseHttpService, ISeidoDbHttpService
    {
        readonly Uri _baseUri;
        readonly IDictionary<string, string> _headers;

        public SeidoDbHttpService()
        {
            _baseUri = new Uri("https://localhost:44340");
            _headers = new Dictionary<string, string>();
            //https://localhost:44340/api/Necklace // Dit ska vi
        }

        public async Task<IEnumerable<Necklace>> GetNecklaces()
        {
            var url = new Uri(_baseUri, "/api/Necklace");
            var response = await SendRequestAsync<List<Necklace>>(url, HttpMethod.Get, _headers);
            return response;
        }
    }
}
