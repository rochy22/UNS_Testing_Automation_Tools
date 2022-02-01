const defaultValues = require('../support/defaultValues');

class HomePage{

    get inputMyAccount () { return $('//*[@id="Menu"]/li[11]/a/span') }
    get inputLogOut () { return $('//*[@id="Menu"]/li[11]/div/ul/li[2]/a') }

    async LogOut() {        
        return  browser.url('/Account/LogOut');
    }

}

module.exports = new HomePage();
