using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NecklaceModels
{
    public enum PearlColor { Black, White, Pink }
    public enum PearlShape { Round, DropShaped }
    public enum PearlType { FreshWater, SaltWater }

    public class Pearl
    {
        public const decimal PearlBasePrice = 50M;
        public int PearlID { get; set; }
        public int Size { get; set; }
        public PearlColor Color { get; set; }
        public PearlShape Shape { get; set; }
        public PearlType Type { get; set; }
        public decimal Price
        {
            get
            {
                var price = Size * PearlBasePrice;
                if (Type == PearlType.SaltWater)
                    price *= 2;
                return price;
            }
        }

        public override string ToString() => $"{Size}mm {Color} {Shape} {Type} pearl. Price: {Price}";

    }
}
