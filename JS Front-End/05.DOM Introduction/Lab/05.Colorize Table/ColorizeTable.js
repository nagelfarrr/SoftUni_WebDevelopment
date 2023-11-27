function colorize() {
    const tRows = document.querySelectorAll("tr:nth-child(even)");

    for (let i = 0; i < tRows.length; i++) {
        tRows[i].style.background = "teal";
    }
}