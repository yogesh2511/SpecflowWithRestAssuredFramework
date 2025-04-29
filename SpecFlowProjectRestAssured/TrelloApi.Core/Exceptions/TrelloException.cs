using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectRestAssured.TrelloApi.Core.Exceptions
{
    public class TrelloException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public TrelloException(HttpStatusCode statusCode, string message)
            : base($"Trello API Error ({statusCode}): {message}")
        {
            StatusCode = statusCode;
        }
    }
}
