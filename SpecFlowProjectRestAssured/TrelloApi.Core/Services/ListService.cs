using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecFlowProjectRestAssured.TrelloApi.Core.Clients;
using SpecFlowProjectRestAssured.TrelloApi.Core.Models.Responses;
using SpecFlowProjectRestAssured.TrelloApi.Core.Utilities;

namespace SpecFlowProjectRestAssured.TrelloApi.Core.Services
{
    public class ListService : BaseTrelloClient
    {
        public ListService(ApiLogger logger) : base(logger) { }

        public async Task<ListResponse> CreateListAsync(string boardId, string listName)
        {
            var restRequest = RequestFactory.CreateRequest(
                "lists",
                Method.Post,
                new { name = listName, idBoard = boardId }
            );
            return await ExecuteAsync<ListResponse>(restRequest);
        }
    }
}
