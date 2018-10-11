﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrademeApp.Models
{
    public class Specification<T> : ISpecification<T>
    {
        private readonly Func<T, bool> _expression;
        public Specification(Func<T, bool> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException();
            }

            else
            {
                this._expression = expression;
            }
                
        }

        public bool IsSatisfiedBy(T expression)
        {
            return this._expression(expression);
        }
    }
}
