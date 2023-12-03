function generateReport() {
    const checkBoxes = document.querySelectorAll('input[type="checkbox"]')
    const tableRows = document.querySelectorAll("table tbody tr");

    const selectedData = [];

    for (const row of tableRows) {
        let rowData = {};
        let rowCells = row.querySelectorAll("td");

        for (let i = 0; i < checkBoxes.length; i++) {
            if (checkBoxes[i].checked) {
                const headerName = checkBoxes[i].parentElement.textContent.toLowerCase().trim();
                const cellText = rowCells[i].textContent;

                rowData[headerName] = cellText;
            }

        }

        if (Object.keys(rowData).length > 0) {
            selectedData.push(rowData);
        }
    }

    document.getElementById("output").textContent = JSON.stringify(selectedData, null,2);
}