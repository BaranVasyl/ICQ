﻿using System;
using System.Linq;
using System.Threading.Tasks;
using ICQ.Api.Models.Common;
using ICQ.Api.Models.Message;
using ICQ.Api.Models.Users;
using ICQ.Data.Access.Constants;
using ICQ.Data.Models;
using ICQ.Filters;
using ICQ.Maps;
using ICQ.Queries.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ICQ.Server.RestAPI
{
    [Route("api/[controller]")]
    [Authorize(Roles = Roles.AdministratorOrManager)]
    public class UsersController : Controller
    {
        private readonly IUsersQueryProcessor _query;
        private readonly IAutoMapper _mapper;

        public UsersController(IUsersQueryProcessor query, IAutoMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        [HttpGet]
        [QueryableResult]
        public IQueryable<UserModel> Get()
        {
            var result = _query.Get();
            var models = _mapper.Map<User, UserModel>(result);
            return models;
        }

        [HttpGet("{id}")]
        public UserModel Get(int id)
        {
            var item = _query.Get(id);
            var model = _mapper.Map<UserModel>(item);
            return model;
        }

        //[HttpPost]
        //[ValidateModel]
        //public async Task<UserModel> Post([FromBody]CreateUserModel requestModel)
        //{
        //    var item = await _query.Create(requestModel);
        //    var model = _mapper.Map<UserModel>(item);
        //    return model;
        //}

        [HttpPost("{id}/password")]
        [ValidateModel]
        public async Task ChangePassword(int id, [FromBody]ChangeUserPasswordModel requestModel)
        {
            await _query.ChangePassword(id, requestModel);
        }

        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<UserModel> Put(int id, [FromBody]UpdateUserModel requestModel)
        {
            var item = await _query.Update(id, requestModel);
            var model = _mapper.Map<UserModel>(item);
            return model;
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _query.Delete(id);
        }
    }
}