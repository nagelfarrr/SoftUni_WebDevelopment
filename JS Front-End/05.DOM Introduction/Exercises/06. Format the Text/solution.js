function solve() {
  var inputText = document.getElementById('input').value;
  var sentences = inputText.split('.')
  .filter(sentence => sentence.length > 0)
  .map(sentence => sentence += ".");

  var outputDiv = document.getElementById('output');

  while (sentences.length > 0) {
    let p = document.createElement("p");

    p.textContent = sentences.splice(0, 3).join("");
    outputDiv.appendChild(p);
  }
  
}