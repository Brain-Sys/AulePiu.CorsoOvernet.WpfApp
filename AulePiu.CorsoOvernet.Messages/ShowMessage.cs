using System;
using System.Collections.Generic;
using System.Text;

namespace AulePiu.CorsoOvernet.Messages
{
    public class ShowMessage : BaseMessage
    {
        public string Title { get; private set; } = "Errore";
        public string Text { get; private set; }

        public ShowMessage(string title, string text)
        {
            this.Title = title;
            this.Text = text;
        }
    }
}