function solve() {
  let input = document.getElementById("text").value;
  let currentCase = document.getElementById("naming-convention").value;

  let words = input.split(" ");
  let result = "";

  switch (currentCase) {
    case "Camel Case":
      for (let i = 0; i < words.length; i++) {

        let tempWord = words[i];
        if (i === 0) {
          tempWord = tempWord.toLowerCase();
          result += tempWord;
        } else {
          let firstChar = tempWord.charAt(0).toUpperCase();
          let remainingChars = tempWord.substring(1).toLowerCase();
          result += firstChar + remainingChars;
        }

      }
      break;
    case "Pascal Case":
      for (let i = 0; i < words.length; i++) {
        let tempWord = words[i];

        let firstChar = tempWord.charAt(0).toUpperCase();
        let remainingChars = tempWord.substring(1).toLowerCase();

        result += firstChar + remainingChars;
      }
      break;
    default:
      result = "Error!";
      break;
  }

  const resultDiv = document.getElementById("result");
  resultDiv.textContent = result;
}