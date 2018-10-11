using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrademeApp.Models
{
    public class Package : ICanBeShipped
    {

        public int Length { get; set; }
        public int Breadth { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public IShipping<Package> Shipping { get; set; }


        public Package(int length, int breadth, int height, int weight)
        {
            this.Length = length;
            this.Breadth = breadth;
            this.Height = height;
            this.Weight = weight;

        }

        public void SetShippingType<T>(IShipping<T> shipping) where T : ICanBeShipped => this.Shipping = (IShipping<Package>)shipping;
    }
}
