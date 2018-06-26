using System;
using System.Collections.Generic;
using System.Text;

namespace AulePiu.CorsoOvernet.Messages
{
    public class QuestionMessage : ShowMessage
    {
        public Action Yes { get; set; }
        public Action No { get; set; }

        public QuestionMessage(string title, string text)
            : base(title, text)
        {

        }
    }
}