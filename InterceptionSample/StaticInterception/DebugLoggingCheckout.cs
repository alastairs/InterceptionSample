using System;
using Ninject.Extensions.Logging;

namespace InterceptionSample.StaticInterception
{
    public class DebugLoggingCheckout : ICheckout
    {
        private readonly ICheckout checkout;
        private readonly ILogger logger;

        public DebugLoggingCheckout(ICheckout checkout, ILogger logger)
        {
            if (checkout == null)
            {
                throw new ArgumentNullException("checkout");
            }

            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }

            this.checkout = checkout;
            this.logger = logger;
        }

        public int GetTotal(string skus)
        {
            logger.Debug("Scanning {0} SKUs...", skus);

            var total = checkout.GetTotal(skus);

            logger.Debug("Total for items {0} is {1:C2}", skus, total);

            return total;
        }
    }
}
