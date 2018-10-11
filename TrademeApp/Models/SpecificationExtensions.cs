using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrademeApp.Models
{
   public static class SpecificationExtensions
    {
        public static Specification<T> AND<T>(this ISpecification<T> a, ISpecification<T> b)
        {
            if (a != null && b != null)
            {
                // Check if both a AND b satisfy expression.
                return new Specification<T>(expression => a.IsSatisfiedBy(expression) && b.IsSatisfiedBy(expression));
            }
            return null;
        }
        public static Specification<T> OR<T>(this ISpecification<T> a, ISpecification<T> b)
        {
            if (a != null && b != null)
            {
                // Check if either a OR b satisfy expression.
                return new Specification<T>(expression => a.IsSatisfiedBy(expression) || b.IsSatisfiedBy(expression));
            }
            return null;
        }
        public static Specification<T> NOT<T>(this ISpecification<T> a)
        {
            // Check .
            return a != null ? new Specification<T>(expression => !a.IsSatisfiedBy(expression)) : null;
        }
    }
}
