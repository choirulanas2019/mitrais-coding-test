using MitraisCodingTest.Core.Models;
using MitraisCodingTest.Core.Services.Request;
using MitraisCodingTest.Core.Services.Response;

namespace MitraisCodingTest.Core.Services.Interface
{
    public interface IUserService
    {
        void Add(UserRequest item);
    }
}
