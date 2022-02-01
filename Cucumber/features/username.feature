Feature: Username
  Background: 
    Given I am in the Creation section of the fms web portal

  Scenario: RF_01 - Caracteres permitidos    
    When I input an invalid username with invalid characters
    Then An error message should be displayed
    And Log Out

  Scenario: RF_03 - Unico  
    When I input an <state> username
    Then An error message that the user is already registered should be displayed
    And Log Out

    Examples:
      | state |
      | enable |
      | disable |
      | enterprise |


  Scenario: RF_04 - Longitud permitida
    When I input an username of 65 characters
    Then An error message about the allowed length should be displayed
    And Log Out

  Scenario: RF_02 - Prefijos no permitidos
    When I input an username with prefix <prefix>
    Then An error message should be displayed
    And Log Out

    Examples:
      | prefix |
      | endpoint |
      | anyone |