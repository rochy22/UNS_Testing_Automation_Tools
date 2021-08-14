import randomHelper from '../helpers/randomHelper';
import defaultValues from '../shared/defaultValues';

class creationPage{
constructor(){
    this.url="/HumanUser/Create"
    this.LoginButton="#login"
    this.usernameField="#UsernameOrEmail"
    this.passwordField="#password"
}

goToCreationPage = () => {
    cy.visit(this.url);
}

inputUsername= (isvalid, lenght=10)=> {
    cy.get("#Username").clear();
    cy.get("#Username").type(randomHelper.getRandomUsername(isvalid,lenght));
    cy.get("#FirstName").click();        
}

inputSpecificUsername= (value)=> {
    cy.get("#Username").clear();
    cy.get("#Username").type(value);
    cy.get("#FirstName").click();        
}

AlreadyExists=(field) => {
    return 'The User with username \"'+field+'\" already exists. Please choose a different username.';
}

verifyUser = (isEnabled) =>{
     cy.sqlServer('SELECT TOP 1 UserId FROM [FMS2].[auth].[HumanUsers] WHERE [IsEnabled]='+isEnabled).then(userId => {
        let variable= 'SELECT TOP 1 username FROM [FMS2].[auth].[Users] WHERE [UserId] =\''+userId+'\'';
        cy.sqlServer(variable).then(data => {        
            this.inputSpecificUsername(data);
            cy.get(".field-validation-error > span").contains(this.AlreadyExists(data));
             }); 
    }); 
}

verifyEnterpriseUser = () =>{
    cy.get("#Username").clear();
    cy.sqlServer('SELECT TOP 1 UserId FROM [FMS2].[auth].[HumanUsers] WHERE [EnterpriseId] is not NULL').then(userId => {
        let variable= 'SELECT TOP 1 username FROM [FMS2].[auth].[Users] WHERE [UserId] =\''+userId+'\'';
        cy.sqlServer(variable).then(enterpriseName => {        
            this.inputSpecificUsername(enterpriseName);
            cy.wait(1000);
            cy.get(".field-validation-error > span").contains(this.AlreadyExists(enterpriseName));
             }); 
     });  
}

getSpecialty (robotPiPEnabled=false){
    let expectedValue=0;

    if(robotPiPEnabled) 
    {
        expectedValue=1;
    }
    cy.get(':nth-child(7) > :nth-child(5) > .k-widget > .k-dropdown-wrap > .k-input').clear();
    cy.sqlServer('SELECT TOP 1 * FROM [FMS2].[auth].[Specialties] where [RobotPipEnabled] = '+expectedValue).then(Specialty => {
    cy.get(':nth-child(7) > :nth-child(5) > .k-widget > .k-dropdown-wrap > .k-input').type(Specialty[1]);    
    })
    cy.wait(2000);
}

getSpecialtyById(id){
    cy.get(':nth-child(7) > :nth-child(5) > .k-widget > .k-dropdown-wrap > .k-input').clear();
    cy.sqlServer('SELECT TOP 1 * FROM [FMS2].[auth].[Specialties] where [SpecialtyId] = '+id).then(Specialty => {
    cy.get(':nth-child(7) > :nth-child(5) > .k-widget > .k-dropdown-wrap > .k-input').type(Specialty[1]);
    cy.get('#SpecialtyId_listbox').contains(Specialty[1]);
    })
}

getConnectivityGroupBy(id){
    cy.get('[name="ConnectivityGroupId_input"]').clear();
    cy.sqlServer('SELECT TOP 1 * FROM [FMS2].[fms].[ConnectivityGroups] WHERE [ConnectivityGroupId] = '+id).then(Id => {
        cy.get('[name="ConnectivityGroupId_input"]').type(Id[1]);
        cy.get('#ConnectivityGroupId_listbox').contains(Id[1]).click({force: true});
    })
}

getUserGroupBy(id){
    cy.get('[name="UsersGroupId_input"]').clear();
    cy.sqlServer('SELECT TOP 1 * FROM [FMS2].[auth].[UsersGroups] WHERE [UsersGroupId]='+id).then(Id => {
        cy.get('[name="UsersGroupId_input"]').type(Id[1]);
        cy.get('#UsersGroupId_listbox').contains(Id[1]).click({force: true});
    })
}

fillForm (optionals=false){
    let expectUsername=randomHelper.getRandomString(defaultValues.username);
    let expectFirstName=randomHelper.getRandomString(defaultValues.name);
    let expectLastName=randomHelper.getRandomString(defaultValues.name);
    let expectEmail=randomHelper.getRandomString(defaultValues.local)+'@'+randomHelper.getRandomString(defaultValues.domain)+'.com';
    let expectConnectivityGroup=randomHelper.getRandomNumber().toString();
    let expectEmail2=randomHelper.getRandomString(defaultValues.local)+'@'+randomHelper.getRandomString(defaultValues.domain)+'.com';
    let expectMobile=randomHelper.getRandomString(defaultValues.numbers);
    let expectTitle=randomHelper.getRandomString(defaultValues.validCharacters);
    let expectServiceLine=randomHelper.getRandomString(defaultValues.validCharacters);
    let expectComments=randomHelper.getRandomString(defaultValues.validCharacters);
    let expectAddress=randomHelper.getRandomString(defaultValues.validCharacters);
    let expectCity=randomHelper.getRandomString(defaultValues.validCharacters);
    let expectZip=randomHelper.getRandomString(defaultValues.numbers);
    let expectOfficePhone=randomHelper.getRandomString(defaultValues.numbers);
    let expectEmployer=randomHelper.getRandomString(defaultValues.validCharacters);
    let expectSpecialty=randomHelper.getRandomNumber();
    let expectUserGroup='1';
    let expectNPI="3751679044";
    let expectEpicEmp=randomHelper.getRandomString(defaultValues.numbers);
    let expectedPasword = randomHelper.getRandomPassword();    
    
    cy.get('#Username').type(expectUsername); 
    cy.get("#FirstName").type(expectFirstName);  
    cy.get("#LastName").type(expectLastName);
    cy.get("#Email").type(expectEmail);

    if(optionals){
        cy.get('#Email2').type(expectEmail2);  
        cy.get('#Mobile').type(expectMobile);  
        cy.get('#Title').type(expectTitle);  
        cy.get('#ServiceLine').type(expectServiceLine);  
        cy.get('#Comments').type(expectComments);  
        cy.get('#Address').type(expectAddress);           
        cy.get('#OfficePhone').type(expectOfficePhone);  
        cy.get('#Employer').type(expectEmployer);  
        this.getSpecialtyById(expectSpecialty);

        cy.get(':nth-child(5) > :nth-child(5) > .k-widget > .k-dropdown-wrap > .k-input').clear();
        cy.get(':nth-child(5) > :nth-child(5) > .k-widget > .k-dropdown-wrap > .k-input').type("United States");
        cy.get('#City').type(expectCity);  
        cy.get('#Zip').type(expectZip); 

        cy.get(':nth-child(3) > :nth-child(5) > .k-widget > .k-dropdown-wrap > .k-select > .k-icon').click();
        cy.get('#StateId_listbox').contains('Arkansas').click();
    }

    cy.get('[aria-controls="humanTabstrip-2"]').click({force: true});

    cy.get('#Password').type(expectedPasword);
    cy.get('#ConfirmPassword').type(expectedPasword);

    if(optionals){
    cy.get('#humanTabstrip-2 > .smallTable > tbody > :nth-child(3) > .editor-field > .k-widget > .k-dropdown-wrap > .k-input').click();
    cy.get('#challengeQuestion1_listbox > :nth-child(3)').click();
    cy.get('#humanTabstrip-2 > .smallTable > tbody > :nth-child(5) > .editor-field > .k-widget > .k-dropdown-wrap > .k-input').click();
    cy.get('#challengeQuestion2_listbox > :nth-child(4)').click();
    cy.get('#challengeAnswer1').type(randomHelper.getRandomString(defaultValues.validCharacters));
    cy.get('#challengeAnswer2').type(randomHelper.getRandomString(defaultValues.validCharacters));
    }

    cy.wait(2000);
    cy.contains('System Information').click({force: true});
    cy.wait(500);
    this.getConnectivityGroupBy(expectConnectivityGroup);

    if(optionals){
        this.getUserGroupBy(expectUserGroup);
        cy.get('#humanTabstrip-3 > .smallTable > tbody > :nth-child(4) > :nth-child(2) > .k-widget > .k-dropdown-wrap > .k-select > .k-icon').click();
        cy.get('#OrganizationLicenseDropdown_listbox').contains('CORE 01').click();
        cy.get('#humanTabstrip-3 > .smallTable > tbody > :nth-child(5) > :nth-child(2) > .k-widget > .k-dropdown-wrap > .k-select > .k-icon').click();
        cy.get('#OrganizationDropdown_listbox').contains('CORE 01').click();
        cy.get('#NationalProviderIdentifier').type(expectNPI);    
        cy.get('#IsEmployee').check();
       
        cy.get('#EpicEmpId').type(expectEpicEmp);
    }
    
    cy.get('.confirmForm').click();
    cy.get(':nth-child(1) > .ui-button-text').click();

    cy.wait(2000);

     cy.sqlServer('SELECT TOP 1 UserId FROM [FMS2].[auth].[Users] WHERE  [Username] =\''+expectUsername+'\'').then(userId => {
        let variable= 'SELECT TOP 1 * FROM [FMS2].[auth].[HumanUsers] WHERE [UserId] =\''+userId+'\'';   
        cy.sqlServer(variable).then(user => {   
            expect(user[1]).to.equal(expectFirstName);
            expect(user[2]).to.equal(expectLastName);
            expect(user[6]).to.equal(expectEmail);
            expect(user[10]).to.equal(expectConnectivityGroup);
            
            if(optionals){
               expect(user[3]).to.equal(expectAddress);
               expect(user[4]).to.equal(expectMobile);
               expect(user[5]).to.equal(expectOfficePhone);
               expect(user[7]).to.equal(expectEmail2);
               expect(user[8]).to.equal(expectTitle);              
               expect(user[9]).to.equal(expectSpecialty);
               expect(user[11]).to.equal(expectComments);
               expect(user[12]).to.equal(6);
               expect(user[14]).to.equal(1);
               expect(user[18]).to.equal(expectServiceLine);
               expect(user[21]).to.equal(expectEmployer);
               expect(user[22]).to.equal(expectCity);
               expect(user[23]).to.equal(4); //State
               expect(user[24]).to.equal(expectZip);
               expect(user[25]).to.equal(236);//country
               expect(user[26]).to.equal(expectUserGroup);                           
                expect(user[28]).to.equal('3B72BB1A-E354-4C2B-9BA0-8AD582CAD4AE'); //OrganizationLicense               
                expect(user[29]).to.equal('3B72BB1A-E354-4C2B-9BA0-8AD582CAD4AE'); //OrganizationProvider             
                expect(user[31]).to.be.true;
                expect(user[33]).to.equal(expectNPI);
                expect(user[34]).to.equal(expectEpicEmp)
            }
            else{
                expect(user[3]).to.be.null
                expect(user[4]).to.be.null
                expect(user[5]).to.be.null
                expect(user[7]).to.be.null
                expect(user[8]).to.be.null         
                expect(user[9]).to.be.null
                expect(user[11]).to.be.null
                expect(user[12]).to.be.null
                expect(user[14]).to.be.null
                expect(user[18]).to.be.null
                expect(user[21]).to.be.null
                expect(user[22]).to.be.null
                expect(user[23]).to.be.null
                expect(user[24]).to.be.null
                expect(user[25]).to.be.null
                expect(user[26]).to.equal("1");                      
                expect(user[28]).to.be.null               
                expect(user[29]).to.be.null             
                expect(user[31]).to.be.false;
                expect(user[33]).to.be.null
                expect(user[34]).to.be.null
            }
            
        })
    })
    
}

}
export default new creationPage;