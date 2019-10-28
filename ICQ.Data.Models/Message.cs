using System;
using System.Collections.Generic;
using System.Text;

namespace ICQ.Data.Models
{
    public class Message
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Sticker { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public bool IsDeleted { get; set; }
    }
}
