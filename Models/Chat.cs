using System;
using System.Collections.Generic;
using System.Text;

namespace AdminConsole.Models
{
    class Chat
    {
        public Guid ChatId { get; set; }
        public string ChatName { get; set; }
        public DateTime LastData { get; set; }
        public List<ChatsList> ChatsList { get; set; }
        public List<Message> Messages { get; set; }
    }
}
