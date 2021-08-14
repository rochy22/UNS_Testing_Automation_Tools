import loginPage from '../support/pages/loginPage';
import creationPage from "../support/pages/creationPage";

describe('Specialties', () => {
    beforeEach(() => {
        loginPage.FillAndSubmit();
        creationPage.goToCreationPage();
    })
  
    it('RF_05 - Relación entre Specialties y Robot PiP - default value= true', () => {
      creationPage.getSpecialty(true);        
        cy.get('[aria-controls="humanTabstrip-4"]').click({force: true});
        cy.get('#ProviderAccess').check();
        cy.get('#RobotPipEnabled').should('be.checked') ;

        cy.scrollTo(0,0,{ ensureScrollable: false });
        cy.wait(2000);
        cy.get('#humanTabstrip > :nth-child(1) > .k-first > .k-link').click({force: true});
        cy.wait(2000);
        creationPage.getSpecialty(false);  
        cy.get('#SpecialtyId_listbox > :nth-child(1)').click(); 
        cy.get('[aria-controls="humanTabstrip-4"]').click({force: true});
        cy.get('#RobotPipEnabled').should('not.be.checked') ;
    })

    it('RF_05 - Relación entre Specialties y Robot PiP - default value= false', () => {
        creationPage.getSpecialty(false);        
        cy.get('[aria-controls="humanTabstrip-4"]').click({force: true});
        cy.get('#ProviderAccess').check();
        cy.get('#RobotPipEnabled').should('not.be.checked') ;

        cy.scrollTo(0,0,{ ensureScrollable: false });
        cy.wait(2000);
        cy.get('#humanTabstrip > :nth-child(1) > .k-first > .k-link').click({force: true});
        cy.wait(2000);
        creationPage.getSpecialty(true);   
        cy.get('#SpecialtyId_listbox > :nth-child(1)').click();
        cy.get('[aria-controls="humanTabstrip-4"]').click({force: true});
        cy.get('#RobotPipEnabled').should('be.checked') ;
      })
  
})