using System;
using System.Linq;
using System.Threading.Tasks;
using ICQ.Api.Models.Message;
using ICQ.Data.Models;
using ICQ.Filters;
using ICQ.Maps;
using ICQ.Queries.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ICQ.Server.RestAPI
{
    [Route("api/[controller]")]
    public class ExpensesController : Controller
    {
        private readonly IMessageQueryProcessor _query;
        private readonly IAutoMapper _mapper;

        public ExpensesController(IMessageQueryProcessor query, IAutoMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        [HttpGet]
        [QueryableResult]
        public IQueryable<MessageModel> Get()
        {
            var result = _query.Get();
            var models = _mapper.Map<Message, MessageModel>(result);
            return models;
        }

        [HttpGet("{id}")]
        public MessageModel Get(int id)
        {
            var item = _query.Get(id);
            var model = _mapper.Map<MessageModel>(item);
            return model;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<MessageModel> Post([FromBody]TextMessageModel requestModel)
        {
            var item = await _query.Create(requestModel);
            var model = _mapper.Map<MessageModel>(item);
            return model;
        }

        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<MessageModel> Put(int id, [FromBody]UpdateMessageModel requestModel)
        {
            var item = await _query.Update(id, requestModel);
            var model = _mapper.Map<MessageModel>(item);
            return model;
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _query.Delete(id);
        }
    }
}