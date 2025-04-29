using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectRestAssured.TrelloApi.Core.Models.Requests
{
    public class CreateBoardRequest
    {
        public string Name { get; set; }
        public bool CreateDefaultLists { get; set; } = true;
    }

   
}
