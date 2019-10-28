using System.Linq;
using AutoMapper;
using ICQ.Api.Models.Users;
using ICQ.Data.Models;
using ICQ.Queries.Models;

namespace ICQ.Maps
{
    public class UserWithTokenMap : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression configuration)
        {
            var map = configuration.CreateMap<UserWithToken, UserWithTokenModel>();
        }
    }
}