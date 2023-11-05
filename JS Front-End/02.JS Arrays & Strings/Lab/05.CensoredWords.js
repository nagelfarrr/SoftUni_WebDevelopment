function censoreWords(text, censoredWord) {

    let regex = new RegExp(censoredWord, 'gi');
    let newText = "";

    if (text.includes(censoredWord)) {
        newText = text.replace(regex, '*'.repeat(censoredWord.length));
    }

    console.log(newText);
}