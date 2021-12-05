*** Settings ***
Library  Selenium2Library
Library  String
Library  Collections
Library  BuiltIn

Resource  ../../Resources/KeywordDefinationFiles/LoginPage.robot
Resource  ../../Resources/KeywordDefinationFiles/CreationEditonPage.robot
Variables  ../../Resources/Locators/UserCreationEditionLocators.py
Variables  ../../Resources/Testdata/Environment.py
Variables  ../../Resources/Testdata/DefaultValues.py

*** Test Cases ***
RF_06 - Almacenamiento de elementos requeridos
    Open browser    ${FMSPortalBaseURL}   ${Browser}
    Fill And Submit
    Go To Creation Page
    ${result}=    Fill Fields
    ${parametrousername}=   Get From List    ${result}    0
    ${parametroEmail}=  Get From List    ${result}    1

    Click Button    ${SaveButtonLocator}
    Click Button    //button[.//text() = 'Confirm']
    Sleep   1s
    Verify Created User    username=${parametrousername}    email=${parametroEmail}    haveOptionals=FALSE
    close browser

RF_07 - Almacenamiento del usuario
    Open browser    ${FMSPortalBaseURL}   ${Browser}
    Fill And Submit
    Go To Creation Page
    ${result}=    Fill Fields    haveOptionals=TRUE
    ${parametrousername}=   Get From List    ${result}    0
    ${parametroEmail}=  Get From List    ${result}    1

    Click Button    ${SaveButtonLocator}
    Click Button    //button[.//text() = 'Confirm']
    Sleep   1s
    Verify Created User    username=${parametrousername}    email=${parametroEmail}    haveOptionals=TRUE
    close browser
*** Keywords ***

Go To Creation Page
    Go To    ${FMSPortalBaseURL}/HumanUser/Create