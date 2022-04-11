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
        
        public override string ToString() => $"{NecklaceID}";
        //public override string ToString() => $"{NecklaceID} {Country} {NecklaceType}";




























        //        #region for EFC CodeFirst
        //        [Key]
        //        [Column("NecklaceID")]
        //public int NecklaceID { get; set; }







        //        public virtual List<Pearl> Pearls { get; set; } = new List<Pearl>();
        //        #endregion

        //        public Pearl this[int idx] => Pearls[idx];
        //        public decimal Price
        //        {
        //            get
        //            {
        //                //_stringOfPearls.Sum(x => x.Price);
        //                var price = 0M;
        //                foreach (var p in Pearls)
        //                {
        //                    price += p.Price;
        //                }
        //                return price;   
        //            }
        //        }

        //        public int Count() => Pearls.Count;    

        //        public int Count(PearlType type)
        //        {
        //            //_stringOfPearls.Where(o => o.Type == type).Count();
        //            int c = 0;
        //            foreach (var item in Pearls)
        //            {
        //                if (type == item.Type)  
        //                    c++;    
        //            }
        //           return c;
        //        }

        //        public override string ToString()
        //        {
        //            string sRet = $"Necklace has the following pearls:\n";
        //            foreach (var item in Pearls)
        //            {
        //                sRet += $"{item}\n";
        //            }
        //            return sRet;
        //        }


        //        public void Sort() => Pearls.Sort();
        //        public int IndexOf(Pearl pearl) => Pearls.IndexOf(pearl);

        //        public bool HasPearlSize(int size)
        //        {
        //            return Pearls.Find(x => x.Size == size) != null;
        //        }
        //        public Necklace FindAllOfSize(int size)
        //        {
        //            var n = new Necklace();
        //            n.Pearls = this.Pearls.FindAll(x => x.Size == size);

        //            return n;
        //        }

        //        #region Class Factory for creating an instance filled with Random data
        //        public static class Factory
        //        {
        //            public static Necklace CreateRandomNecklace(int NrOfItems)
        //            {
        //                var necklace = new Necklace();
        //                for (int i = 0; i < NrOfItems; i++)
        //                {
        //                    necklace.Pearls.Add(Pearl.Factory.CreateRandomPearl());
        //                }
        //                return necklace;    
        //            }
        //         }
        //        #endregion

        //        #region Methods for writing a neclace to disk
        //        public string Write(string filename)
        //        {
        //            string fn = fname(filename);
        //            using (FileStream fs = File.Create(fn))
        //            using (TextWriter writer = new StreamWriter(fs))
        //            {
        //                writer.WriteLine(this);
        //            }
        //            return fn;    
        //        }
        //        static string fname(string name)
        //        {
        //            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        //            documentPath = Path.Combine(documentPath, "ADOP", "Examples");
        //            if (!Directory.Exists(documentPath)) Directory.CreateDirectory(documentPath);
        //            return Path.Combine(documentPath, name);
        //        }
        //        #endregion
    }
}
