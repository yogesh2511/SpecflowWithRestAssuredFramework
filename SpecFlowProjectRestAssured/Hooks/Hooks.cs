using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecFlowProjectRestAssured.TrelloApi.Core.Models.Responses;
using SpecFlowProjectRestAssured.TrelloApi.Core.Services;
using SpecFlowProjectRestAssured.TrelloApi.Core.Utilities;
using SpecFlowProjectRestAssured.Utility;
using TechTalk.SpecFlow;

namespace SpecFlowProjectRestAssured.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;
        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            ScenarioContextManager.Initialize(scenarioContext);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            ScenarioContextManager.Reset();

            // Clean up test data (e.g., delete boards/cards created during testing)
            if (_scenarioContext.TryGetValue<BoardResponse>("CreatedBoard", out var board))
            {
                var logger = (ApiLogger)_scenarioContext["ApiLogger"];
                var boardService = new BoardService(logger);
                boardService.DeleteBoardAsync(board.Id).Wait(); // Implement DeleteBoardAsync
            }
        }

    }
}
