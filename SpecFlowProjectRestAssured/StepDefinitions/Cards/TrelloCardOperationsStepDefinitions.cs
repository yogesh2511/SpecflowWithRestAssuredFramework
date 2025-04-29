using System;
using NUnit.Framework;
using SpecFlowProjectRestAssured.TrelloApi.Core.Models.Requests;
using SpecFlowProjectRestAssured.TrelloApi.Core.Models.Responses;
using SpecFlowProjectRestAssured.TrelloApi.Core.Services;
using SpecFlowProjectRestAssured.TrelloApi.Core.Utilities;
using TechTalk.SpecFlow;

namespace SpecFlowProjectRestAssured.StepDefinitions.Cards
{
    [Binding]
    public class TrelloCardOperationsStepDefinitions
    {
        private CardService _cardService;
        private CardResponse _cardResponse;
        private string _listId = "67c03fbc0310dc1fb7910dd3"; // Replace with actual list ID

        [Given(@"I have a valid Trello list ID")]
        public void GivenValidListId()
        {
            var logger = new ApiLogger();
            _cardService = new CardService(logger);
        }

        [When(@"I create a card with name ""(.*)"" and description ""(.*)""")]
        public async Task WhenICreateCard(string name, string description)
        {
            _cardResponse = await _cardService.CreateCardAsync(
                new CreateCardRequest
                {
                    Name = name,
                    Description = description,
                    ListId = _listId
                }
            );
        }

        [Then(@"the card should be created in the list")]
        public void ThenCardIsCreated()
        {
            Assert.IsNotNull(_cardResponse);
            Assert.AreEqual(_listId, _cardResponse.Id); // Ensure Id matches
        }
    }
}
