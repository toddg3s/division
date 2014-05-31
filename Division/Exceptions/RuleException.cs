using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Division.Exceptions
{
    public class RuleException : Exception
    {
        public RuleException(string message) : base(message) { }
        public RuleException(string message, Exception inner) : base(message, inner) { }
    }
}
