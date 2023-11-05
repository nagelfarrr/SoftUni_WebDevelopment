function countString ( text, string) {
    const words = text.split(" ");

    let count = 0;

    for (const word of words) {
        if(word.toLowerCase() === string.toLowerCase()) {
            count++;
        }
    }

    console.log(count);
}

countString('softuni is great place for learning new programming languages','softuni');