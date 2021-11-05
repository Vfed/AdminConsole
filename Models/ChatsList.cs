using System;
using System.Collections.Generic;
using System.Text;

namespace AdminConsole.Models
{
    class ChatsList
    {
        public Guid Id { get; set; }
        public ChatUser ChatUser { get; set; }
        public Chat Chat { get; set; }
        public DateTime Current { get; set; }
    }
}
