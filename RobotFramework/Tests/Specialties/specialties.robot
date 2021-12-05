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
RF_05 - Relacion entre Specialties y Robot PiP - default value= true
    Open browser    ${FMSPortalBaseURL}   ${Browser}
    Fill And Submit
    Go To Creation Page
    ${Specialty}=   getSpecialtyFromDatabase    PiPEnabled=TRUE
    Input text    ${SpecialtyLocator}    ${Specialty}
    Sleep   1s
    Click Element    ${SpecialtyFirstElementLocator}

    Click Link    xpath://*[@id="humanTabstrip"]/ul/li[4]/a
    Sleep   1s
    Select Checkbox    id:ProviderAccess
    Execute JavaScript    window.scrollTo(0, document.body.scrollHeight)
    Sleep   1s
    Checkbox Should Be Selected    id:RobotPipEnabled

    Click Link    xpath://*[@id="humanTabstrip"]/ul/li[1]/a
    ${Specialty}=   getSpecialtyFromDatabase    PiPEnabled=FALSE
    Input text    ${SpecialtyLocator}    ${Specialty}
    Sleep   1s
    Click Element    ${SpecialtyFirstElementLocator}
    Click Link    xpath://*[@id="humanTabstrip"]/ul/li[4]/a
    Sleep   1s
    Checkbox Should Not Be Selected   id:RobotPipEnabled
    close browser


RF_06 - Relacion entre Specialties y Robot PiP - default value= false
    Open browser    ${FMSPortalBaseURL}   ${Browser}
    Fill And Submit
    Go To Creation Page
    ${Specialty}=   getSpecialtyFromDatabase    PiPEnabled=FALSE
    Input text    ${SpecialtyLocator}    ${Specialty}
    Sleep   1s
    Click Element    ${SpecialtyFirstElementLocator}

    Click Link    xpath://*[@id="humanTabstrip"]/ul/li[4]/a
    Sleep   1s
    Select Checkbox    id:ProviderAccess
    Execute JavaScript    window.scrollTo(0, document.body.scrollHeight)
    Sleep   1s
    Checkbox Should not Be Selected   id:RobotPipEnabled

    Click Link    xpath://*[@id="humanTabstrip"]/ul/li[1]/a
    ${Specialty}=   getSpecialtyFromDatabase    PiPEnabled=TRUE
    Input text    ${SpecialtyLocator}    ${Specialty}
    Sleep   1s
    Click Element    ${SpecialtyFirstElementLocator}
    Click Link    xpath://*[@id="humanTabstrip"]/ul/li[4]/a
    Sleep   1s
    Checkbox Should Be Selected   id:RobotPipEnabled
    close browser


*** Keywords ***

Go To Creation Page
    Go To    ${FMSPortalBaseURL}/HumanUser/Create