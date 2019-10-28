using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICQ.Api.Models.Message
{
    public class UpdateMessageModel
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public string Sticker { get; set; }
    }
}
