function addItem() {
    const dropDownMenu = document.getElementById("menu");
    const text = document.getElementById("newItemText");
    const textValue = document.getElementById("newItemValue");


    const newItem = document.createElement("option");
    newItem.value = textValue.value;
    newItem.textContent = text.value;
    dropDownMenu.appendChild(newItem);
    text.value = "";
    textValue.value = "";

}