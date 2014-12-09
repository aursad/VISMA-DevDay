using System.Collections.Generic;
using DevDay.Model;

namespace DevDay.ViewModel
{
    public class MessageViewModel
    {
        public List<MessageEntity> Start { get; set; } 
        public List<MessageEntity> Stop { get; set; }
        public List<MessageEntity> Continue { get; set; } 
    }

}