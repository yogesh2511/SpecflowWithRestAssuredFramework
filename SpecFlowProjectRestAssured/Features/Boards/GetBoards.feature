Feature: Get Boards
  In order to get boards from Trello
  As a user
  I want to be able to get boards from Trello
Background:
  Given API Base URL is configured
  And User is authenticated

@regression
Scenario: Check Get Boards
  When User sends GET request to 'GetBoards'
  Then the response status code should be 200
  And the response content type should be 'application/json'
  Then User getBoards response matches "get_boards.json" schema

@smoke
Scenario: Check Get a single Board
  When User sends GET request to 'GetBoards'
  Then User getBoards response matches "get_boards.json" schema
