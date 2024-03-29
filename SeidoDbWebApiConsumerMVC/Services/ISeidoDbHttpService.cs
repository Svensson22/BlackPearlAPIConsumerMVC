﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NecklaceModels;

namespace SeidoDbWebApiConsumerMVC.Services
{
    public interface ISeidoDbHttpService
    {
        Task<IEnumerable<Necklace>> GetNecklacesAsync();
        Task<Necklace> GetNecklaceAsync(int neckId);

        Task<Necklace> UpdateNecklaceAsync(Necklace neck);

        Task<Necklace> CreateNecklaceAsync(Necklace neck);
        Task<Necklace> DeleteNecklaceAsync(int neckId);
    }
}
