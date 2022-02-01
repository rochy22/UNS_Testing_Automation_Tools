Feature: Specialties
  Background: 
    Given I am in the Creation section of the fms web portal

  Scenario: RF_05 - Relación entre Specialties y Robot PiP   
    When I input an Specialties whit default value=<robotPipEnabled>
    Then Robot PiP Enabled should be displayed as <robotPipEnabled>
    And Log Out

    Examples:
      | robotPipEnabled |
      | true |
      | false |