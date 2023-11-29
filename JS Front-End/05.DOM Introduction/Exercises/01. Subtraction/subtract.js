function subtract() {
    const firstNum = Number(document.getElementById("firstNumber").value);
    const secondNum = Number(document.getElementById("secondNumber").value);

    const resultDiv = document.getElementById("result");
    resultDiv.textContent = firstNum - secondNum;
}