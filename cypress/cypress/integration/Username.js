import loginPage from '../support/pages/loginPage';
import creationPage from "../support/pages/creationPage";
import defaultValues from "../support/shared/defaultValues"

describe('Username', () => {
    beforeEach(() => {
        loginPage.FillAndSubmit();
        creationPage.goToCreationPage();
    })
  
    it('RF_01 - Caracteres permitidos', () => {
       creationPage.inputUsername(true);
       cy.get("[data-valmsg-for=Username]").should('be.empty') ;
       creationPage.inputUsername(false);
       cy.get("[data-valmsg-for=Username]").contains(defaultValues.InvalidUsername);
    })

    it('RF_02 - Prefijos no permitidos', () => {
      
        creationPage.inputSpecificUsername("endpoint");
        cy.get("[data-valmsg-for=Username]").contains(defaultValues.InvalidUsername);
        
        cy.get("#Username").clear();
        creationPage.inputSpecificUsername("anyone");
        //cy.wait(1000);
       cy.get(".field-validation-error > span").contains(defaultValues.InvalidUsername);
    })

    it('RF_04 - Longitud permitida', () => {
        cy.get("#Username").clear();
        creationPage.inputUsername(true,65);
        cy.wait(1000);
        cy.get(".field-validation-error > span").should('contain',defaultValues.InvalidLengthUsername);
    })

    it('RF_03 - Unico', () => {
        creationPage.verifyUser("1");
        creationPage.verifyUser("0");
        creationPage.verifyEnterpriseUser();
    })
   
})