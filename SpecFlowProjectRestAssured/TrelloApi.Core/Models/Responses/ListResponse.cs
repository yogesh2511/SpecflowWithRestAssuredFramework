using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectRestAssured.TrelloApi.Core.Models.Responses
{
    public class ListResponse
    {
        // Add properties and methods as needed to represent the response structure.  
        public string Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Url { get; set; }
        public string IdBoard { get; set; }
        public bool Closed { get; set; }
        public DateTime? DateLastActivity { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Source { get; set; }
        public string IdList { get; set; }
        public string IdCard { get; set; }
        public string IdCheckItem { get; set; }
        public string IdCheckItemState { get; set; }
        public string IdAttachment { get; set; }
        public string IdSticker { get; set; }
    }
}
