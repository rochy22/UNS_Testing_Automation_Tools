Feature: Database
  Background: 
    Given I am in the Creation section of the fms web portal

  Scenario: RF_06 - Almacenamiento de elementos requeridos
    When I complete the required fields for a new user
    Then Required fields must have the expected value
    And Log Out

  Scenario: RF_07 - Almacenamiento del usuario
    When I complete all fields for a new user
    Then All fields must have the expected value
    And Log Out

    