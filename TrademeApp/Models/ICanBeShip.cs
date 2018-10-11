using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrademeApp.Models
{
    public interface ICanBeShipped
    {
        int Length { get; set; }
        int Breadth { get; set; }
        int Height { get; set; }
        int Weight { get; set; }

        void SetShippingType<T>(IShipping<T> shipping) where T : ICanBeShipped;
    }
}
