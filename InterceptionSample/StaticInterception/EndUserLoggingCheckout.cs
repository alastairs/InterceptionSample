using System;
using Ninject.Extensions.Logging;

namespace InterceptionSample.StaticInterception
{
    public class EndUserLoggingCheckout : ICheckout
    {
        private readonly ICheckout checkout;
        private readonly ILogger logger;

        public EndUserLoggingCheckout(ICheckout checkout, ILogger logger)
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
            if (string.IsNullOrWhiteSpace(skus))
            {
                logger.Warn("Scanning no SKUs. Is this what you intended?");
            }

            try
            {
                return checkout.GetTotal(skus);
            }
            catch (InvalidOperationException ex)
            {
                logger.Warn(ex.Message);
                return 0; // In reality, we would re-throw the exception so it could be handled by a UI-level error handler.
            }
        }
    }
}
