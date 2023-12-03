function addItem() {
    const ul = document.querySelector("ul#items");
    const inputField = document.getElementById("newItemText");
    const textToAdd = inputField.value;

    const li = document.createElement("li");
    li.textContent = textToAdd;

    ul.appendChild(li);
    inputField.value = "";
    
}