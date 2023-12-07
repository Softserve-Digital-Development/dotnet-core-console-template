using System.Threading.Tasks;

namespace NetCoreConsoleApp.Repositories.Interface
{
    public interface IConsoleService
    {
        /// <summary>
        /// Entry point to the console application.
        /// </summary>
        Task Run();
    }
}
