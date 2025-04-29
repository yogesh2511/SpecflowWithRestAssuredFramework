using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectRestAssured.TrelloApi.Core.Models.Responses
{
    public class CardResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Url { get; set; }
    }
}
