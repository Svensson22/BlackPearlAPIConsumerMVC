using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NecklaceModels;

namespace SeidoDbWebApiConsumerMVC.Services
{
    public interface ISeidoDbHttpService
    {
        Task<IEnumerable<Necklace>> GetNecklaces();
    }
}
