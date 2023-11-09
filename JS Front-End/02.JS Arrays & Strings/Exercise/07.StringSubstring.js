function findSubstring(substringToFind, text) {

    let textArr = text.split(" ");
    let isWordFound = false;

    for(let i = 0; i < textArr.length; i++) {
        
        let tempWord = textArr[i].toLowerCase();

        if(substringToFind.toLowerCase() === tempWord){
            isWordFound = true;
            break;
        }
    }

    if(isWordFound) {
        console.log(substringToFind)
    } else {
        console.log(`${substringToFind} not found!`);
    }
}

findSubstring('bEsT', 'JavaScript is the best programming language');