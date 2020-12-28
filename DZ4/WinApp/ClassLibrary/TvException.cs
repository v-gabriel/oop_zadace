using System;
using System.Collections.Generic;
using System.Runtime.Serialization;//needed for SerializationInfo & StreamingContext
using System.Text;

namespace ClassLibrary
{
    [Serializable]
    public class TvException : Exception
    {
        public string Title { get; private set; }
        public TvException() { }
        public TvException(string message) : base(message) { }
        public TvException(string message, string name) : base(message)
        {
            Title = name;
        }
        public TvException(string message, Exception innerException) : base(message, innerException)
        { }
        protected TvException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }

}
