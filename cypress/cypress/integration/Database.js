import loginPage from '../support/pages/loginPage';
import creationPage from "../support/pages/creationPage";

describe('Database', () => {
    beforeEach(() => {
        loginPage.FillAndSubmit();
        creationPage.goToCreationPage();
    })

    it('RF_06 - Almacenamiento de elementos requeridos', () => {
        creationPage.fillForm(false);   
      })
 
    it('RF_07 - Almacenamiento del usuario', () => {
      creationPage.fillForm(true);   
    })

})