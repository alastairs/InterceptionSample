namespace InterceptionSample.StaticInterception
{
    public class AccessControlPolicy : IAccessControlPolicy
    {
        public bool AllowsUserTo(string task)
        {
            // Only members of staff are allowed to check items out.
            return task == "checkout" && Program.IsMemberOfStaff;
        }
    }
}