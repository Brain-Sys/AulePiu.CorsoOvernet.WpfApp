using System;

namespace AulePiu.CorsoOvernet.Authentication
{
    public class AuthEngine
    {
        public bool Check(string user, string pwd)
        {
            var result = false;

            if (user == "bologna" && pwd == "pwd")
            {
                result = true;
            }

            return result;
        }
    }
}