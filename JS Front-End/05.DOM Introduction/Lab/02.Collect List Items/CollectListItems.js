function extractText() {
    const liItems = document.querySelectorAll("ul > li");
    let textArr = [];
    for (let i = 0; i < liItems.length; i++) {
        let liItemText = liItems[i].textContent;

        textArr.push(liItemText);
    }
    
    const textArea = document.getElementById('result');
    textArea.textContent = textArr.join("\n")
}