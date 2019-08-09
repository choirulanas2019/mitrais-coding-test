using MitraisCodingTest.Core.Models;

namespace MitraisCodingTest.Core.Repositories.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        bool IsExistByEmail(string email);

        bool IsExistByMobileNumber(string mobileNumber);
    }
}
