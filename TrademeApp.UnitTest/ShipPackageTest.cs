using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrademeApp.Models;

namespace TrademeApp.UnitTest
{
    [TestClass]
    public class ShipPackageTest
    {
        [TestMethod]
        public void ShipPackage_ExpectedMedium()
        {
            string expectedAnswer = "Medium";
            double expectedCost = 7.5;

            var package = new Package(200,200,200,20);
            var mediumSpec = new Specification<Package>(x => x.Length <= 300 && x.Breadth <= 400 && x.Height <= 200);
            var medium = new Shipping<Package>("Medium", 7.5);
            medium.SetSpecification(mediumSpec);

            medium.ProcessShipping(ref package);

            Assert.Equals(package.Shipping.Name, expectedAnswer);
            Assert.Equals(package.Shipping.Price, expectedCost);
        }
    }
}
