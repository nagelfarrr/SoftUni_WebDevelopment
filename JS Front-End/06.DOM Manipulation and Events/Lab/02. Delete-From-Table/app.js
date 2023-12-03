function deleteByEmail() {
    const emailInput = document.querySelector("label input").value;
    const resultField = document.getElementById("result");
    const table = document.querySelectorAll("tbody tr td:nth-child(even)");
    
    for (let i = 0; i < table.length; i++) {
        if(emailInput === table[i].textContent) {
            table[i].parentNode.remove();
            resultField.textContent = "Deleted."
            return;
        } else {
            resultField.textContent = "Not found."
        }
        
    }
}