using System;
using System.Collections.Generic;
using System.Text;

namespace AdminConsole.Models
{
    class Message
    {
        public Guid Id { get; set; }
        public Chat Chat { get; set; }
        public string UserName { get; set; }
        public string Massege { get; set; }
        public DateTime CurrentTime { get; set; }
    }
}
