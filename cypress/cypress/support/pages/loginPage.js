class loginPage{
constructor(){
    this.LoginButton="#login"
    this.usernameField="#UsernameOrEmail"
    this.passwordField="#password"
}

Submit = () => {
    cy.get("#login").click();
}

FillAndSubmit = () => {
    cy.fixture('envValues.json').then((values)=>{
        cy.visit('');
        cy.get(this.usernameField).type(values.username)
        cy.get(this.passwordField).type(values.password)
        this.Submit();
    })
    
}

}
export default new loginPage;