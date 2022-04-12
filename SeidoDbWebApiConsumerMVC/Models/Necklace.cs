using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NecklaceModels;

namespace NecklaceModels
{
    public class Necklace
    {
        public int NecklaceID { get; set; }
        public string Country { get; set; }
        public string NecklaceType { get; set; }

        public override string ToString() => $"{NecklaceID} {Country} {NecklaceType}";
    }
}