function sortNames(names) {
    names.sort(function(a, b) {
        return a.toLowerCase().localeCompare(b.toLowerCase());
    });

    let count = 1;
    for (let i = 0; i <= names.length -1; i++) {
        
        console.log(`${count}.${names[i]}`)
        count++;
    }
}

sortNames([ "Ab", "cd", "bc"]);