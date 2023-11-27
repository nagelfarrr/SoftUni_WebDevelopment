function extract(content) {
    let textContent = document.getElementById(content).textContent;

    let regExp = /\(([^)]+)\)/g;
    let matches = textContent.match(regExp);

    if (matches) {
        return matches.map(match => match.replace(/^\(|\)$/g,)).join("; ");
    }
}