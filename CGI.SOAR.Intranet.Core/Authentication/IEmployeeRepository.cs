
namespace CGI.SOAR.Intranet.Core.Authentication
{
    public interface IEmployeeRepository
    {
      Employee GetEmployeeByEmail(string email);
    }
}
