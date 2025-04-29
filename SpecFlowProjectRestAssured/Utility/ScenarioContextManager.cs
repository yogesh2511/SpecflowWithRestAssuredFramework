using TechTalk.SpecFlow;

namespace SpecFlowProjectRestAssured.Utility
{
    public static class ScenarioContextManager
    {
        private static ScenarioContext _current;

        public static void Initialize(ScenarioContext context)
        {
            _current = context;
        }

        public static ScenarioContext Current
        {
            get
            {
                if (_current == null)
                {
                    throw new InvalidOperationException("ScenarioContext is not initialized.");
                }
                return _current;
            }
        }

        public static void Reset()
        {
            _current = null;
        }
    }
}
