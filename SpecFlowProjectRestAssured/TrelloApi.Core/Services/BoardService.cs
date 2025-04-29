using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecFlowProjectRestAssured.TrelloApi.Core.Clients;
using SpecFlowProjectRestAssured.TrelloApi.Core.Models.Requests;
using SpecFlowProjectRestAssured.TrelloApi.Core.Models.Responses;
using SpecFlowProjectRestAssured.TrelloApi.Core.Utilities;

namespace SpecFlowProjectRestAssured.TrelloApi.Core.Services
{
    public class BoardService : BaseTrelloClient
    {
        public BoardService(ApiLogger logger) : base(logger) { }

        public async Task<BoardResponse> CreateBoardAsync(CreateBoardRequest request)
        {
            var restRequest = RequestFactory.CreateRequest(
                "boards",
                Method.Post,
                new { name = request.Name, defaultLists = request.CreateDefaultLists }
            );
            return await ExecuteAsync<BoardResponse>(restRequest);
        }

        public async Task<BoardResponse> GetBoardAsync(string boardId)
        {
            var restRequest = RequestFactory.CreateRequest($"boards/{boardId}", Method.Get);
            return await ExecuteAsync<BoardResponse>(restRequest);
        }

        public async Task DeleteBoardAsync(string boardId)
        {
            var request = new RestRequest($"boards/{boardId}", Method.Delete);
            await ExecuteAsync<object>(request);
        }
    }
}
