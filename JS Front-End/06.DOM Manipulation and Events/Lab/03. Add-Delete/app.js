function addItem() {
    const ul = document.querySelector("ul#items");
    const inputField = document.getElementById("newItemText");
    const textToAdd = inputField.value;

    const li = document.createElement("li");
    li.textContent = textToAdd;

    ul.appendChild(li);
    const a  = document.createElement("a");
    a.href = "#";
    a.textContent = "[Delete]";

    li.appendChild(a);
    inputField.value = "";

    a.addEventListener("click", deleteItem);

    function deleteItem() {
        a.parentElement.remove();
    }

}