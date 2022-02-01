const TokenSecret = require('../support/tokenSecret');

class LoginPage{

    get inputUsername () { return $('#UsernameOrEmail') }
    get inputPassword () { return $('#password') }
    get btnSubmit () { return $('#login') }
   
    async login (username, password) {
        await this.inputUsername.setValue(username);
        await this.inputPassword.setValue(password);
        await this.btnSubmit.click();
    }

    open () {
        return browser.url(TokenSecret.portalURL)
    }
}

module.exports = new LoginPage();
