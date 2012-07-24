using NUnit.Framework;

namespace InterceptionSample.Tests
{
    public class CheckoutFacts
    {
        [TestFixture, Category("Acceptance Tests")]
        public class GetTotalShould
        {
            [Test]
            public void Return0WhenNoItemIsScanned()
            {
                var checkout = new Checkout();

                var scannedItemPrice = checkout.GetTotal(string.Empty);

                Assert.That(scannedItemPrice, Is.EqualTo(0));
            }

            [TestCase("A", 50)]
            [TestCase("B", 30)]
            [TestCase("C", 20)]
            [TestCase("D", 15)]
            public void ReturnTheItemPriceWhenASingleItemIsScannedOnce(string sku, int price)
            {
                var checkout = new Checkout();

                var scannedItemPrice = checkout.GetTotal(sku);

                Assert.That(scannedItemPrice, Is.EqualTo(price));
            }
        }
    }
}
