using System.Linq;
using AutoMapper;
using ICQ.Api.Models.Message;
using ICQ.Api.Models.Users;
using ICQ.Data.Models;

namespace ICQ.Maps
{
    public class ExpenseMap : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression configuration)
        {
            var map = configuration.CreateMap<Message, MessageModel>();
            map.ForMember(x => x.UserName, x => x.MapFrom(y => y.User.FirstName + " " + y.User.LastName));
        }
    }
}