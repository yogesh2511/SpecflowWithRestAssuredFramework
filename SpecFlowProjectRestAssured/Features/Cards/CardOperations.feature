Feature: Trello Card Operations
  Scenario: Add a card to a list
    Given I have a valid Trello list ID
    When I create a card with name "Test Card" and description "Test Description"
    Then the card should be created in the list