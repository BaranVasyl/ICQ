﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ICQ.Api.Models.Users
{
    public class UserWithTokenModel
    {
        public string Token { get; set; }
        public UserModel User { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
