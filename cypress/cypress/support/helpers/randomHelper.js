import defaultValues from "../shared/defaultValues";

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
                charactersLength=this.username.length;
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

    getRandomNumber(min=1, max=10) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    getRandomPassword(){
        let result=''
        result +=this.getRandomString(defaultValues.uppercase,4);
        result +=this.getRandomString(defaultValues.lowercase,4);
        result +=this.getRandomString(defaultValues.numbers,4);
        result +=this.getRandomString(defaultValues.punctuationSymbol,4);
        return result;
    }
    
    }
    export default new randomHelper;