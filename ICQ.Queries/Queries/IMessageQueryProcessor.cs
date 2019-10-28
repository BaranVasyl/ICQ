using System.Linq;
using System.Threading.Tasks;
using ICQ.Api.Models.Message;
using ICQ.Data.Models;

namespace ICQ.Queries.Queries
{
    public interface IMessageQueryProcessor
    {
        IQueryable<Message> Get();
        Message Get(int id);
        Task<Message> Create(TextMessageModel model);
        Task<Message> Update(int id, UpdateMessageModel model);
        Task Delete(int id);
    }
}
