using Ninject.Modules;

namespace InterceptionSample.StaticInterception.Modules
{
    public class AccessControlModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IAccessControlPolicy>().To<AccessControlPolicy>().WhenInjectedExactlyInto<LoggingAccessControlPolicy>();
            Kernel.Bind<IAccessControlPolicy>().To<LoggingAccessControlPolicy>().WhenInjectedExactlyInto<AccessControlCheckout>();
            Kernel.Bind<ICheckout>().To<AccessControlCheckout>().WhenInjectedInto<Checkout>();
        }
    }
}
