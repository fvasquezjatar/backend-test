using System.Threading.Tasks;

namespace IngswDev.EntityFramework
{
    public interface IIngswDevDBSeed
    {
        Task SeedAsync();
    }
}
