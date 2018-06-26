using System;
using System.Collections.Generic;
using System.Text;

namespace AulePiu.CorsoOvernet.Messages
{
    public class OpenNewViewMessage
        : BaseMessage
    {
        public string ViewName { get; set; }
        public bool Modal { get; set; }
    }
}