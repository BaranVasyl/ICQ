using System;
using System.Linq;
using System.Threading.Tasks;
using ICQ.Api.Common.Exceptions;
using ICQ.Api.Models.Common;
using ICQ.Api.Models.Message;
using ICQ.Api.Models.Users;
using ICQ.Data.Access.DAL;
using ICQ.Data.Models;
using ICQ.Security;
using Microsoft.EntityFrameworkCore;

namespace ICQ.Queries.Queries
{
    public class MessageQueryProcessor : IMessageQueryProcessor
    {
        private readonly IUnitOfWork _uow;
        private readonly ISecurityContext _securityContext;

        public MessageQueryProcessor(IUnitOfWork uow, ISecurityContext securityContext)
        {
            _uow = uow;
            _securityContext = securityContext;
        }

        public IQueryable<Message> Get()
        {
            var query = GetQuery();
            return query;
        }

        private IQueryable<Message> GetQuery()
        {
            var q = _uow.Query<Message>()
                .Where(x => !x.IsDeleted);

            if (!_securityContext.IsAdministrator)
            {
                var userId = _securityContext.User.Id;
                q = q.Where(x => x.UserId == userId);
            }

            return q;
        }

        public Message Get(int id)
        {
            var user = GetQuery().FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                throw new NotFoundException("Expense is not found");
            }

            return user;
        }

        public async Task<Message> Create(TextMessageModel model)
        {
            var item = new Message
            {
                UserId = _securityContext.User.Id,
                Date = model.Date,
                Description = model.Description,
                Sticker = model.Sticker
            };

            _uow.Add(item);
            await _uow.CommitAsync();

            return item;
        }

        public async Task<Message> Update(int id, UpdateMessageModel model)
        {
            var message = GetQuery().FirstOrDefault(x => x.Id == id);

            if (message == null)
            {
                throw new NotFoundException("Expense is not found");
            }

            message.Description = model.Description;
            message.Sticker = model.Sticker;
            await _uow.CommitAsync();
            return message;
        }

        public async Task Delete(int id)
        {
            var user = GetQuery().FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                throw new NotFoundException("Message is not found");
            }

            if (user.IsDeleted) return;

            user.IsDeleted = true;
            await _uow.CommitAsync();
        }
    }
}
