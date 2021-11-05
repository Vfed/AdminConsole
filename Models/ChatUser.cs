using System;
using System.Collections.Generic;
using System.Text;

namespace AdminConsole.Models
{
    class ChatUser
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public List<ChatsList> Chats { get; set; }
    }
}
