using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICQ.Api.Models.Message
{
    public class MessageModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Sticker { get; set; }
        public int UserId { get; set; }
        
        public string UserName { get; set; }
    }
}
