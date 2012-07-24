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
        }
    }
}
