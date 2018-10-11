using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrademeApp.Models
{
    public interface ISpecification<in T>
    {
        bool IsSatisfiedBy(T expression);
    }
}
