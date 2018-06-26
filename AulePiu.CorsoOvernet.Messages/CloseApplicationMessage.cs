using System;
using System.Collections.Generic;
using System.Text;

namespace AulePiu.CorsoOvernet.Messages
{
    public class CloseApplicationMessage : BaseMessage
    {
        public int ExitCode { get; set; }

        // ctor privato
        CloseApplicationMessage()
        {

        }

        private static CloseApplicationMessage empty;
        public static CloseApplicationMessage Empty
        {
            get
            {
                if (empty == null)
                {
                    empty = new CloseApplicationMessage();
                }

                return empty;
            }
        }
    }
}