class defaultValues{
  
    InvalidUsername = "Invalid Username: it must be lowercase, should not start with 'endpoint' or 'anyone'. Allowed characters: a-z, 0-9, '-', '_' and '.'";
    InvalidLengthUsername= "The field Username must be a string with a maximum length of 64.";

    lowercaseAccentedCharacters = "äëïöüâêîôûáéíóúàèìùò";
    uppercaseAccentedCharacters = "ÄËÏÖÜÂÊÎÔÛÁÉÍÓÚÀÈÌÒÙ";
    uppercase = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
    lowercase = "abcdefghijkmnopqrstuvwxyz";
    numbers="1234567890";
    punctuationSymbol=".:;_-";
    validCharacters=this.uppercase+this.lowercase+this.numbers+"_-():.,+=@*/\;."
    username=this.lowercase+this.numbers+"-_.";
    name=this.uppercase+this.lowercase+this.lowercaseAccentedCharacters+this.uppercaseAccentedCharacters+"+.-"
    local=this.uppercase+this.lowercase+this.numbers+"!#$%&*+-/=?^_{|}~";
    domain=this.uppercase+this.lowercase+this.numbers+"-";
    }
    export default new defaultValues;