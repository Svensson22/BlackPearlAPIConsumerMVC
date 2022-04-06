using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SeidoDbWebApiConsumerMVC.Models;

namespace SeidoDbWebApiConsumerMVC.Services
{
    public class SeidoDbHttpService : BaseHttpService, ISeidoDbHttpService
    {
        readonly Uri _baseUri;
        readonly IDictionary<string, string> _headers;

        public SeidoDbHttpService()
        {
            _baseUri = new Uri("https://localhost:5001");
            //_baseUri = new Uri("http://localhost:5000");
            _headers = new Dictionary<string, string>();
        }

        public async Task<IEnumerable<ICustomer>> GetCustomersAsync()
        {
            var url = new Uri(_baseUri, "/api/customers");
            var response = await SendRequestAsync<List<Customer>>(url, HttpMethod.Get, _headers);

            return response;
        }

        public async Task<ICustomer> GetCustomerAsync(Guid custId)
        {
            var url = new Uri(_baseUri, $"/api/customers/{custId}");
            var response = await SendRequestAsync<Customer>(url, HttpMethod.Get, _headers);

            return response;
        }

        public async Task<ICustomer> UpdateCustomerAsync(Customer cus)
        {
            var url = new Uri(_baseUri, $"/api/customers/{cus.CustomerID}");

            //Confirm customer exisit in Database
            var cusToUpdate = await SendRequestAsync<Customer>(url, HttpMethod.Get, _headers);
            if (cusToUpdate == null)
                return null;  //Customer does not exist

            //Update Customer, always gives null response, NonSuccess response errors are thrown
            await SendRequestAsync<Customer>(url, HttpMethod.Put, _headers, cus);

            return cus;
        }

        public async Task<ICustomer> CreateCustomerAsync(Customer cus)
        {
            var url = new Uri(_baseUri, "/api/customers");
            var response = await SendRequestAsync<Customer>(url, HttpMethod.Post, _headers, cus);

            return response;
        }

        public async Task<ICustomer> DeleteCustomerAsync(Guid custId)
        {
            var url = new Uri(_baseUri, $"/api/customers/{custId}");

            //Confirm customer exisit in Database
            var cusToDel = await SendRequestAsync<Customer>(url, HttpMethod.Get, _headers);
            if (cusToDel == null)
                return null;  //Customer does not exist

            //Delete Customer, always gives null response, NonSuccess response errors are thrown
            await SendRequestAsync<Customer>(url, HttpMethod.Delete, _headers);
            return cusToDel;
        }
    }
}
