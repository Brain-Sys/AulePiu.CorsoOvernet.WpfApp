using System;
using System.Collections.Generic;
using System.Text;

namespace AulePiu.CorsoOvernet.DomainModel
{
    public class Machine : DomainObject
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int WorkHours { get; set; }
        public bool Maintenance { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.Code, this.Name);
        }
    }
}