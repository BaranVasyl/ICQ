using System.Threading.Tasks;
using ICQ.Api.Models.Login;
using ICQ.Api.Models.Users;
using ICQ.Data.Models;
using ICQ.Queries.Models;

namespace ICQ.Queries.Queries
{
    public interface ILoginQueryProcessor
    {
        UserWithToken Authenticate(string username, string password);
        Task<User> Register(RegisterModel model);
        Task ChangePassword(ChangeUserPasswordModel requestModel);
    }
}
