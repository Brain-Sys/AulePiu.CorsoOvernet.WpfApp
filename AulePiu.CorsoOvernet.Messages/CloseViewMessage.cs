using System;
using System.Collections.Generic;
using System.Text;

namespace AulePiu.CorsoOvernet.Messages
{
    public class CloseViewMessage : BaseMessage
    {
        public string ViewName { get; set; }
    }
}