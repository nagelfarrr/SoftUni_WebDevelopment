function addAndSubstract(num1, num2, num3) {

    let firstNum = sum(num1, num2);

    let result = subtract(firstNum, num3);

    console.log(result);

    function sum(x, y) {
        return x + y;
    }
    function subtract(x, y) {
        return x - y;
    }
}

addAndSubstract(42, 58, 100);