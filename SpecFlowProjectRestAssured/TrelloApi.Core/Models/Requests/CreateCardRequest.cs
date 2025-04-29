using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectRestAssured.TrelloApi.Core.Models.Requests
{
    public class CreateCardRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ListId { get; set; }
    }
}
