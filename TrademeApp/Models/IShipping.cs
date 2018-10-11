using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrademeApp.Models
{
    public interface IShipping<T>
    {
        void ProcessShipping(ref T package);
        void SetSpecification(ISpecification<T> specification);
        void SetSuccessor(IShipping<T> shipping);

        string Name { get; }
        double Price { get; }
    }
}
