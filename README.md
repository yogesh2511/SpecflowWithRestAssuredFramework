```markdown
# Trello API Automation Framework with BDD (SpecFlow)

This project is a BDD-style API automation framework designed for testing the **Trello API** using **SpecFlow**, **RestSharp**, and **.NET**. It follows the Gherkin syntax to define test scenarios and uses SpecFlow for step definitions, along with built-in support for reporting and data-driven testing.

## 🔧 Tech Stack

- [.NET 6 / .NET Core](https://dotnet.microsoft.com/)
- [SpecFlow](https://specflow.org/)
- [RestSharp](https://restsharp.dev/)
- [Newtonsoft.Json](https://www.newtonsoft.com/json)
- [ExtentReports](https://extentreports.com/) (for reporting)
- [NUnit](https://nunit.org/) or [xUnit](https://xunit.net/)
- [Trello REST API](https://developer.atlassian.com/cloud/trello/rest/api-group-actions/)

---
Thanks for pointing that out! Here's the corrected and clearly formatted folder structure section for the `README.md` file:

---

## 📁 Project Structure

```
TrelloApiAutomation/
│
├── Features/                    # Gherkin feature files
│   └── TrelloBoard.feature
│
├── StepDefinitions/            # Step definition implementations
│   └── TrelloBoardSteps.cs
│
├── Helpers/                    # API interaction utilities
│   └── TrelloApiHelper.cs
│
├── Hooks/                      # Hooks for setup/teardown
│   └── TestHooks.cs
│
├── Utils/                      # Utility and support classes
│   ├── ScenarioContextManager.cs
│   └── ConfigReader.cs
│
├── Reports/                    # HTML or other test reports
│   └── ExtentReport.html
│
├── appsettings.json            # Environment/API configuration
├── TrelloApiAutomation.csproj  # Project file
└── README.md                   # Project documentation
```


## ✅ Supported Trello API Scenarios

- Create a board
- Get board details
- Create a list in a board
- Add a card to a list
- Update card details
- Delete board or card

---

## 🔑 Prerequisites

- Visual Studio 2022+ or Rider
- .NET 6 SDK or later
- Trello API Key and Token (generate from [Trello Developer Portal](https://trello.com/app-key))

---

## ⚙️ Configuration (`appsettings.json`)

```json
{
  "Trello": {
    "ApiKey": "YOUR_API_KEY",
    "ApiToken": "YOUR_API_TOKEN",
    "BaseUrl": "https://api.trello.com/1"
  }
}
```

---

## 🚀 How to Run Tests

1. Clone the repository
2. Install dependencies via NuGet
3. Update `appsettings.json` with your credentials
4. Run tests using:
   - **Test Explorer in Visual Studio**, or
   - CLI command:  
     ```
     dotnet test
     ```

---

## 📊 Reporting

- An **Extent HTML Report** is generated after every test execution.
- Default path: `/Reports/ExtentReport.html`

---

## 🧪 Sample Gherkin Scenario

```gherkin
Feature: Trello Board API Test

  Scenario: Create a new Trello board
    Given I have a valid Trello API key and token
    When I create a new board with name "Test Board"
    Then the board should be created successfully
    And the response should contain the board name "Test Board"
```

---

## 🧰 CI/CD Integration (Optional)

You can integrate this framework with CI tools like **GitHub Actions**, **Azure DevOps**, or **Jenkins** for continuous testing.

---

## 👨‍💻 Author

**Yogesh Solanki**

---

## 📃 License

This project is licensed under the MIT License.
```

---

Would you like me to generate this README in a downloadable `.md` file or customize it with your project name and GitHub repo URL?
