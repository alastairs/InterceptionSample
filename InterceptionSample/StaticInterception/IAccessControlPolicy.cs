namespace InterceptionSample.StaticInterception
{
    public interface IAccessControlPolicy
    {
        bool AllowsUserTo(string completeTask);
    }
}