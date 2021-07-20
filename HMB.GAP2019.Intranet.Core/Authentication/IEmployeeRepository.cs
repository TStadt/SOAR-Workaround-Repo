
namespace HMB.GAP2019.Intranet.Core.Authentication
{
    public interface IEmployeeRepository
    {
      Employee GetEmployeeByEmail(string email);
    }
}
