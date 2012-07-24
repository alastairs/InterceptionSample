using Ninject.Modules;

namespace InterceptionSample.StaticInterception.Modules
{
    public class CheckoutModule : NinjectModule
    {
        public override void Load()
        {
            // In the below comment and code block: 
            //   A -> B means "A wraps B", or "B is injected into A".
            //   [A] indicates an optional part of the chain.
            // I.e., B is the Decorator, and A is the wrapped implementation.
            // 
            // For A -> B, we write Kernel.Bind<Interface>().To<B>().WhenInjectedInto<A>().InThreadScope();

            
            // Assembly of this application is:
            // DebugLoggingCheckout -> EndUserLoggingCheckout -> [AccessControlCheckout] -> Checkout

            // We want to apply access control as close to the implementation as possible to ensure nothing slips through.
            if (Program.IsAccessControlEnabled)
            {
                // AccessControlCheckout -> Checkout
                Kernel.Bind<ICheckout>().To<Checkout>().WhenInjectedInto<AccessControlCheckout>().InThreadScope();

                // EndUserLoggingCheckout -> AccessControlCheckout -> Checkout
                Kernel.Bind<ICheckout>().To<AccessControlCheckout>().WhenInjectedInto<EndUserLoggingCheckout>().InThreadScope();
            } 
            else
            {
                // EndUserLoggingCheckout -> Checkout
                Kernel.Bind<ICheckout>().To<Checkout>().WhenInjectedInto<EndUserLoggingCheckout>().InThreadScope();
            }

            // DebugLoggingCheckout -> EndUserLoggingCheckout
            Kernel.Bind<ICheckout>().To<EndUserLoggingCheckout>().WhenInjectedInto<DebugLoggingCheckout>().InThreadScope();
            
            // Entry point into the call: DebugLoggingCheckout isn't wrapped by anything.
            Kernel.Bind<ICheckout>().To<DebugLoggingCheckout>().InThreadScope();
        }
    }
}
