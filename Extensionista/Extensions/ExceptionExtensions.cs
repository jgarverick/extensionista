using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extensionista
{
    public static class ExceptionExtensions
    {
        public static string Unwind(this Exception exception, bool includeStackTrace = false)
        {
            StringBuilder results = new StringBuilder();
            results.AppendLine(exception.Message);
            if (includeStackTrace) 
                results.AppendLine(exception.StackTrace);
            if (exception.InnerException != null) 
                results.AppendLine(exception.InnerException.Unwind(includeStackTrace));
            return results.ToString();
        }
    }
}
