function sumTable() {
    const tdElements = document.querySelectorAll("tr > td");

    let sum = 0;
    for (let i = 0; i < tdElements.length; i++) {
        if(Number(tdElements[i].textContent)){
            sum += Number(tdElements[i].textContent);
        }
    }

    const sumTdElement = document.getElementById("sum");
    sumTdElement.textContent = sum.toFixed(2);
}