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
    public class CardService : BaseTrelloClient
    {
        public CardService(ApiLogger logger) : base(logger) { }

        public async Task<CardResponse> CreateCardAsync(CreateCardRequest request)
        {
            var restRequest = RequestFactory.CreateRequest(
                "cards",
                Method.Post,
                new { name = request.Name, desc = request.Description, idList = request.ListId }
            );
            return await ExecuteAsync<CardResponse>(restRequest);
        }

        public async Task<CardResponse> UpdateCardDescriptionAsync(string cardId, string newDescription)
        {
            var restRequest = RequestFactory.CreateRequest(
                $"cards/{cardId}",
                Method.Put,
                new { desc = newDescription }
            );
            return await ExecuteAsync<CardResponse>(restRequest);
        }
    }
}
