*** Settings ***
Library  BuiltIn
Library  DatabaseLibrary
Library  OperatingSystem
Library  pymysql
Variables  ../Testdata/DefaultValues.py
Variables  ../Testdata/TokenSecret.py

*** Keywords ***
InputRandomUsername
    [Arguments]    ${isvalid}=True    ${lenght}=10    ${prefix}=Null
    IF    ${isvalid}
        ${result} =    Generate Random String    ${lenght}    [LOWER][NUMBERS]
    ELSE
        ${result} =    Generate Random String    ${lenght}    ${InvalidCharacters}
    END
    ${StringPrefix}=    Convert To String    ${prefix}
    IF    "${prefix}"=='Null'
        Input text    id:Username   ${result}
    ELSE
        Input text    id:Username   ${prefix}-${result}
    END
    Sleep   3s
    Input text    id:FirstName   test


getUserFromDatabase
    [Arguments]    ${unconfirmed}=Null    ${enterprise}=Null
    Connect To Database    pymssql    ${DBName}    ${DBUser}    ${DBPass}    ${DBHost}    ${PORT}
    ${output} =    Query   SELECT Username FROM FMS2.auth.Users where UserType=0;

    IF    "${unconfirmed}"=='TRUE'
        ${output} =    Query   SELECT Username FROM FMS2.auth.UnconfirmedUsers;
    END
    IF    "${enterprise}"=='TRUE'
        ${UserId} =    Query   SELECT UserId FROM FMS2.auth.HumanUsers where EnterpriseId is not NULL;
        Log    ${UserId [0] [0]}
        ${output} =    Query   SELECT Username FROM FMS2.auth.Users where UserId='${UserId [0] [0]}'
        Log    ${output [0] [0]}
    END

    Input text    id:Username   ${output [0] [0]}
    Input text    id:FirstName   test
    Sleep   2s
    Disconnect From Database

getSpecialtyFromDatabase
    [Arguments]    ${PiPEnabled}=TRUE
    Connect To Database    pymssql    ${DBName}    ${DBUser}    ${DBPass}    ${DBHost}    ${PORT}
    IF    "${PiPEnabled}"=='TRUE'
        ${output} =    Query   SELECT Name FROM FMS2.auth.Specialties where RobotPipEnabled=1;
    ELSE
        ${output} =    Query   SELECT Name FROM FMS2.auth.Specialties where RobotPipEnabled=0;
    END
    Sleep   2s
    Disconnect From Database
    [return]  ${output [0] [0]}


ErrorMessage
    [Arguments]    ${username}
    [return]  The User with username "${username}" already exists. Please choose a different username.


Fill Fields
    [Arguments]    ${haveOptionals}=FALSE
    ${time} =    Get Time   epoch
    Input text    id:Username   core_qa_user_${time}
    ${randomUsername} =   Get Value    id:Username
    Input text    id:FirstName   test
    Input text    id:LastName   test
    Input text    id:Email   core_qa_${time}@mailinator.com
    ${randomEmail} =   Get Value    id:Email
    IF    "${haveOptionals}"=='TRUE'
        Input text    id:Email2    ${DefaultEmail2}
        Input text    id:Mobile    ${DefaultMobile}
        Input text    id:Title    ${DefaultTitle}
        Input text    id:ServiceLine    ${DefaultServiceLine}
        Input text    id:Comments    ${DefaultComments}
        Input text    id:Employer    ${DefaultEmployer}
        Input text    ${SpecialtyLocator}   ${DefaultSpecialtyName}
        Input text    id:OfficePhone    ${DefaultOfficePhone}
        Input text    ${CountryLocator}    United States
        Input text    id:Zip    ${DefaultZip}
        Click Element    ${StateArrowLocator}
        Sleep   1s
        Click Element    ${DefaultStateLocator}
        Input text    id:City    ${DefaultCity}
        Input text    id:Address    ${DefaultAddress}
    END

    Click Link    xpath://*[@id="humanTabstrip"]/ul/li[2]/a
    Sleep   1s
    Input text    id:Password   New-1234
    Input text    id:ConfirmPassword   New-1234
    IF    "${haveOptionals}"=='TRUE'
        Click Element    ${SecondChallengeQuestionArrowLocator}
        Sleep   1s
        Click Element    ${Default2ndChallengeQuestionLocator}
        Input text    id:challengeAnswer2    test
        Click Element    ${ChallengeQuestionArrowLocator}
        Sleep   1s
        Click Element    ${DefaultChallengeQuestionLocator}
        Input text    id:challengeAnswer1    test
    END

    Click Link    xpath://*[@id="humanTabstrip"]/ul/li[3]/a
    Sleep   1s
    Click Element    ${ConnectivityGroupArrowLocator}
    Input text    ${ConnectivityGroupLocator}    ${DefaultConnectivityGroup}
    IF    "${haveOptionals}"=='TRUE'
        Click Element    ${SoloLicenseArrowLocator}
        Sleep   1s
        Click Element    ${DefaultSoloLicenseLocator}
        Input text    id:EpicEmpId    ${DefaultEpicEmpId}
        Select Checkbox    id:IsEmployee
        Click Element    ${PreferredTimezoneArrowLocator}
        Sleep   1s
        Click Element    ${DefaultPreferredTimezoneLocator}
        Input text    id:NationalProviderIdentifier    ${DefaultNationalProviderIdentifier}
        Click Element    ${OrganizationProviderArrowLocator}
        Sleep   1s
        Click Element    ${DefaultOrganizationProviderLocator}

        Click Element    ${OrganizationLicenseArrowLocator}
        Sleep   1s
        Click Element    ${DefaultOrganizationLicenseLocator}
        Input text    ${UserGroupLocator}    ${DefaultUsersGroupName}
    END


    ${result}=  Create List   ${randomUsername}   ${randomEmail}
    [return]  ${result}

