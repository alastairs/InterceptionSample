using System;

namespace InterceptionSample.StaticInterception
{
    public class AccessControlCheckout : ICheckout
    {
        private readonly ICheckout checkout;
        private readonly IAccessControlPolicy policy;

        public AccessControlCheckout(ICheckout checkout, IAccessControlPolicy policy)
        {
            if (checkout == null)
            {
                throw new ArgumentNullException("checkout");
            }

            if (policy == null)
            {
                throw new ArgumentNullException("policy");
            }

            this.checkout = checkout;
            this.policy = policy;
        }

        public int GetTotal(string skus)
        {
            const string checkoutItems = "checkout";
            if (policy.AllowsUserTo(checkoutItems))
            {
                return checkout.GetTotal(skus);
            }

            throw new InvalidOperationException(string.Format("You are not allowed to perform the action {0}", checkoutItems));
        }
    }
}
