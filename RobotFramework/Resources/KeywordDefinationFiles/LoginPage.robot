*** Settings ***
Variables  ../Locators/LoginPageLocators.py
Variables  ../Testdata/TokenSecret.py

*** Keywords ***
Fill And Submit
    Input text    ${UsernameOrEmailLocator}   ${Username}
    Input text    ${PasswordLocator}   ${Password}
    Press Keys    ${ButtonLoginLocator}   ENTER