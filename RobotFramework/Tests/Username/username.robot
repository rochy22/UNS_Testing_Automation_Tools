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
RF_01-Caracteres_permitidos
    Open browser    ${FMSPortalBaseURL}   ${Browser}
    Fill And Submit
    GoToCreationPage
    InputRandomUsername    True
    Page Should Not Contain Element    ${ErrorMessageLocator}

    InputRandomUsername    False
    Wait Until Page Contains Element    ${ErrorMessageLocator}
    ${actual_value}=    Get Text    ${ErrorMessageLocator}
    Should Contain    ${actual_value}    ${MesssageInvalidUsername}
    close browser


RF_02 - Prefijos no permitidos
    Open browser    ${FMSPortalBaseURL}   ${Browser}
    Fill And Submit
    GoToCreationPage
    InputRandomUsername    prefix=endpoint
    ${actual_value}=    Get Text    ${ErrorMessageLocator}
    Should Contain    ${actual_value}    ${MesssageInvalidUsername}

    InputRandomUsername    prefix=anyone
    ${actual_value}=    Get Text    ${ErrorMessageLocator}
    Should Contain    ${actual_value}    ${MesssageInvalidUsername}
    close browser

RF_03 - Unico
    Open browser    ${FMSPortalBaseURL}   ${Browser}
    Fill And Submit
    GoToCreationPage
    getUserFromDatabase
    ${actual_value}=    Get Value    xpath://*[@id="Username"]
    ${error_value}=    Get Text    ${ErrorMessageLocator}
    ${expected_message} =   ErrorMessage    ${actual_value}
    Should Contain    ${error_value}    ${expected_message}

    getUserFromDatabase    enterprise=TRUE
    ${actual_value}=    Get Value    id:Username
    ${error_value}=    Get Text    ${ErrorMessageLocator}
    ${expected_message} =   ErrorMessage    ${actual_value}
    Should Contain    ${error_value}    ${expected_message}

    Fill Fields
    Click Link    xpath://*[@id="humanTabstrip"]/ul/li[1]/a
    Sleep   1s
    getUserFromDatabase    unconfirmed=TRUE
    Click Button    xpath://*[@id="content"]/div/div[2]/form/fieldset/p/input
    Sleep   1s
    Click Button    //button[.//text() = 'Confirm']
    ${actual_value}=    Get Value    id:Username
    ${error_value}=    Get Text    ${ErrorBackendMessageLocator}
    ${expected_message} =   ErrorMessage    ${actual_value}
    Should Contain    ${error_value}    ${expected_message}
    close browser

RF_04 - Longitud permitida
    Open browser    ${FMSPortalBaseURL}   ${Browser}
    Fill And Submit
    GoToCreationPage
    InputRandomUsername    isvalid=True    lenght=65
    ${actual_value}=    Get Text    ${ErrorMessageLocator}
    Should Contain    ${actual_value}    ${MesssageInvalidLength}
    close browser


*** Keywords ***

GoToCreationPage
    Go To    ${FMSPortalBaseURL}/HumanUser/Create