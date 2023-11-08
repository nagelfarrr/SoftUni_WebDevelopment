function revealWords(words, text) {

    let wordsArr = words.split(", ");
    let textArr = text.split(" ");

    for (const word of textArr) {
        for (let i = 0; i < wordsArr.length; i++) {
            if(word.startswWth("*") && word.length() === wordsArr[i].length) {
                word.replace(wordsArr[i]);
            }
            
        }
    }
    
    const outputText = "";

    

    
    console.log(text);
}

revealWords('great, learning', 'softuni is ***** place for ******** new programming languages');