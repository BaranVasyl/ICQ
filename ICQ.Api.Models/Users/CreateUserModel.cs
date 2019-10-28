using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICQ.Api.Models.Users
{
    public class CreateUserModel
    {
        public CreateUserModel()
        {
            Roles = new string[0];
        }

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string[] Roles { get; set; }
    }
}
