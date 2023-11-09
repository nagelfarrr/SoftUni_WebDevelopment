function printMatrix(n) {


    row = printRow(n);

    for (let i = 0; i < n; i++) {
        console.log(row);
    }


    function printRow(n) {

        let row = ""
        for (let i = 0; i < n; i++) {
            row += n + " ";
        }

        return row;
    }
}

printMatrix(3);