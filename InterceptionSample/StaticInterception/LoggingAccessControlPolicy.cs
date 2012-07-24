using System;
using Ninject.Extensions.Logging;

namespace InterceptionSample.StaticInterception
{
    public class LoggingAccessControlPolicy : IAccessControlPolicy
    {
        private readonly IAccessControlPolicy accessControlPolicy;
        private readonly ILogger logger;

        public LoggingAccessControlPolicy(IAccessControlPolicy accessControlPolicy, ILogger logger)
        {
            if (accessControlPolicy == null)
            {
                throw new ArgumentNullException("accessControlPolicy");
            }

            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }

            this.accessControlPolicy = accessControlPolicy;
            this.logger = logger;
        }

        public bool AllowsUserTo(string completeTask)
        {
            var taskPermitted = accessControlPolicy.AllowsUserTo(completeTask);
            if (!taskPermitted)
            {
                logger.Warn("Illegal access attempted!");
            }

            return taskPermitted;
        }
    }
}
