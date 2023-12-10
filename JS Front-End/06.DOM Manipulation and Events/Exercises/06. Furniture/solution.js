function solve() {
  const buttons = document.getElementById("exercise").getElementsByTagName("button");
  const generateBtn = buttons[0];
  const buyBtn = buttons[1];

  const textAreas = document.getElementsByTagName("textarea");
  const inputArea = textAreas[0];
  const outputArea = textAreas[1];

  generateBtn.addEventListener("click", generate);
  buyBtn.addEventListener("click", buy);

  function generate() {
    let input = JSON.parse(inputArea.value);
    const tableBody = document.querySelector("table > tbody");

    for (let i = 0; i < input.length; i++) {
      let furniture = input[i];

      let row = document.createElement("tr");
      row.innerHTML =
        `<td><img src="${furniture.img}"></td>
      <td><p>${furniture.name}</p></td>
      <td><p>${furniture.price}</p></td>
      <td><p>${furniture.decFactor}</p></td>
      <td><input type="checkbox"/></td>`;
      tableBody.appendChild(row);
    }
  }

  function buy() {
    let furniture = Array.from(document.querySelectorAll('#exercise table tbody tr'))
      .filter(r => r.querySelector('input').checked)
      .map(r => r.querySelector('p').textContent)
      .join(', ');

    let totalPrice = Array.from(document.querySelectorAll('#exercise table tbody tr'))
      .filter(r => r.querySelector('input').checked)
      .map(r => Number(r.querySelectorAll('p')[1].textContent))
      .reduce((a, b) => a + b, 0);

    let avgDecFactor = Array.from(document.querySelectorAll('#exercise table tbody tr'))
      .filter(r => r.querySelector('input').checked)
      .map(r => Number(r.querySelectorAll('p')[2].textContent))
      .reduce((a, b) => a + b, 0) / Array.from(document.querySelectorAll('#exercise table tbody tr'))
        .filter(r => r.querySelector('input').checked).length;

    document.querySelector('#exercise textarea:last-of-type').value = `Bought furniture: ${furniture}\nTotal price: ${totalPrice.toFixed(2)}\nAverage decoration factor: ${avgDecFactor}`;
  }
}