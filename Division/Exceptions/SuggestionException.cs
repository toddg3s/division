using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Division.Exceptions
{
    public class SuggestionException : Exception
    {
        public SuggestionException(string message) : base(message) { }
        public SuggestionException(string message, Exception inner) : base(message, inner) { }

    }
}
