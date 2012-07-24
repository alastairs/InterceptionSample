using System;
using System.Linq;
using NLog;
using Ninject;

namespace InterceptionSample
{
    public class Program
    {
        // The three properties define three configuration switches.  Toggle them to change the behaviour of the application.
        // See CheckoutModule for an example of how the application is composed differently based on the value of IsAccessControlEnabled.

        public static bool IsMemberOfStaff
        {
            // Toggle this to change behaviour!
            get { return false; }
        }

        public static bool IsDebugLoggingEnabled
        {
            // Tweak NLog.config to change behaviour: e.g., change the minLevel to Warn
            get
            {
                // Info level counts as debug information, as users only generally want messages about bad stuff.
                return LogManager.Configuration.LoggingRules.Single().IsLoggingEnabledForLevel(LogLevel.Info);
            }
        }

        public static bool IsAccessControlEnabled
        {
            // Toggle this to change behaviour!
            get { return true; }
        }

        public static void Main(string[] args)
        {
            const string items = "AABACDDAABCCCBA";

            var kernel = CreateKernel();
            var checkout = kernel.Get<ICheckout>();

            Console.WriteLine("Total for scanned items: {0:C2}", checkout.GetTotal(items));
            Console.WriteLine("Total for scanned items: {0:C2}", checkout.GetTotal(string.Empty));
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(typeof(Program).Assembly);

            RegisterServices(kernel);
            
            return kernel;
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IStockRoom>().To<StockRoom>().InThreadScope();
        }
    }
}
