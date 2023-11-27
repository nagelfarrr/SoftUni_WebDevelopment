function editElement(htmlElement, match, replacer) {
    const text = htmlElement.textContent;

    const matcher = new RegExp(match, 'g');
    const edited = text.replace(matcher, replacer);

    htmlElement.textContent = edited;
}