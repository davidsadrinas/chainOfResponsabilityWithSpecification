using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrademeApp.Models
{
    public class Shipping<T> : IShipping<T> where T : ICanBeShipped
    {
        private IShipping<T> _successor;
        private ISpecification<T> _specification;
        private readonly string _name;
        private readonly double _price;
        public Action<T> _shippingAction;

        public Shipping(String name, Double price)
        {
            _name = name;
            _price = price;
        }

        public string Name 
        {
            get { return _name; }
        }

        public double Price
        {
            get { return _price; }
        }

        public bool CanShip(T package)
        {
            if (_specification != null && package != null)
            {
                return _specification.IsSatisfiedBy(package);
            }
            return false;
        }
        public void ProcessShipping(ref T package)
        {
            if (CanShip(package))
            {
                package.SetShippingType(this);
            }
            else
            {
                _successor?.ProcessShipping(ref package);
            }
        }

        public void SetSpecification(ISpecification<T> specification)
        {
            _specification = specification;
        }

        public void SetSuccessor(IShipping<T> shipping)
        {
            _successor = shipping;
        }
    }
}
