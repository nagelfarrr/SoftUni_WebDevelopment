function splitWords(text) {

    let array = text.split(/(?=[A-Z])/);

    console.log(array.join(", "));
}

splitWords('ThisIsSoAnnoyingToDo');