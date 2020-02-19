using System.Threading.Tasks;

namespace ShareApp.Models
{
    public interface IAppStateAware
    {
        void OnResumeApplicationAsync();
    }
}
