function findHashTag(text) {

    let textArr = text.split(" ");

    for(let i = 0; i < textArr.length; i++) {

        if(textArr[i].startsWith("#")) {
            const lettersRegex = /^[A-Za-z]+$/

            let word = textArr[i];
            word = word.slice(1);
            let isLetters = lettersRegex.test(word);

            if(!isLetters) {
                continue;
            } else {
                console.log(word);
            }
        }
    }
}

findHashTag('The symbol # is known #variously in English-speaking #regions as the #number sign');