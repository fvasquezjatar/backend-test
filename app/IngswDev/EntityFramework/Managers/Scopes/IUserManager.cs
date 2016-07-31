namespace IngswDev.EntityFramework.Managers.Scopes
{
    public interface IUserManager
    {
        bool Authenticate(string userId, string token);
    }
}
