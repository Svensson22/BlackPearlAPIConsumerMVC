﻿using System;
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
            //_baseUri = new Uri("http://localhost:5000");
            _headers = new Dictionary<string, string>();
        }

        public async Task<IEnumerable<Necklace>> GetNecklacesAsync()
        {
            var url = new Uri(_baseUri, "/api/necklace");
            var response = await SendRequestAsync<List<Necklace>>(url, HttpMethod.Get, _headers);

            return response;
        }

        public async Task<Necklace> GetNecklaceAsync(int neckId)
        {
            var url = new Uri(_baseUri, $"/api/necklace/{neckId}");
            var response = await SendRequestAsync<Necklace>(url, HttpMethod.Get, _headers);

            return response;
        }

        public async Task<Necklace> UpdateNecklaceAsync(Necklace neck)
        {
            var url = new Uri(_baseUri, $"/api/necklace/{neck.NecklaceID}");

            //Confirm necklace exisit in Database
            var neckToUpdate = await SendRequestAsync<Necklace>(url, HttpMethod.Get, _headers);
            if (neckToUpdate == null)
                return null;  //Necklace does not exist

            //Update Necklace, always gives null response, NonSuccess response errors are thrown
            await SendRequestAsync<Necklace>(url, HttpMethod.Put, _headers, neck);

            return neck;
        }

        public async Task<Necklace> CreateNecklaceAsync(Necklace neck)
        {
            var url = new Uri(_baseUri, "/api/necklace");
            var response = await SendRequestAsync<Necklace>(url, HttpMethod.Post, _headers, neck);

            return response;
        }

        public async Task<Necklace> DeleteNecklaceAsync(int neckId)
        {
            var url = new Uri(_baseUri, $"/api/necklace/{neckId}");

            //Confirm necklace exisit in Database
            var neckToDel = await SendRequestAsync<Necklace>(url, HttpMethod.Get, _headers);
            if (neckToDel == null)
                return null;  //Necklace does not exist

            //Delete Necklace, always gives null response, NonSuccess response errors are thrown
            await SendRequestAsync<Necklace>(url, HttpMethod.Delete, _headers);
            return neckToDel;
        }
    }
}
