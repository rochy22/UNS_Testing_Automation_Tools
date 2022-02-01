const defaultValues = require('./defaultValues');

 class randomHelper{
    constructor(){
        this.username='abcdefghijklmnopqrstuvwxyz0123456789';
        this.invalidcharacters='!@#$%^&*()'
    }
    
    getRandomUsername(isValid,length=10) {
        let result = '';
        let charactersLength =0;
        for ( let i = 0; i < length; i++ ) {
            if(isValid){
                charactersLength= this.username.length;
                result += this.username.charAt(Math.floor(Math.random() * charactersLength));
        } else{
            charactersLength=this.invalidcharacters.length;
            result += this.invalidcharacters.charAt(Math.floor(Math.random() * charactersLength));
        }
        }
    
        return result;
    }

    getRandomString(characters,length=10) {
        let result = '';
        let charactersLength =characters.length;
        for ( let i = 0; i < length; i++ ) {
            result += characters.charAt(Math.floor(Math.random() * charactersLength));
        }
        return result;
    }

    getRandomNumber() {
        return Math.floor(Math.random() * 500);
    }

}

module.exports = new randomHelper();