Verify Created User
    [Arguments]    ${username}=Null    ${email}=Null    ${haveOptionals}=TRUE
    Connect To Database    pymssql    ${DBName}    ${DBUser}    ${DBPass}    ${DBHost}    ${PORT}
    ${output} =    Query   SELECT UserId FROM FMS2.auth.Users where Username='${username}';
    ${user} =    Query   SELECT * FROM FMS2.auth.HumanUsers where UserId='${output [0] [0]}';
    ${OrganizationIdFromDB} =    Query   SELECT OrganizationId FROM FMS2.fms.Organizations where SfName='${DefaultOrganization}';
    Should Be Equal    ${user[0][1]}  test
    Should Be Equal    ${user[0][2]}  test
    Should Be Equal    ${user[0][6]}  ${email}
    Should Be Equal    '${user[0][10]}'  '${DefaultConnectivityGroupId}'
    Should Be Equal    '${user[0][32]}'    'True'
    IF    "${haveOptionals}"=='TRUE'
        Should Be Equal    ${user[0][3]}    ${DefaultAddress}
        Should Be Equal    ${user[0][4]}    ${DefaultMobile}
        Should Be Equal    ${user[0][5]}    ${DefaultOfficePhone}
        Should Be Equal    ${user[0][7]}    ${DefaultEmail2}
        Should Be Equal    ${user[0][8]}    ${DefaultTitle}
        Should Be Equal    ${user[0][9]}    ${DefaultSpecialtyId}
        Should Be Equal    ${user[0][11]}    ${DefaultComments}
        Should Be Equal    ${user[0][12]}    ${DefaultChallengeQuestionId}
        Should Be Equal    ${user[0][14]}    ${DefaultChallengeQuestionTwoId}
        Should Be Equal    ${user[0][18]}    ${DefaultServiceLine}
        Should Be Equal    ${user[0][21]}    ${DefaultEmployer}
        Should Be Equal    ${user[0][22]}    ${DefaultCity}
        Should Be Equal    ${user[0][23]}    ${DefaultStateId}
        Should Be Equal    ${user[0][24]}    ${DefaultZip}
        Should Be Equal    ${user[0][25]}    ${DefaultCountryId}
        Should Be Equal    ${user[0][26]}    ${DefaultUsersGroupId}
        Should Be Equal    '${user[0][28]}'    '${OrganizationIdFromDB [0] [0]}'
        Should Be Equal    '${user[0][29]}'    '${OrganizationIdFromDB [0] [0]}'
        Should Be Equal    ${user[0][30]}    ${DefaultPreferredTimezone}
        Should Be Equal    '${user[0][31]}'    'True'
        Should Be Equal    '${user[0][33]}'    '${DefaultNationalProviderIdentifier}'
        Should Be Equal    ${user[0][34]}    ${DefaultEpicEmpId}
    ELSE
        Should Be Equal    ${user[0][3]}    ${None}
        Should Be Equal    ${user[0][4]}    ${None}
        Should Be Equal    ${user[0][5]}    ${None}
        Should Be Equal    ${user[0][7]}    ${None}
        Should Be Equal    ${user[0][8]}    ${None}
        Should Be Equal    ${user[0][9]}    ${None}
        Should Be Equal    ${user[0][11]}    ${None}
        Should Be Equal    ${user[0][12]}    ${None}
        Should Be Equal    ${user[0][13]}    ${None}
        Should Be Equal    ${user[0][14]}    ${None}
        Should Be Equal    ${user[0][15]}    ${None}
        Should Be Equal    ${user[0][18]}    ${None}
        Should Be Equal    ${user[0][21]}    ${None}
        Should Be Equal    ${user[0][22]}    ${None}
        Should Be Equal    ${user[0][23]}    ${None}
        Should Be Equal    ${user[0][24]}    ${None}
        Should Be Equal    ${user[0][25]}    ${None}
        Should Be Equal    '${user[0][26]}'    '1'
        Should Be Equal    ${user[0][27]}    ${None}
        Should Be Equal    ${user[0][28]}    ${None}
        Should Be Equal    ${user[0][29]}    ${None}
        Should Be Equal    ${user[0][30]}    Pacific Standard Time
        Should Be Equal    '${user[0][31]}'    'False'
        Should Be Equal    ${user[0][33]}    ${None}
        Should Be Equal    ${user[0][34]}    ${None}
    END
    Disconnect From Database




