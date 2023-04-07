using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Models
{
    public enum MessageType
    {
        Text = 0,
        Image
    }
    public class Message
    {
        public string Author { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public Guid Id { get; set; }

        public MessageType MessageType { get; set; }
    }
}
